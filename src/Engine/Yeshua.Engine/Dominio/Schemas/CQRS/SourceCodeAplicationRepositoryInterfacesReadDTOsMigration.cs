using Migration.Dominio;
using System.Text;
using Migration.Dominio.Schemas.CQRS;
using System.Linq;
using Dominio.Migration;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesReadDTOsMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly string _column;
        private readonly CommandType _commandType;
        private readonly IQueryWithMeta _query;

        public SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(Entity entity, CommandType commandType, string column)
            : base()
        {
            _entity = entity;
            _column = column;
            _commandType = commandType;
        }
        public SourceCodeAplicationRepositoryInterfacesReadDTOsMigration(Entity entity, CommandType commandType, IQueryWithMeta queryMeta)
            : base()
        {
            _entity = entity;
            _query = queryMeta;
            _commandType = commandType;
        }

        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            // Adiciona os usings
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a struct
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceRepositorioOutputs}");
            sb.AppendLine("{");

            switch (_commandType)
            {
                case CommandType.Read:
                    sb.AppendLine($"    public partial record {_entity.EntityName}{_column}DTO");
                    sb.AppendLine("    {");

                    foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                    {
                        var typeName = column.getCsharpType();
                        sb.AppendLine($"    public {typeName} {column.Name.ToLower()} {{ get; set; }}{DefaultInitializer(typeName)}");
                    }

                    break;
                case CommandType.ReadQuery:
                    sb.AppendLine($"    public partial record {_entity.EntityName}{_query.Meta.QueryName}DTO");
                    sb.AppendLine("    {");

                    foreach (var column in _query.Meta.SelectFields)
                    {
                        var typeName = GetFriendlyTypeName(column.FieldType, true);
                        sb.AppendLine($"    public {typeName} {column.Field.ToLower()} {{ get; set; }}{DefaultInitializer(typeName)}//01");
                    }

                    break;
                case CommandType.ReadFK:

                    sb.AppendLine($"    public partial record {_entity.EntityName}{_column}DTO");
                    sb.AppendLine("    {");

                    Column columnFK = _entity.AddColumns.Where(x => x.Name == _column).FirstOrDefault();
                    foreach (var column in columnFK.EntityFK.AddColumns.Where(x => x.DisplayFK))
                    {
                        var typeName = column.getCsharpType();
                        sb.AppendLine($"    public {typeName} {column.Name.ToLower()} {{ get; set; }}{DefaultInitializer(typeName)}");
                    }

                    break;
                default:
                    break;
            }



            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private static string DefaultInitializer(string typeName)
        {
            return typeName == "string" ? " = string.Empty;" : string.Empty;
        }
    }
}
