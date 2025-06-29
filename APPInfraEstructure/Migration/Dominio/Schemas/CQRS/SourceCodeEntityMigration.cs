using System.ComponentModel.Design;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeEntityMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly CommandType _commandType;
        public SourceCodeEntityMigration(Entity entity, CommandType commandType)
            : base()
        {
            _entity = entity;
            _commandType = commandType;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            if (_commandType == CommandType.Factory)
            {
                sb.Append(@$"

                            namespace {CQRSParam.I.NameSpaceEntitys}
                            {{
                                public class {_entity.EntityName}Factory
                                {{
                                    private readonly {CQRSParam.I.NameSpaceDominioInterface}.ILogger _logger;

                                    public {_entity.EntityName}Factory({CQRSParam.I.NameSpaceDominioInterface}.ILogger logger)
                                    {{
                                        _logger = logger;
                                    }}");


                sb.AppendLine(@$" public I{_entity.EntityName}Entity Create({string.Join(", ", _entity.AddColumns.Select(c => c.getCsharpType(true) + " " + c.getParameterConstructor()))} )
                            {{
                            var entity = new {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Select(c => c.getParameterConstructor()))} );


                            var decoratedEntity = new {_entity.EntityName}Decorator(entity, _logger);
                            return decoratedEntity;
                                    }}
                                }}
                            }}");

                return sb;
            }

            sb.Append($@"
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace {CQRSParam.I.NameSpaceEntitys}
                {{
            ");

            if (_commandType == CommandType.IEntity)
            {
                sb.AppendLine($"        public interface I{_entity.EntityName}Entity");
                sb.AppendLine("{");
            }
            if (_commandType == CommandType.Entity)
            {
                sb.AppendLine($"        public partial class {_entity.EntityName}Entity : I{_entity.EntityName}Entity");
                sb.AppendLine("{");
            }
            if (_commandType == CommandType.EntityDecorator)
            {
                sb.AppendLine($"        public partial class {_entity.EntityName}Decorator : I{_entity.EntityName}Entity");
                sb.AppendLine("{");

                sb.Append($@"
                        private readonly I{_entity.EntityName}Entity _inner;
                        private readonly {CQRSParam.I.NameSpaceDominioInterface}.ILogger _logger;
                        public {_entity.EntityName}Decorator(I{_entity.EntityName}Entity inner, {CQRSParam.I.NameSpaceDominioInterface}.ILogger logger)
                        {{
                            _inner = inner;
                            _logger = logger;
                        }}");
            }



            // atributos
            foreach (var column in _entity.AddColumns)
            {
                if (_commandType == CommandType.IEntity)
                    sb.AppendLine($"    {column.getCsharpType(true)} {column.Name} {{ get; set; }}");

                if (_commandType == CommandType.Entity)
                    sb.AppendLine($"    public {column.getCsharpType(true)} {column.Name} {{ get; set; }}");

                if (_commandType == CommandType.EntityDecorator)
                {
                    sb.AppendLine($@"
                                    public {column.getCsharpType(true)} {column.Name}
                                    {{
                                        get => _inner.{column.Name};
                                        set
                                        {{
                                            if (_inner.{column.Name} != value)
                                            {{
                                                _logger.Info($""Propriedade {column.Name}: antes={{_inner.{column.Name}}}, depois={{value}}"");
                                                _inner.{column.Name} = value;
                                            }}
                                        }}
                                    }}");

                }
            }




            if (_commandType == CommandType.IEntity)
            {
                sb.AppendLine(@"    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                ");
            }

            if (_commandType == CommandType.Entity)
            {
                sb.AppendLine("    private List<string> _erroMensagem = null;");
                // construtor 
                sb.AppendLine(@$" internal {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Select(c => c.getCsharpType(true) + " " + c.getParameterConstructor()))} ){{");
                foreach (var column in _entity.AddColumns)
                    if (column.getCsharpType() == "DateTime")
                        sb.AppendLine($" {column.Name} = ({column.getParameterConstructor()} < (new DateTime(1800, 1, 1))) ? DateTime.Now : {column.getParameterConstructor()}; ");
                    else
                        sb.AppendLine($" {column.Name} = {column.getParameterConstructor()}; ");
                sb.AppendLine("}");


                sb.AppendLine("public bool isValidData()");
                sb.AppendLine("{");
                sb.AppendLine("_erroMensagem = new List<string>();");

                foreach (var column in _entity.AddColumns.Where(x => x.IsNotNull))
                {
                    if (column.getCsharpType() == "string")
                        sb.AppendLine($"   if(string.IsNullOrEmpty({column.Name}))");
                    if (column.getCsharpType() == "DateTime")
                        sb.AppendLine($"   if ({column.Name} == null || {column.Name} < (new DateTime(1800, 1, 1)))");

                    if (column.getCsharpType() == "int" || column.getCsharpType() == "Float" || column.getCsharpType() == "Decimal")
                        sb.AppendLine($"   if ({column.Name} == null)");

                    sb.AppendLine($"   this._erroMensagem.Add(\"{column.Description} deve ser informado.\");");
                }

                sb.AppendLine("return _erroMensagem.Count() <= 0;");
                sb.AppendLine("}");

                sb.Append($@"
                        public bool isValid{CommandType.Insert}() => isValidData();
                        public bool isValid{CommandType.Update}() => isValidData();
                        public bool isValid{CommandType.Delete}() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                ");


            }
            if (_commandType == CommandType.EntityDecorator)
            {
                sb.Append($@"
                        public bool isValid{CommandType.Insert}() => _inner.isValidInsert();
                        public bool isValid{CommandType.Update}() => _inner.isValidUpdate();
                        public bool isValid{CommandType.Delete}() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                ");
            }
            sb.Append($@"
                }}
            }}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            sb.Append($@"
                namespace Dominio.Entitys.{_entity.EntityName}
                {{
            ");

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}Entity");
            sb.AppendLine("{");

            // Fecha a classe
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
    }
}