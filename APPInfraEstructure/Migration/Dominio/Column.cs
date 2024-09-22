using System.Collections.Generic;
using System.Data.Common;

namespace Dominio
{
    public class Column
    {
        public Column(string columnName, string description, Entity entity)
        {
            this.Name = columnName;
            this.Description = description;
            this.Entity = entity;
            this.IsNotNull = false;
        }

        public Entity Entity { get; set; }
        public bool AutoIncremento { get; set; }
        public Dictionary<int, string> Enum { get; set; }
        public string Name { get; private set; }
        private string Description { get; set; }
        private string Type { get; set; }

        public float Length { get; set; }
        public bool IsNullable { get; set; }
        public float Precision { get; set; }
        public bool IsKey { get; set; }
        public bool IsFK { get; private set; }
        public bool IsNotNull { get; private set; }

        public string FkEntityName;

        public string ColumnReference { get; private set; }

        public Entity Int()
        {
            Type = "int";
            return this.Entity;
        }
        public Entity Varchar(int length)
        {
            Type = "varchar";
            Length = length;
            return this.Entity;
        }
        public Entity Float()
        {
            Type = "float";
            return this.Entity;
        }

        public Entity DateTime()
        {
            Type = "datetime";
            return this.Entity;
        }

        public Entity Incremento()
        {
            this.Type ??= "int";
            AutoIncremento = true;
            return this.Entity;
        }
        public Entity Enumerable(int codigo, string descricao)
        {
            this.Type = "int";
            this.Enum ??= new Dictionary<int, string>();
            this.Enum.Add(codigo, descricao);
            return this.Entity;
        }
        public Entity Key()
        {
            this.IsKey = true;
            return this.Entity;
        }


        public Entity Decimal(int length, int precision)
        {
            Type = "decimal";
            this.Length = length;
            this.Precision = precision;
            return this.Entity;
        }

        internal string getCsharpType()
        {
            switch (this.Type)
            {
                case "int":
                    return "int";
                case "varchar":
                    return "string";
                case "datetime":
                    return "DateTime";
                case "float":
                    return "Float";
                case "decimal":
                    return "Decimal";
                default:
                    throw new ArgumentException("Tipo SQL desconhecido: " + this.Type);
            }
        }
        internal string getParameterConstructor()
        {
            return this.Name.ToLower();
        }

        internal string GetSqlType()
        {
            return this.Type;
            switch (this.Type)
            {
                case "int":
                    return "int";
                case "varchar":
                    return "string";
                case "datetime":
                    return "DateTime";
                case "float":
                    return "Float";
                case "decimal":
                    return "Decimal";
                default:
                    throw new ArgumentException("Tipo SQL desconhecido: " + this.Type);
            }
        }

        public Entity FK(string entityName, string columnReference)
        {
            this.IsFK = true;
            this.FkEntityName = entityName;
            this.ColumnReference = columnReference;
            return this.Entity;
        }


        internal Entity NotNull()
        {
            this.IsNotNull = true;
            return this.Entity;
        }
    }
}