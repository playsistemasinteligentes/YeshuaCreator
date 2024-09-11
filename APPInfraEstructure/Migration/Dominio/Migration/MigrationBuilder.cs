using Dapper;
using Interfaces.Schemas;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Migration.Dominio.Migration;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Migration
{
    public class MigrationBuilder
    {
        private List<ISchema> _schemas;
        private IEnumerable<MigrationBase> _migrations = new List<MigrationBase>();
        private MigrationDiscovery _migrationDiscovery;
        private List<Entity> sanitizedEntities = new List<Entity>();
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

            foreach (var schema in _schemas.OfType<ISchemaDataBase>())
            {
                int LastVersion = GetLastVersion(schema._unitOfWork);

                foreach (var item in migration.Where(x => x.ID > LastVersion))
                    AplyQuerys(schema.ApplyMigration(item), schema._unitOfWork, item);
            }

            PreparMigrationsToCodeGenerete(migration);
            foreach (var schema in _schemas.OfType<ISchemaCodeGeneration>())
            {
                schema.CodeGenaration(_migrationConcriteBase);
            }
        }
        private void PreparMigrationsToCodeGenerete(IEnumerable<MigrationBase> migrations)
        {
            foreach (var migration in migrations)
                SanitizeMigrationEndEntityToCodeGenerete(migration);
        }
        private void SanitizeMigrationEndEntityToCodeGenerete(MigrationBase migration)
        {
            // Cria um dicionário para acesso rápido às entidades já sanitizadas
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
            }
        }
        private void setMigrationVersion(int id, string migrationName, IUnitOfWork unitOfWork)
        {
            unitOfWork.ExecuteCommand($"Insert into MigrationVersion(ID,Migration,IssueDate) Values({id},'{migrationName}', GETDATE())");
        }
        private int GetLastVersion(IUnitOfWork unitOfWork)
        {
            try
            {
                string sql = "SELECT MAX(ID) AS ID FROM MigrationVersion";
                return unitOfWork.QuerySingle<int>(sql);
            }
            catch (Exception)
            {
                unitOfWork.ExecuteCommand("CREATE TABLE MigrationVersion(ID INT  primary key, Migration varchar(20), IssueDate dateTime);");
                return 0;
            }
        }
    }
}
