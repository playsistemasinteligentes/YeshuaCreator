using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Interfaces.Schemas;
using Microsoft.IdentityModel.Tokens;
using Shered.DB.Connection;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;
using static Dapper.SqlMapper;

namespace Dominio.Schemas
{
    public class SqlServerSchema : ISchemaDataBase
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public SqlServerSchema(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<MigrationQuery> ApplyMigration(Dominio.Migration.MigrationBase migration)
        {
            List<MigrationQuery> querys = new List<MigrationQuery>();
            foreach (var e in migration.Entitys)
            {
                if (e.create)
                    querys.Add(CreateTable(e));
                else
                    querys.Add(AlterTable(e));
            }
            return querys;
        }

        private MigrationQuery AlterTable(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.EntityName))
            {
                throw new InvalidOperationException("EntityName cannot be null or empty.");
            }

            var dropColumns = entity.DropColumns.Select(c =>
                $" ALTER TABLE {entity.EntityName} DROP COLUMN {c.Name}; "
            ).ToArray();
            var dropColumnsString = string.Join("; ", dropColumns);

            var addColumns = entity.AddColumns.Select(c =>
                $"  ALTER TABLE {entity.EntityName} ADD {c.Name}  {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();
            var addColumnsString = string.Join("; ", addColumns);

            var alterColumns = entity.AlterColumns.Select(c =>
                $"  ALTER TABLE {entity.EntityName} ALTER COLUMN {c.Name}  {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();
            var alterColumnsString = string.Join("; ", alterColumns);

            var addForingKey = entity.AddColumns.Where(x => x.IsFK).Select(c =>
                $"  ALTER TABLE {entity.EntityName} ADD CONSTRAINT FK_{c.FkEntityName} FOREIGN KEY({c.Name}) REFERENCES {c.FkEntityName}({c.Name}); "
            ).ToArray();
            var addForingKeyString = string.Join("; ", addForingKey);

            var alterForingKey = entity.AlterColumns.Where(x => x.IsFK).Select(c =>
            $" IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_{c.FkEntityName}') BEGIN  " +
            $"ALTER TABLE {entity.EntityName} ADD CONSTRAINT FK_{c.FkEntityName} FOREIGN KEY({c.Name}) REFERENCES {c.FkEntityName}({c.Name}); " +
            $"END ").ToArray();
            var alterForingKeyString = string.Join("; ", alterForingKey);

            return new MigrationQuery($@" {dropColumnsString} {alterColumnsString} {addColumnsString} {addForingKeyString}", null);
        }

        public MigrationQuery CreateTable(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.EntityName))
            {
                throw new InvalidOperationException("EntityName cannot be null or empty.");
            }
            var columnsSql = entity.AddColumns.Select(c =>
                $"{c.Name} {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();
            var columnsSqlString = string.Join(", ", columnsSql);

            var columsForingKey = entity.AddColumns.Where(x => x.IsFK).Select(c =>
                $"  CONSTRAINT FK_{c.Entity.EntityName}_{c.FkEntityName} FOREIGN KEY({c.Name}) REFERENCES {c.FkEntityName}({c.ColumnReference}) "
            ).ToArray();
            var columsForingKeyString = string.Join(", ", columsForingKey);
            columsForingKeyString = string.IsNullOrEmpty(columsForingKeyString) ? "" : ($",{columsForingKeyString}");
            return new MigrationQuery($" CREATE TABLE {entity.EntityName} ({columnsSqlString} {columsForingKeyString});", null);
        }

        private string GetSqlDataType(Column column)
        {
            string retorno = string.Empty;
            switch (column.GetSqlType().ToUpper())
            {
                case "INT":
                    return "INT";
                case "TINYINT":
                    return "TINYINT";
                case "SMALLINT":
                    return "SMALLINT";
                case "BIGINT":
                    return "BIGINT";
                case "VARCHAR":
                    return $"VARCHAR({column.Length})"; // Tamanho padrão, ajuste conforme necessário
                case "TEXT":
                    return "TEXT";
                case "DATE":
                    return "DATE";
                case "DATETIME":
                    return "DATETIME";
                case "FLOAT":
                    return "FLOAT";
                case "DOUBLE":
                    return "DOUBLE";
                case "REAL":
                    return "REAL";
                case "DECIMAL":
                    return $"DECIMAL({column.Length}, {column.Precision})";
                case "BOOLEAN":
                    return "BIT"; // Tipo para SQL Server; use "BOOLEAN" para PostgreSQL e MySQL
                default:
                    throw new ArgumentException($"Tipo de dado '{column.GetSqlType()}' não suportado.");
            }
        }

        public MigrationQuery AlterColumn(IEnumerable<Column> columns)
        {
            throw new NotImplementedException();
        }
    }
}
