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
                var createParameters = string.Join(", ", _entity.AddColumns
                    .Where(x => !x.IsBackEndField && !x.IsValueDefault)
                    .Select(c => c.getCsharpType(true) + " " + c.getParameterConstructor()));
                var createArguments = string.Join(", ", _entity.AddColumns
                    .Where(x => !x.IsBackEndField && !x.IsValueDefault)
                    .Select(c => c.getParameterConstructor()));
                var createForwardArguments = string.IsNullOrWhiteSpace(createArguments)
                    ? "null"
                    : $"null, {createArguments}";
                var createContextParameters = string.IsNullOrWhiteSpace(createParameters)
                    ? "Dominio.Patterns.Domain.DomainOperationContext? context"
                    : $"Dominio.Patterns.Domain.DomainOperationContext? context, {createParameters}";

                sb.Append(@$"

                            namespace {CQRSParam.I.NameSpaceEntitys}
                            {{
                                public class {_entity.EntityName}Factory
                                {{
                                    private readonly {CQRSParam.I.NameSpaceDominioInterface}.ILogger _logger;
                                    private readonly {CQRSParam.I.NameSpaceDominioInterface}.IDomainTrackingPolicy? _trackingPolicy;

                                    public {_entity.EntityName}Factory({CQRSParam.I.NameSpaceDominioInterface}.ILogger logger)
                                        : this(logger, null)
                                    {{
                                    }}

                                    public {_entity.EntityName}Factory(
                                        {CQRSParam.I.NameSpaceDominioInterface}.ILogger logger,
                                        {CQRSParam.I.NameSpaceDominioInterface}.IDomainTrackingPolicy? trackingPolicy)
                                    {{
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    }}");


                sb.AppendLine(@$" public I{_entity.EntityName}Entity Create({createParameters} )
                            {{
                                return Create({createForwardArguments});
                            }}

                            public I{_entity.EntityName}Entity Create(
                                {createContextParameters} )
                            {{
                            var entity = new {_entity.EntityName}Entity({createArguments} );


                            var trackingMask = _trackingPolicy?.GetMask(""{_entity.EntityName}"", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new {_entity.EntityName}Decorator(entity, _logger, context, trackingMask);
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
                sb.AppendLine(GenerateTrackingFieldsConstants());
                sb.AppendLine($"        public partial class {_entity.EntityName}Decorator : I{_entity.EntityName}Entity");
                sb.AppendLine("{");

                sb.Append($@"
                        private readonly I{_entity.EntityName}Entity _inner;
                        private readonly {CQRSParam.I.NameSpaceDominioInterface}.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public {_entity.EntityName}Decorator(I{_entity.EntityName}Entity inner, {CQRSParam.I.NameSpaceDominioInterface}.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {{
                        }}

                        public {_entity.EntityName}Decorator(
                            I{_entity.EntityName}Entity inner,
                            {CQRSParam.I.NameSpaceDominioInterface}.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {{
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }}");
            }



            // atributos
            var entityColumns = _entity.AddColumns.Where(x => !x.IsBackEndField).ToList();
            foreach (var column in entityColumns)
            {
                if (_commandType == CommandType.IEntity)
                    sb.AppendLine($"    {column.getCsharpType(true)} {column.Name} {{ get; set; }}");

                if (_commandType == CommandType.Entity)
                    sb.AppendLine($"    public {column.getCsharpType(true)} {column.Name} {{ get; set; }}");

                if (_commandType == CommandType.EntityDecorator)
                {
                    var trackingIndex = entityColumns.IndexOf(column);
                    var trackingBlock = trackingIndex < 64
                        ? $@"                                                if ((_trackingMask & {_entity.EntityName}TrackingFields.{column.Name}) != 0UL)
                                                    _logger.DomainValueChanged(""{_entity.EntityName}"", ""{column.Name}"", _trackingTraceId, _trackingOperation, _trackingRecordId, value);"
                        : string.Empty;

                    sb.AppendLine($@"
                                    public {column.getCsharpType(true)} {column.Name}
                                    {{
                                        get => _inner.{column.Name};
                                        set
                                        {{
                                            if (_inner.{column.Name} != value)
                                            {{
                                                _inner.{column.Name} = value;
{trackingBlock}
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
                sb.AppendLine(@$" internal {_entity.EntityName}Entity({string.Join(", ", _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsValueDefault).Select(c => c.getCsharpType(true) + " " + c.getParameterConstructor()))} ){{");
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsValueDefault))
                    if (column.getCsharpType() == "DateTime")
                        sb.AppendLine($" {column.Name} = ({column.getParameterConstructor()} < (new DateTime(1800, 1, 1))) ? DateTime.Now : {column.getParameterConstructor()}; ");
                    else
                        sb.AppendLine($" {column.Name} = {column.getParameterConstructor()}; ");

                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && x.IsValueDefault && !IsExecutionContextDefault(x)))
                    sb.AppendLine($" {column.Name} = {BuildDefaultValueExpression(column)}; ");

                sb.AppendLine("}");


                sb.AppendLine("public bool isValidData()");
                sb.AppendLine("{");
                sb.AppendLine("_erroMensagem = new List<string>();");

                foreach (var column in _entity.AddColumns.Where(x => x.IsNotNull && !x.IsBackEndField && !x.IsValueDefault))
                {
                    var validationCondition = column.getCsharpType() switch
                    {
                        "string" => $"string.IsNullOrEmpty({column.Name})",
                        "DateTime" => $"{column.Name} == null || {column.Name} < (new DateTime(1800, 1, 1))",
                        "int" or "Float" or "Decimal" or "long" when column.getCsharpType(true).EndsWith("?") => $"{column.Name} == null",
                        _ => null
                    };

                    if (validationCondition is null)
                        continue;

                    sb.AppendLine($"   if({validationCondition})");
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

        private string GenerateTrackingFieldsConstants()
        {
            var fields = _entity.AddColumns
                .Where(x => !x.IsBackEndField)
                .Take(64)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"        public static class {_entity.EntityName}TrackingFields");
            sb.AppendLine("        {");
            for (var i = 0; i < fields.Count; i++)
            {
                sb.AppendLine($"            public const ulong {fields[i].Name} = 1UL << {i};");
            }
            sb.AppendLine("        }");
            return sb.ToString();
        }

        private static bool IsExecutionContextDefault(Column column)
        {
            return column.ValueDefault?.Contains("_executionContext", StringComparison.Ordinal) == true;
        }

        private static string BuildDefaultValueExpression(Column column)
        {
            var value = column.ValueDefault ?? string.Empty;
            if (value.StartsWith("#", StringComparison.Ordinal))
                return value[1..];

            return column.GetSqlType() switch
            {
                "bool" when value == "1" => "true",
                "bool" when value == "0" => "false",
                "bool" => value.ToLowerInvariant(),
                "varchar" when value == "''" => "\"\"",
                "varchar" when value.Length >= 2 && value.StartsWith("'", StringComparison.Ordinal) && value.EndsWith("'", StringComparison.Ordinal) => $"\"{Escape(value[1..^1])}\"",
                "varchar" => $"\"{Escape(value)}\"",
                _ => value
            };
        }

        private static string Escape(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");

        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();

            sb.Append($@"
                namespace {CQRSParam.I.NameSpaceEntitys}
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
