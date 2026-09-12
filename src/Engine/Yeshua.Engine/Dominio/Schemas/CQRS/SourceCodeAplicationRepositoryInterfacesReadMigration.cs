using Dominio.Migration;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationRepositoryInterfacesReadMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeAplicationRepositoryInterfacesReadMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();
            var itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"bool TakeOff{colun.Name} = false");
            string takeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;


            // Adiciona os usings
            sb.AppendLine($"using Repositorio.Outputs;");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");

            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using System.Linq;");
            sb.AppendLine($"using System.Text;");
            sb.AppendLine($"using System.Threading.Tasks;");
            sb.AppendLine();

            // Adiciona o namespace e a interface
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceIRepositoryRead}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial interface I{_entity.EntityName}ReadRepository");
            sb.AppendLine("    {");

            //--trocar ICommand comando por um DTO apenas pra não gerar dependencia do Repositorio para o command

            sb.AppendLine($"        public DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}(ICommandRead command {takeOff});");

            foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command {takeOff});");


            //Exist
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                sb.AppendLine($"        public bool ExistsBy{column.Name}({column.getCsharpType()} value {takeOff});");

            //FirstBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                sb.AppendLine($"        public {_entity.EntityName}DTO FirstBy{column.Name}({column.getCsharpType()} value {takeOff});");

            //GetAllBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAllBy{column.Name}({column.getCsharpType()} value {takeOff});");




            foreach (var query in _entity.Queries.OfType<IQueryWithMeta>())
            {
                // WhereContexts
                foreach (var ctxName in query.Meta.WhereContextParameters.Keys)
                {
                    string methodName = $"{_entity.EntityName}{ctxName}";
                    sb.AppendLine($"        public DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO> Get{methodName}(ICommandRead command {takeOff});");
                }

                // Wheres
                foreach (var whName in query.Meta.WhereParameters.Keys)
                {
                    string methodName = $"{_entity.EntityName}{whName}";
                    sb.AppendLine($"        public DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO> Get{methodName}(ICommandRead command {takeOff});");
                }
            }




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
