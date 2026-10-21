from contextlib import redirect_stderr, redirect_stdout
import copy
import importlib.util
import io
import json
import os
from pathlib import Path
import unittest
from unittest.mock import patch

from test_credentials import ROOT, configured

spec = importlib.util.spec_from_file_location("setup_sql_access_tests", ROOT / "infra/private/sql_access.py")
access = importlib.util.module_from_spec(spec)
spec.loader.exec_module(access)

PASSWORD = "fixture-login-password-'$-never-log"


def declarations():
    document = configured()
    document["Shared"]["SqlServer"]["Logins"] = {
        "app]login": {"Password": PASSWORD, "Databases": {"APP]DB": ["db_datareader", "db_datawriter"]}}}
    return document


class SqlAccessTests(unittest.TestCase):
    def provision(self, document, **options):
        with patch.object(access.private, "read_json", return_value=document), \
                patch.object(access.private, "environment"), \
                patch.object(access.sql, "sql_inventory", return_value=({}, "client")), \
                patch.object(access, "execute_batch") as execute:
            result = access.provision(Path("/private/credentials.json"), **options)
        return result, execute

    def test_sa_only_needs_no_new_declaration_and_no_mutation(self):
        document = configured()
        document["Shared"]["SqlServer"].pop("Logins", None)
        result, execute = self.provision(document)
        self.assertTrue(result["admin_connection_verified"])
        self.assertEqual(0, result["declared_logins"])
        execute.assert_not_called()

    def test_additional_accounts_are_explicit_and_passwords_not_rotated_or_printed(self):
        document = declarations()
        before = copy.deepcopy(document)
        with redirect_stdout(io.StringIO()) as stdout, redirect_stderr(io.StringIO()) as stderr:
            result, execute = self.provision(document)
        self.assertEqual(before, document)
        self.assertFalse(result["passwords_rotated"])
        self.assertNotIn(PASSWORD, stdout.getvalue() + stderr.getvalue() + json.dumps(result))
        self.assertEqual(2, execute.call_count)
        batch = execute.call_args_list[0].args[2]
        self.assertIn("IF SUSER_ID", batch)
        self.assertIn("CREATE LOGIN [app]]login]", batch)
        self.assertIn("PWDCOMPARE", batch)
        self.assertIn("password-''$-never-log", batch)
        self.assertNotIn("ALTER LOGIN", batch)
        self.assertNotIn("CREATE ANY DATABASE", batch)

    def test_database_access_repairs_orphan_mapping_and_grants_only_declared_roles(self):
        _, execute = self.provision(declarations())
        batch = execute.call_args_list[1].args[2]
        for expected in ("USE [APP]]DB]", "CREATE USER [app]]login]", "ALTER USER [app]]login] WITH LOGIN=",
                         "ALTER ROLE [db_datareader]", "ALTER ROLE [db_datawriter]", "IS_ROLEMEMBER", "authentication_type<>1",
                         "SELECT owner_sid FROM sys.databases WHERE name=DB_NAME()"):
            self.assertIn(expected, batch)
        for forbidden in ("db_owner", "sysadmin", "DROP USER", "REVOKE", "REPLACE"):
            self.assertNotIn(forbidden, batch)
        self.assertIn("Declared access database is missing", batch)

    def test_missing_database_is_deferred_only_before_its_migration(self):
        result, execute = self.provision(declarations(), allow_missing=True)
        self.assertTrue(result["missing_databases_deferred"])
        self.assertNotIn("Declared access database is missing", execute.call_args_list[1].args[2])
        self.assertNotIn("CREATE DATABASE", execute.call_args_list[1].args[2])

    def test_create_database_permission_requires_explicit_declaration(self):
        document = declarations()
        document["Shared"]["SqlServer"]["Logins"]["app]login"]["CreateDatabase"] = True
        _, execute = self.provision(document)
        self.assertIn("GRANT CREATE ANY DATABASE TO [app]]login]", execute.call_args_list[0].args[2])
        self.assertNotIn("sysadmin", execute.call_args_list[0].args[2])

    def test_secrets_stay_in_stdin_and_admin_environment_not_argv(self):
        with patch.dict(os.environ, SQLCMDINI="hostile"), patch.object(access.sql, "run") as run:
            access.execute_batch("fixture-admin-password", "client", PASSWORD)
        args = run.call_args.args[0]
        self.assertNotIn(PASSWORD, " ".join(args))
        self.assertNotIn("fixture-admin-password", " ".join(args))
        self.assertNotIn("-Q", args)
        self.assertNotIn("-P", args)
        self.assertIn("-x", args)
        self.assertIn("/dev/stdin", args)
        self.assertEqual(PASSWORD, run.call_args.kwargs["input"])
        self.assertEqual("fixture-admin-password", run.call_args.kwargs["env"]["SQLCMDPASSWORD"])
        self.assertNotIn("SQLCMDINI", run.call_args.kwargs["env"])

    def test_entire_manifest_is_validated_before_any_sql(self):
        document = declarations()
        document["Shared"]["SqlServer"]["Logins"]["later"] = {"Password": ""}
        with patch.object(access.private, "read_json", return_value=document), \
                patch.object(access.private, "environment"), patch.object(access.sql, "sql_inventory") as inventory, \
                patch.object(access, "execute_batch") as execute:
            with self.assertRaises(access.private.ConfigurationError):
                access.provision(Path("/private/credentials.json"))
            execute.assert_not_called()
            inventory.assert_not_called()

    def test_admin_not_ready_retries_only_connection_not_mutations(self):
        with patch.object(access.private, "read_json", return_value=configured()), \
                patch.object(access.private, "environment"), patch.object(access.time, "monotonic", side_effect=[0, 0, 2]), \
                patch.object(access.time, "sleep") as sleep, \
                patch.object(access.sql, "sql_inventory", side_effect=access.sql.InventoryError("fixture")) as inventory, \
                patch.object(access, "execute_batch") as execute:
            with self.assertRaisesRegex(access.sql.InventoryError, "admin_not_ready"):
                access.provision(Path("/private/credentials.json"), wait_seconds=1)
            self.assertEqual(2, inventory.call_count)
            sleep.assert_called_once_with(2)
            execute.assert_not_called()

    def test_unsafe_roles_names_and_passwords_are_rejected_without_values(self):
        changes = ({"Password": ""}, {"Password": "<complete>"}, {"Password": "secret\nvalue"},
                   {"CreateDatabase": "true"}, {"ServerRole": "sysadmin"},
                   {"Databases": {"master": ["db_owner"]}}, {"Databases": {"App": ["sysadmin"]}},
                   {"Databases": {"App": ["db_datareader", "db_datareader"]}},
                   {"Databases": {"App": ["db_datareader]; DROP DATABASE other"]}},
                   {"Databases": {"App": [{}]}}, {"Databases": {"App": None}})
        for change in changes:
            document = declarations()
            document["Shared"]["SqlServer"]["Logins"]["app]login"].update(change)
            with self.subTest(change=change), self.assertRaises(access.private.ConfigurationError) as error:
                access.private.sql_logins(document)
            self.assertNotIn(PASSWORD, str(error.exception))
        for name in ("sa", "dbo", "SA", "guest", "", "bad\nname", "x" * 129):
            document = declarations()
            entry = document["Shared"]["SqlServer"]["Logins"].pop("app]login")
            document["Shared"]["SqlServer"]["Logins"][name] = entry
            with self.subTest(name=name), self.assertRaises(access.private.ConfigurationError):
                access.private.sql_logins(document)

    def test_ambiguous_names_and_malformed_sections_are_rejected(self):
        document = declarations()
        logins = document["Shared"]["SqlServer"]["Logins"]
        logins["APP]LOGIN"] = copy.deepcopy(logins["app]login"])
        with self.assertRaises(access.private.ConfigurationError):
            access.private.sql_logins(document)
        for value in (None, [], "secret"):
            document = declarations()
            document["Shared"]["SqlServer"]["Logins"] = value
            with self.assertRaises(access.private.ConfigurationError):
                access.private.sql_logins(document)

    def test_new_login_password_is_not_exported_to_apps(self):
        values = access.private.exports(declarations(), Path("/private"), "all")
        self.assertNotIn(PASSWORD, values.values())

    def test_setup_hook_remains_between_migration_and_service_start(self):
        for folder, service in (("Central", "central"), ("Clinica", "clinica"), ("APS.ADM", "aps-adm"),
                                ("Fiscal", "fiscal"), ("Memorias", "memorias")):
            script = (ROOT / "infra" / folder / "DockerCompose/deploy.sh").read_text()
            self.assertLess(script.index("docker compose run --rm " + service + "-migration"), script.index("yeshua_setup_sql_access"))
            self.assertLess(script.index("yeshua_setup_sql_access"), script.index("docker compose up -d --remove-orphans"))


if __name__ == "__main__":
    unittest.main()
