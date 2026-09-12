using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureWriteConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;

        public SourceCodeInfraestructureWriteConcreteRepositoryMigration(Entity entity)
            : base()
        {
            _entity = entity;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Dapper;");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceEntitys};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIQueryWrite};");

            sb.AppendLine($"using RepositoryInterfaces.Services;");
            sb.AppendLine($"using RepositoryInterfaces.Patterns.UnitOfWork;");
            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace Input.Repository.{_entity.EntityName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_entity.EntityName}WriteRepository : I{_entity.EntityName}WriteRepository");
            sb.AppendLine("    {");
            sb.AppendLine("        private readonly IUnitOfWork _UnitOfWork;");
            sb.AppendLine($"       private readonly I{_entity.EntityName}QueryWrite _query; ");

            if (_entity.CachedTable)
            {
                sb.AppendLine($"        private readonly ICacheService<object> _cacheService;");
                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}WriteRepository(IUnitOfWork unitOfWork, I{_entity.EntityName}QueryWrite query,ICacheService<object> cacheService)");
                sb.AppendLine("        {");
                sb.AppendLine("             _UnitOfWork= unitOfWork;");
                sb.AppendLine("             _cacheService = cacheService;");
                sb.AppendLine("             _query = query;");
                sb.AppendLine("        }");
            }
            else
            {
                sb.AppendLine();
                sb.AppendLine($"        public {_entity.EntityName}WriteRepository(IUnitOfWork unitOfWork,I{_entity.EntityName}QueryWrite query)");
                sb.AppendLine("        {");
                sb.AppendLine("             _UnitOfWork= unitOfWork;");
                sb.AppendLine("             _query = query;");
                sb.AppendLine("        }");
            }

            sb.AppendLine();
            sb.AppendLine($"        public void Insert(I{_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            if (_entity.CachedTable)
                sb.AppendLine($"            _cacheService.RemoveByPrefix(\"{_entity.EntityName}\");");

            sb.AppendLine($"            var query = _query.Inserir{_entity.EntityName}Query({_entity.EntityName});");

            var incremento = _entity.AddColumns.Where(x => x.AutoIncremento).FirstOrDefault();
            if (incremento != null)
                sb.AppendLine($"        {_entity.EntityName}.{incremento.Name} =  _UnitOfWork.ExecuteScalar<{incremento.getCsharpType()}>(query.Query, query.Parameters);");
            else
                sb.AppendLine("                _UnitOfWork.Execute(query.Query, query.Parameters);");

            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        public void Update(I{_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            if (_entity.CachedTable)
                sb.AppendLine($"            _cacheService.RemoveByPrefix(\"{_entity.EntityName}\");");
            sb.AppendLine($"            var query = _query.Update{_entity.EntityName}Query({_entity.EntityName});");
            sb.AppendLine("             _UnitOfWork.Execute(query.Query, query.Parameters);");
            sb.AppendLine("        }");
            sb.AppendLine($"        public void Delete(I{_entity.EntityName}Entity {_entity.EntityName})");
            sb.AppendLine("        {");
            if (_entity.CachedTable)
                sb.AppendLine($"            _cacheService.RemoveByPrefix(\"{_entity.EntityName}\");");
            sb.AppendLine($"            var query = _query.Delete{_entity.EntityName}Query({_entity.EntityName});");
            sb.AppendLine("             _UnitOfWork.Execute(query.Query, query.Parameters);");
            sb.AppendLine("        }");


            var keys = _entity.AddColumns.Where(x => x.IsKey && !x.IsBackEndField).ToList();
            var methodParamsKeys = string.Join(", ", keys.Select(k => $"{k.getCsharpType()} {k.Name.ToLower()}"));
            var methodParamsCall = string.Join(", ", keys.Select(k => k.Name.ToLower()));

            foreach (var column in _entity.AddColumns.Where(x => !x.IsKey && !x.IsBackEndField))
            {
                //sb.AppendLine($"        public void Update{column.Name}(I{_entity.EntityName}Entity entity)");

                sb.AppendLine($"        public void Update{column.Name}({methodParamsKeys}, {column.getCsharpType()} value)"); 
                sb.AppendLine("        {");
                if (_entity.CachedTable)
                    sb.AppendLine($"            _cacheService.RemoveByPrefix(\"{_entity.EntityName}\");");
                //sb.AppendLine($"            var query = _query.Update{column.Name}(entity);");
                sb.AppendLine($"            var query = _query.Update{column.Name}({methodParamsCall}, value);");
                sb.AppendLine("             _UnitOfWork.Execute(query.Query, query.Parameters);");
                sb.AppendLine("        }");
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
