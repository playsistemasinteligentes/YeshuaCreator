using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Text;
using CommandType = Migration.Dominio.Schemas.CQRS.CommandType;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationCommandCommandsMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly CommandType _commandType;
        private readonly string _nameSpace;
        private readonly string _column;

        public SourceCodeAplicationCommandCommandsMigration(Entity entity, CommandType commandType, string nameSpace, string column)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
            _nameSpace = nameSpace;
            _column = column;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");

            // Adiciona a declaração do namespace
            sb.AppendLine($"namespace {_nameSpace}");
            sb.AppendLine("{");

            // Define a struct que são desde comandos de insert update delete como filtros para pesquisas ou conjuntos de dados para determinar a execução de metodos
            if (_commandType == CommandType.Read)
                sb.AppendLine($"    public struct {_entity.EntityName}{_commandType}{_column}Command : ICommandRead");
            else
                sb.AppendLine($"    public struct {_entity.EntityName}{_commandType}{_column}Command : ICommand");

            sb.AppendLine("    {");

            // Adiciona as propriedades

            if (_commandType == CommandType.ReadFK)
            {
                foreach (var column in _entity.AddColumns.Where(x => x.Name == _column).FirstOrDefault().EntityFK.AddColumns.Where(x => x.DisplayFK))
                {
                    if (string.IsNullOrWhiteSpace(column.getCsharpType()) || string.IsNullOrWhiteSpace(column.Name))
                        throw new InvalidOperationException("Column type or name cannot be null or empty.");

                    if (column.DisplayFK)
                        sb.AppendLine($"        public {column.getCsharpType(true, true)} {column.Name} {{ get; set; }}");
                }
            }
            else
            {
                foreach (var column in _entity.AddColumns)
                {
                    if (string.IsNullOrWhiteSpace(column.getCsharpType()) || string.IsNullOrWhiteSpace(column.Name))
                        throw new InvalidOperationException("Column type or name cannot be null or empty.");
                    if (_commandType == CommandType.Read || _commandType == CommandType.ReadFK)
                        sb.AppendLine($"        public {column.getCsharpType(true, true)} {column.Name} {{ get; set; }}");
                    else
                        sb.AppendLine($"        public {column.getCsharpType(true, false)} {column.Name} {{ get; set; }}");

                }
            }


            // paginação 
            if (_commandType == CommandType.Read)
                sb.AppendLine(" public Pagination Paginacao { get; set; }");

            // Fecha a classe
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }


        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }
    }

}