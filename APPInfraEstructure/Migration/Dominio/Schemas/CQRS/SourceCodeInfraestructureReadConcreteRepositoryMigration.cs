using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly bool _cacheDecorator;

        public SourceCodeInfraestructureReadConcreteRepositoryMigration(Entity entity, bool cacheDecorator)
            : base()
        {
            _entity = entity;
            _cacheDecorator = cacheDecorator;
        }

        protected override StringBuilder GenerateCode()
        {

            var sb = new StringBuilder();
            var itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"bool TakeOff{colun.Name} = false");
            string takeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;
            itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"TakeOff{colun.Name}");
            string VariavaltakeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;



            if (_cacheDecorator)
            {
                sb.AppendLine($"using Repositorio.Outputs;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine($"using RepositoryInterfaces.Services;");

                sb.AppendLine();
                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceReadRepository}");
                sb.AppendLine("{");
                sb.AppendLine($"    public class {_entity.EntityName}ReadRepositoryCacheDecorator : I{_entity.EntityName}ReadRepository");
                sb.AppendLine("    {");
                sb.AppendLine($"    private readonly I{_entity.EntityName}ReadRepository _inner;");
                sb.AppendLine($"    private readonly ICacheService<{_entity.EntityName}DTO> _cacheById;");
                sb.AppendLine($"    private readonly ICacheService<IEnumerable<{_entity.EntityName}DTO>> _cacheAll;");
                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                    sb.AppendLine($"    private readonly ICacheService<IEnumerable<{_entity.EntityName}{column.Name}DTO>> _cacheFK{column.Name};");

                sb.AppendLine();
                // Construtor
                // Define as FKs
                var fkColumns = _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField).ToList();

                // Início do construtor
                sb.AppendLine($"    public {_entity.EntityName}ReadRepositoryCacheDecorator(");
                sb.AppendLine($"        I{_entity.EntityName}ReadRepository inner,");
                sb.AppendLine($"        ICacheService<{_entity.EntityName}DTO> cacheById,");

                // Só coloca vírgula no `cacheAll` se houver FKs
                if (fkColumns.Any())
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}DTO>> cacheAll,");
                else
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}DTO>> cacheAll");

                // Parâmetros das FKs
                for (int i = 0; i < fkColumns.Count; i++)
                {
                    var column = fkColumns[i];
                    var comma = i < fkColumns.Count - 1 ? "," : "";
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}{column.Name}DTO>> cacheFK{column.Name}{comma}");
                }
                sb.Append("    )");


                sb.AppendLine("    {");
                sb.AppendLine("        _inner = inner;");
                sb.AppendLine("        _cacheById = cacheById;");
                sb.AppendLine("        _cacheAll = cacheAll;");

                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                    sb.AppendLine($"    _cacheFK{column.Name}=cacheFK{column.Name};");

                sb.AppendLine("    }");
                sb.AppendLine();



                // get{EntityName}
                sb.AppendLine($"    public DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}(ICommandRead command {takeOff})");
                sb.AppendLine("    {");
                sb.AppendLine("        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros");
                sb.AppendLine($"        var key = $\"{_entity.EntityName}:All:Page:{{command.Paginacao.Page}}:PageZize:{{command.Paginacao.PageSize}}\";");

                sb.AppendLine("        if (isFullQuery)");
                sb.AppendLine("        {");
                sb.AppendLine($"            var cached = _cacheAll.Get(key {VariavaltakeOff});");
                sb.AppendLine("            if (cached != null)");
                sb.AppendLine($"                return new DataPagination<{_entity.EntityName}DTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);");

                sb.AppendLine();
                sb.AppendLine($"            var data = _inner.get{_entity.EntityName}(command {VariavaltakeOff});");
                sb.AppendLine($"            _cacheAll.Set(key, data.Items, \"{_entity.EntityName}\");");
                sb.AppendLine("            return data;");
                sb.AppendLine("        }");
                sb.AppendLine($"        return _inner.get{_entity.EntityName}(command);");
                sb.AppendLine("    }");


                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {


                    sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand c)");
                    sb.AppendLine($"                return get" + _entity.EntityName + CommandType.ReadFK + column.Name + $"(c {VariavaltakeOff});");
                    sb.AppendLine("            throw new NotImplementedException();");
                    sb.AppendLine("        }");

                    sb.AppendLine($"        private IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}({CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand command {takeOff})");
                    sb.AppendLine("        {");

                    sb.AppendLine($"            string key = $\"{_entity.EntityName}:FK:{column.Name}:{{command.searchFK}}\";");

                    sb.AppendLine($"            var cached = _cacheFK{column.Name}.Get(key {takeOff});");
                    sb.AppendLine("            if (cached != null) return cached;");
                    sb.AppendLine($"            var result = _inner.get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(command {VariavaltakeOff});");
                    sb.AppendLine($"            if (result != null) _cacheFK{column.Name}.Set(key, result,\"{_entity.EntityName}\");");
                    sb.AppendLine("            return result;");
                    sb.AppendLine("        }");


                }


                // GetById
                //sb.AppendLine($"    public {_entity.EntityName}DTO GetById(int id)");
                //sb.AppendLine("    {");
                //sb.AppendLine($"        var key = $\"{_entity.EntityName}:Id:{{id}}\";");
                //sb.AppendLine("        var cached = _cacheById.Get(key);");
                //sb.AppendLine("        if (cached != null) return cached;");
                //sb.AppendLine("        var result = _inner.GetById(id);");
                //sb.AppendLine("        if (result != null) _cacheById.Set(key, result);");
                //sb.AppendLine("        return result;");
                //sb.AppendLine("    }");


                //Exist
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    sb.AppendLine($"        public bool ExistsBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.ExistsBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }

                //FirstBy
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    sb.AppendLine($"        public {_entity.EntityName}DTO FirstBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.FirstBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }

                //GetAllBy
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAllBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.GetAllBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }


                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            sb.AppendLine("using Dapper;");
            sb.AppendLine($"using Repositorio.Outputs;");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceReadRepository};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIQueryRead};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIterfaceAplicationServices};");


            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceReadRepository}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {_entity.EntityName}ReadRepository : I{_entity.EntityName}ReadRepository");
            sb.AppendLine("    {");
            sb.AppendLine("        protected readonly IDbConnection _connection;");
            sb.AppendLine("        protected readonly ICurrentUser _correntUser;");
            sb.AppendLine($"       protected readonly I{_entity.EntityName}QueryRead _query;");
            sb.AppendLine();
            sb.AppendLine($"        public {_entity.EntityName}ReadRepository(SqlFactory factory, ICurrentUser correntUser,I{_entity.EntityName}QueryRead query)");
            sb.AppendLine("        {");
            sb.AppendLine("            _connection = factory.SqlConnection();");
            sb.AppendLine("            _correntUser = correntUser;");
            sb.AppendLine("            _query = query;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}(ICommandRead command {takeOff})");
            sb.AppendLine("         {");
            sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command c)");
            sb.AppendLine($"                return get{_entity.EntityName}(c {VariavaltakeOff});");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");

            sb.AppendLine($"        private DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command command {takeOff})");
            sb.AppendLine("        {");
            sb.AppendLine($"            var query = _query.{_entity.EntityName}Query(command {VariavaltakeOff});");
            sb.AppendLine();
            sb.AppendLine($"                var itens = _connection.Query<{_entity.EntityName}DTO>(query.Query,query.Parameters);");
            //var itens = _connection.Query<GrupoServicoDTO>(query.Query, query.Parameters);
            sb.AppendLine($"                return new DataPagination<{_entity.EntityName}DTO>(");
            sb.AppendLine($"                                itens,");
            sb.AppendLine($"                command.Paginacao?.Page ?? 0,");
            sb.AppendLine($"                command.Paginacao?.PageSize ?? 0,");
            sb.AppendLine($"                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);");
            sb.AppendLine("        }");
            sb.AppendLine();

            foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
            {

                sb.AppendLine($"        private IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}({CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand command {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            List<{_entity.EntityName}{column.Name}DTO> lista;");
                sb.AppendLine($"            var query = _query.{_entity.EntityName}{column.Name}Query(command {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                lista = _connection.Query<{_entity.EntityName}{column.Name}DTO>(query.Query,query.Parameters) as List<{_entity.EntityName}{column.Name}DTO>;");
                sb.AppendLine("            return lista;");
                sb.AppendLine("        }");
                sb.AppendLine();

                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command {takeOff})");
                sb.AppendLine("        {");

                sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandPatterns}.SearchFKCommand c)");
                sb.AppendLine("            {");
                sb.AppendLine($"                return get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(c {VariavaltakeOff});");
                sb.AppendLine("            }");
                sb.AppendLine("            throw new NotImplementedException();");

                sb.AppendLine("        }");
                sb.AppendLine();


            }

            //Exist
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
            {
                sb.AppendLine($"        public bool ExistsBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.ExistsBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine("                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);");
                sb.AppendLine("                return result == 1;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            //FirstBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
            {
                sb.AppendLine($"        public {_entity.EntityName}DTO FirstBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.FirstBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                var result = _connection.QueryFirstOrDefault<{_entity.EntityName}DTO>(query.Query, query.Parameters);");
                sb.AppendLine("                return result;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            //GetAllBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
            {
                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAllBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.FirstBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                var result = _connection.Query<{_entity.EntityName}DTO>(query.Query,query.Parameters) as List<{_entity.EntityName}DTO>;");
                sb.AppendLine("                return result;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            return sb;

            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
            {
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");
            return sb;
        }
    }
}