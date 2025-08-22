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
                foreach (var entity in m.Entitys.Where(x => x.EntityName != "yStandardFields"))
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

            foreach (var schema in _schemas.OfType<ISchemaDataBase>())
            {
                var (maxID, minID) = GetLastVersion(schema._unitOfWork);

                foreach (var item in migration.Where(x => x.ID < minID))
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
        private void SanitizeMigrationEndHubAgentsToCodeGenerete(MigrationBase migration)
        {
            foreach (var hub in migration.UseCaseGroup)
            {
                _migrationConcriteBase.UseCaseGroup.Add(hub);
            }
        }
        private void AplyQuerys(List<MigrationQuery> migrationQueries, IUnitOfWork unitOfWork, MigrationBase migration)
        {
            try
            {
                unitOfWork.BeginTran();
                foreach (var q in migrationQueries)
                {
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
