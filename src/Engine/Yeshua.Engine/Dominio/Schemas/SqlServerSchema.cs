using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Interfaces;
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
            foreach (var e in migration.Entitys.Where(x => x.EntityName != "yStandardFields"))
            {
                if (e.IsFromView)
                    continue;

                if (e.create)
                    querys.Add(CreateTable(e));
                else
                    querys.Add(AlterTable(e));
            }

            foreach (var mod in migration.Modules.Where(x => x.Inserir))
            {
                querys.Add(InsertModules(mod));
            }

            querys.AddRange(BuildForeignKeyQueries(migration.Entitys));

            return querys;
        }

        private MigrationQuery AlterTable(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.EntityName))
            {
                throw new InvalidOperationException("EntityName cannot be null or empty.");
            }

            var dropColumns = entity.DropColumns.Select(c =>
                $" ALTER TABLE {SqlIdentifier(entity.EntityName)} DROP COLUMN {SqlIdentifier(c.Name)};"
            ).ToArray();
            var dropColumnsString = string.Join(" ", dropColumns);

            var addColumns = entity.AddColumns.Select(c =>
                $"  ALTER TABLE {SqlIdentifier(entity.EntityName)} ADD {SqlIdentifier(c.Name)}  {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNotNull ? "NOT NULL" : "NULL" : "")};"
            ).ToArray();
            var addColumnsString = string.Join(" ", addColumns);

            var alterColumns = entity.AlterColumns.Select(c =>
                $"  ALTER TABLE {SqlIdentifier(entity.EntityName)} ALTER COLUMN {SqlIdentifier(c.Name)}  {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNotNull ? "NOT NULL" : "NULL" : "")};"
            ).ToArray();
            var alterColumnsString = string.Join(" ", alterColumns);

            return new MigrationQuery($@" {dropColumnsString} {alterColumnsString} {addColumnsString}", null);
        }

        public MigrationQuery CreateTable(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.EntityName))
            {
                throw new InvalidOperationException("EntityName cannot be null or empty.");
            }
            var columnsSql = entity.AddColumns.Select(c =>
                $"{SqlIdentifier(c.Name)} {GetSqlDataType(c)} {(c.AutoIncremento ? "IDENTITY(1, 1)" : "")} {(c.IsKey ? "PRIMARY KEY " : "")} {(!c.IsKey ? c.IsNotNull ? "NOT NULL" : "NULL" : "")}"
            ).ToArray();
            var columnsSqlString = string.Join(", ", columnsSql);

            return new MigrationQuery($" CREATE TABLE {SqlIdentifier(entity.EntityName)} ({columnsSqlString});", null);
        }

        private IEnumerable<MigrationQuery> BuildForeignKeyQueries(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities.Where(x => x.EntityName != "yStandardFields" && !x.IsFromView))
            {
                foreach (var column in entity.AddColumns.Concat(entity.AlterColumns).Where(x => x.IsFK))
                {
                    yield return BuildForeignKeyQuery(entity, column);
                }
            }
        }

        private MigrationQuery BuildForeignKeyQuery(Entity entity, Column column)
        {
            var constraintName = $"FK_{entity.EntityName}_{column.FkEntityName}_{column.Name}";
            var referenceColumn = string.IsNullOrWhiteSpace(column.ColumnReference) ? column.Name : column.ColumnReference;

            return new MigrationQuery($@"
IF OBJECT_ID(N'{EscapeSqlLiteral(entity.EntityName)}', N'U') IS NOT NULL
   AND OBJECT_ID(N'{EscapeSqlLiteral(column.FkEntityName)}', N'U') IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'{EscapeSqlLiteral(constraintName)}')
BEGIN
    ALTER TABLE {SqlIdentifier(entity.EntityName)}
    ADD CONSTRAINT {SqlIdentifier(constraintName)}
    FOREIGN KEY({SqlIdentifier(column.Name)})
    REFERENCES {SqlIdentifier(column.FkEntityName)}({SqlIdentifier(referenceColumn)});
END;", null);
        }

        public MigrationQuery InsertModules(Module module)
        {
            return new MigrationQuery($" INSERT INTO yModule (Id, Description) values ('{module.Key}','{module.Description}');", null);
        }

        private static string SqlIdentifier(string name)
        {
            return string.Join(".", name.Split('.').Select(part => $"[{part.Replace("]", "]]")}]"));
        }

        private static string EscapeSqlLiteral(string value)
        {
            return value.Replace("'", "''");
        }

        private string GetSqlDataType(Column column)
        {
            string retorno = string.Empty;
            switch (column.GetSqlType().ToUpper())
            {
                case "INT":
                    return "INT";
                case "LONG":
                    return "BIGINT";
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
                case "BOOL":
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
