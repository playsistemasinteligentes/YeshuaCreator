using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Schemas.CQRS.Abstraction
{
    public class Command
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string Inherits { get; set; } // ex: ": ICommandRead"
        public List<CommandField> Fields { get; set; } = new List<CommandField>();
    }

    public class CommandField
    {
        public string Scope { get; set; } = "public"; // public, private, protected
        public Type TypeField { get; set; } // string, int?, DateTime etc
        public string Name { get; set; }

        private string GetCSharpType(FieldTypes Type)
        {
            return Type switch
            {
                FieldTypes.Integer => "int",
                FieldTypes.NullableInteger => "int?",
                FieldTypes.String => "string",
                FieldTypes.DateTime => "DateTime",
                FieldTypes.NullableDateTime => "DateTime?",
                FieldTypes.Decimal => "decimal",
                FieldTypes.NullableDecimal => "decimal?",
                FieldTypes.Boolean => "bool",
                FieldTypes.NullableBoolean => "bool?",
                FieldTypes.Object => "object",
                FieldTypes.Custom => null, // motor deve preencher com algo manualmente
                _ => "object"
            };

            return "";
        }
    }

    public enum FieldTypes
    {
        Integer,
        NullableInteger,
        String,
        DateTime,
        NullableDateTime,
        Decimal,
        NullableDecimal,
        Boolean,
        NullableBoolean,
        Object,
        Custom
    }

    public enum CodeScope
    {
        Public,
        Private,
        Protected,
        Internal
    }

    public enum CodeTypeKind
    {
        Class,
        Struct,
        Interface,
        Record
    }

}
