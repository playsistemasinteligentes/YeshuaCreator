using Interfaces.Schemas;
using Migration.Dominio.Migration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Migration.Interfaces;
using System.Data.Common;
using Migration.Dominio;
using Module = Migration.Dominio.Module;
using static Dapper.SqlMapper;
using Microsoft.IdentityModel.Tokens;

namespace Dominio.Migration
{
    public class MigrationBuilder
    {
        private List<ISchema> _schemas;
        private IEnumerable<MigrationBase> _migrations = new List<MigrationBase>();
        private MigrationDiscovery _migrationDiscovery;
        private List<Entity> sanitizedEntities = new List<Entity>();
        private List<Module> sanitizedMedules = new List<Module>();
        private MigrationBase _migrationConcriteBase = new M000000();
        public MigrationBuilder()
        {
            _schemas = new List<ISchema>();
            _migrationDiscovery = new MigrationDiscovery();
        }
        public MigrationBuilder ADDSchema(ISchema schemas)
        {
            _schemas.Add(schemas);
            return this;
        }
        public MigrationBuilder Build()
        {
            return this;
        }
        public void Run()
        {
            var migration = _migrationDiscovery.DiscoverMigrations();

            foreach (var item in migration)
                item.Up();


            // aplay standard fiels 
            List<Column> columns = migration
                            .SelectMany(m => m.Entitys)
                            .SelectMany(e => e.AddColumns)
                            .Where(c => c.IsValueDefault && c.Entity.EntityName == "yStandardFields")
                            .Distinct()
                            .ToList();

            var chavesIncluidas = new HashSet<string>();

            foreach (var m in migration)
            {
                foreach (var entity in m.Entitys.Where(x => x.EntityName != "yStandardFields" && !x.IsFromView))
                {
                    foreach (var col in columns)
                    {
                        if (col.NotAplicableStandardFieldToEntity.Where(x => x == entity.EntityName).Any())
                            continue;

                        if (entity.AddColumns.Where(x => x.Name == col.Name).Count() > 0)
                            continue;

                        if (entity.EntityName == col.FkEntityName)
                            continue;
                        var chave = col.Name + entity.EntityName;
                        if (!chavesIncluidas.Contains(chave))
                        {
                            entity.AddColumns.Add(col.DeepCopy(entity));
                            chavesIncluidas.Add(chave);
                        }
                    }
                }
            }

            foreach (var m in migration)
                m.Entitys.RemoveAll(x => x.EntityName == "yStandardFields");

            ValidateCompositeKeysAreNotImplemented(migration.SelectMany(m => m.Entitys));

            foreach (var schema in _schemas.OfType<ISchemaDataBase>())
            {
                var (maxID, minID) = GetLastVersion(schema._unitOfWork);

                foreach (var item in migration.Where(x => x.ID < minID).OrderByDescending(x=>x.ID) )
                    AplyQuerys(schema.ApplyMigration(item), schema._unitOfWork, item);
                foreach (var item in migration.Where(x => x.ID > maxID))
                    AplyQuerys(schema.ApplyMigration(item), schema._unitOfWork, item);
            }

            PreparMigrationsToCodeGenerete(migration);

            foreach (var schema in _schemas.OfType<ISchemaCodeGeneration>())
                schema.CodeGenaration(_migrationConcriteBase);
        }
        private void PreparMigrationsToCodeGenerete(IEnumerable<MigrationBase> migrations)
        {
            foreach (var migration in migrations)
            {
                SanitizeMigrationEndEntityToCodeGenerete(migration);
                SanitizeMigrationEndHubAgentsToCodeGenerete(migration);
                SanitizeMigrationExternalConnectorsToCodeGenerete(migration);
            }
        }
        private void SanitizeMigrationEndEntityToCodeGenerete(MigrationBase migration)
        {
            // Cria um dicionário para acesso rápido às entidades já sanitizadas
            var moduleDictionary = sanitizedMedules.ToDictionary(e => e.Key, e => e);
            foreach (var mol in migration.Modules)
            {
                if (!moduleDictionary.TryGetValue(mol.Key, out Module? sanitizedModule))
                {
                    sanitizedMedules.Add(mol);
                    moduleDictionary[mol.Key] = mol;
                    _migrationConcriteBase.AddModule(mol);
                }
                else
                {
                    if (!string.IsNullOrEmpty(mol.Description._value))
                        sanitizedModule.Description = mol.Description;
                    foreach (var entity in mol.Entities)
                    {
                        // Verifica se já existe um entity com o mesmo EntityName
                        if (!sanitizedModule.Entities.Any(e => e.EntityName == entity.EntityName))
                        {
                            sanitizedModule.Entities.Add(entity);
                        }
                    }

                    foreach (var customPage in mol.CustomPages)
                    {
                        var existingCustomPage = sanitizedModule.CustomPages
                            .FirstOrDefault(x => x.Page.Equals(customPage.Page, StringComparison.OrdinalIgnoreCase));

                        if (existingCustomPage == null)
                        {
                            sanitizedModule.CustomPages.Add(customPage);
                        }
                        else
                        {
                            existingCustomPage.Title = customPage.Title;
                            existingCustomPage.Scope = customPage.Scope;
                            existingCustomPage.MenuGroup = customPage.MenuGroup;
                        }
                    }

                    foreach (var menuGroup in mol.MenuGroups)
                    {
                        var existingMenuGroup = sanitizedModule.MenuGroups
                            .FirstOrDefault(x => x.Title.Equals(menuGroup.Title, StringComparison.OrdinalIgnoreCase));

                        if (existingMenuGroup == null)
                        {
                            sanitizedModule.MenuGroups.Add(menuGroup);
                        }
                        else
                        {
                            foreach (var item in menuGroup.Items)
                                existingMenuGroup.AddItem(item);

                            foreach (var prefix in menuGroup.Prefixes)
                                existingMenuGroup.AddPrefix(prefix);

                            existingMenuGroup.IncludeRemaining = existingMenuGroup.IncludeRemaining || menuGroup.IncludeRemaining;
                        }
                    }

                }
            }



            var entityDictionary = sanitizedEntities.ToDictionary(e => e.EntityName, e => e);
            foreach (var entity in migration.Entitys)
            {
                // Verifica se a entidade já existe na lista de sanitizadas
                if (!entityDictionary.TryGetValue(entity.EntityName, out var sanitizedEntity))
                {
                    sanitizedEntity = entity;
                    sanitizedEntities.Add(sanitizedEntity);
                    entityDictionary[entity.EntityName] = sanitizedEntity;
                    _migrationConcriteBase.AddEntity(sanitizedEntity);
                }
                else
                {
                    sanitizedEntity.CopyMetadataFrom(entity);

                    int totalColuns = entity.AddColumns.Count;
                    for (var i = 0; i < totalColuns; i++)
                    {
                        sanitizedEntity.AddColumns.Add(entity.AddColumns[i]);
                        //var index = sanitizedEntity.AddColumns.FindIndex(c => c.Name == entity.AddColumns[i].Name);

                        //if (index >= 0)
                        //sanitizedEntity.AddColumns[index] = entity.AddColumns[i];
                        //else
                        //  sanitizedEntity.AddColumns.Add(entity.AddColumns[i]);
                    }
                }

                for (var i = 0; i < entity.AlterColumns.Count; i++)
                {
                    var index = sanitizedEntity.AddColumns.FindIndex(c => c.Name == entity.AddColumns[i].Name);
                    if (index >= 0)
                        sanitizedEntity.AddColumns[index] = entity.AddColumns[i];
                    //else
                    //    sanitizedEntity.AddColumns.Add(entity.AddColumns[i]);
                }


                foreach (var columnToRemove in entity.DropColumns)
                    sanitizedEntity.AddColumns.RemoveAll(c => c.Name == columnToRemove.Name);
            }

            foreach (var entity in sanitizedEntities)
                foreach (var colun in entity.AddColumns.Where(x => x.IsFK))
                    colun.EntityFK = sanitizedEntities.Where(x => x.EntityName == colun.FkEntityName).FirstOrDefault();
        }
        public static void ValidateCompositeKeysAreNotImplemented(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities.Where(x => !x.IsFromView))
            {
                var keys = entity.AddColumns
                    .Where(x => x.IsKey && !x.IsBackEndField)
                    .Select(x => x.Name)
                    .ToArray();

                if (keys.Length > 1)
                {
                    throw new NotSupportedException(
                        $"Chave composta ainda nao esta implementada no Yeshua. Entidade '{entity.EntityName}' declarou {keys.Length} chaves: {string.Join(", ", keys)}. Use um Id interno simples como chave operacional e mantenha a chave natural/legada como campos de negocio ou metadata de transicao.");
                }
            }
        }
        private void SanitizeMigrationEndHubAgentsToCodeGenerete(MigrationBase migration)
        {
            foreach (var hub in migration.UseCaseGroup)
            {
                _migrationConcriteBase.UseCaseGroup.Add(hub);
            }
        }

