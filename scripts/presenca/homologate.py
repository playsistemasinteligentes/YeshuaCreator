"""Run ONLY the additive existing-database Presenca fixture, using the unified private loader.

No database reset, migration, timer or external delivery. Default is read-only preflight.
The operator supplies the expected database identity and an already provisioned, labelled
test tenant/actors. Credentials are never command arguments, output or saved evidence.
"""
import argparse
from datetime import datetime, timezone
import json
import os
from pathlib import Path
import re
import subprocess
import sys

sys.path.insert(0, str(Path(__file__).resolve().parent))
import feed


def plan(document, args):
    apps = document.get('Apps', {})
    config = apps.get('Presenca', {}).get('MyConfig', {})
    read, write = (config.get(k) for k in ('ReadConectionString', 'WriteConectionString'))
    if not all(isinstance(s, str) and s.strip() and not s.startswith('<') for s in (read, write)):
        raise ValueError('Explicit Presenca read/write connections required.')
    if (not isinstance(args.database, str) or 'presenca' not in args.database.casefold()
            or not args.server or not re.fullmatch(r'PRESENCA_HOMOLOG_[A-Za-z0-9_-]{1,40}', args.marker)
            or min(args.tenant, args.author, args.approver) <= 0 or args.author == args.approver
            or args.browser and not args.exercise):
        raise ValueError('Explicit database identity and labelled test tenant/actors required.')
    peers = [value for name, app in apps.items() if name != 'Presenca'
             for key, value in app.get('MyConfig', {}).items()
             if key in ('ReadConectionString', 'WriteConectionString') and isinstance(value, str) and value]
    return dict(Read=read, Write=write, Peers=peers, Database=args.database, Server=args.server,
                Tenant=args.tenant, Author=args.author, Approver=args.approver,
                Marker=args.marker, Exercise=args.exercise, Browser=args.browser)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--credentials', required=True)
    parser.add_argument('--database', required=True)
    parser.add_argument('--server', required=True, help="Expected SQL SERVERPROPERTY('ServerName'), not a password")
    parser.add_argument('--tenant', required=True, type=int)
    parser.add_argument('--author', required=True, type=int)
    parser.add_argument('--approver', required=True, type=int)
    parser.add_argument('--marker', required=True)
    parser.add_argument('--exercise', action='store_true', help='Persist new labelled records; never delete/reset them')
    parser.add_argument('--browser', action='store_true', help='Also run prepared local Chromium against actual API/SQL')
    parser.add_argument('--evidence', default=None, help='Sanitized checkpoint JSON; retained even if an exercise fails')
    args = parser.parse_args()
    try:
        binding = plan(feed.private_document(args.credentials), args)
        child = dict(os.environ)
        # The destructive disposable suites are NEVER selected, even when inherited variables exist.
        child.pop('YESHUA_TEST_SQL', None)
        child.pop('YESHUA_TEST_SQL_PASSWORD', None)
        child['YESHUA_PRESENCA_HOMOLOGATION'] = json.dumps(binding)
        evidence = Path(args.evidence or '/tmp/presenca-homologation-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%S%f')+'.json').absolute()
        # Preserve old checkpoints. Parent must already exist; no private file or directory is changed.
        with evidence.open('x', encoding='utf-8') as checkpoint:
            checkpoint.write(json.dumps({'status': 'prepared-not-executed', 'writesExecuted': False})+'\n')
        child['YESHUA_PRESENCA_HOMOLOGATION_EVIDENCE'] = str(evidence)
        root = Path(__file__).resolve().parents[2]
        return subprocess.run(['dotnet', 'test', str(root/'tests/Presenca/Yeshua.Presenca.Tests'),
                               '--filter', 'Category=ExistingDatabase', '--logger', 'console;verbosity=minimal'],
                              cwd=root, env=child, check=False).returncode
    except Exception:
        print(json.dumps({'status': 'blocked', 'code': 'PRESENCA_HOMOLOGATION_CONFIGURATION_UNAVAILABLE',
                          'writesExecuted': False}), file=sys.stderr)
        return 1


if __name__ == '__main__':
    sys.exit(main())
