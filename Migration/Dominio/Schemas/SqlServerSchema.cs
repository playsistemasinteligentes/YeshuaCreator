using Dominio.Migration;
using Interfaces.Schemas;
using Shered.DB.Connection;
using System.Data;
using System.Data.Common;
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
                $"  ALTER TABLE {entity.EntityName} ADD {c.Name}  {GetSqlDataType(c.GetSqlType(), c.Length, c.Precision)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();
            var addColumnsString = string.Join("; ", addColumns);

            var alterColumns = entity.AlterColumns.Select(c =>
                $"  ALTER TABLE {entity.EntityName} ALTER COLUMN {c.Name}  {GetSqlDataType(c.GetSqlType(), c.Length, c.Precision)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();
            var alterColumnsString = string.Join("; ", alterColumns);

            return new MigrationQuery($@" {dropColumnsString} {alterColumnsString} {addColumnsString}", null);
        }

        public MigrationQuery CreateTable(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.EntityName))
            {
                throw new InvalidOperationException("EntityName cannot be null or empty.");
            }

            var columnsSql = entity.AddColumns.Select(c =>
                $"{c.Name} {GetSqlDataType(c.GetSqlType(), c.Length, c.Precision)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNullable ? "NULL" : "NOT NULL" : "")}"
            ).ToArray();

            var columnsSqlString = string.Join(", ", columnsSql);
            return new MigrationQuery($@" CREATE TABLE {entity.EntityName} ({columnsSqlString});", null);
        }

        private string GetSqlDataType(string dataType, float length, float precision)
        {
            string retorno = string.Empty;
            switch (dataType.ToUpper())
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
                    return $"VARCHAR({length})"; // Tamanho padrão, ajuste conforme necessário
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
                    return $"DECIMAL({length}, {precision})";
                case "BOOLEAN":
                    return "BIT"; // Tipo para SQL Server; use "BOOLEAN" para PostgreSQL e MySQL
                default:
                    throw new ArgumentException($"Tipo de dado '{dataType}' não suportado.");
            }
        }

        public MigrationQuery AlterColumn(IEnumerable<Column> columns)
        {
            throw new NotImplementedException();
        }
    }
}