        private void SanitizeMigrationExternalConnectorsToCodeGenerete(MigrationBase migration)
        {
            foreach (var connector in migration.ExternalConnectors)
            {
                var target = _migrationConcriteBase.ExternalConnectors.FirstOrDefault(x =>
                    string.Equals(x.Key, connector.Key, StringComparison.OrdinalIgnoreCase));

                if (target == null)
                {
                    _migrationConcriteBase.ExternalConnectors.Add(connector);
                    continue;
                }

                target.Protocol = connector.Protocol;
                target.TokenRequired = target.TokenRequired || connector.TokenRequired;

                foreach (var operation in connector.Operations)
                {
                    if (target.Operations.Any(x =>
                            string.Equals(x.Service, operation.Service, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(x.Operation, operation.Operation, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    target.Operations.Add(operation);
                }
            }
        }
        private void AplyQuerys(List<MigrationQuery> migrationQueries, IUnitOfWork unitOfWork, MigrationBase migration)
        {
            try
            {
                unitOfWork.BeginTran();
                foreach (var q in migrationQueries)
                {
                    Console.Write(q.Query);
                    unitOfWork.ExecuteCommand(q.Query);
                }
                setMigrationVersion(migration.ID, migration.MigrationName, unitOfWork);

                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
        private void setMigrationVersion(int id, string migrationName, IUnitOfWork unitOfWork)
        {
            unitOfWork.ExecuteCommand($"Insert into MigrationVersion(ID,Migration,IssueDate) Values({id},'{migrationName}', GETDATE())");
        }
        private (int MaxID, int MinID) GetLastVersion(IUnitOfWork unitOfWork)
        {
            try
            {
                string sql = "SELECT ISNULL(MAX(ID),0) AS MaxID, ISNULL(MIN(ID),0) AS MinID FROM MigrationVersion";
                return unitOfWork.QuerySingle<(int MaxID, int MinID)>(sql);
            }
            catch (Exception)
            {
                unitOfWork.ExecuteCommand("CREATE TABLE MigrationVersion(ID INT PRIMARY KEY, Migration VARCHAR(20), IssueDate DATETIME);");
                return (0, 0);
            }
        }
    }
}
