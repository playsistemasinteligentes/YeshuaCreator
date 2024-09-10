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
        }

        public Entity Entity { get; set; }
        public bool AutoIncremento { get; set; }
        public string Name { get; private set; }
        private string Description { get; set; }
        private string Type { get; set; }

        public float Length { get; set; }
        public bool IsNullable { get; set; }
        public float Precision { get; set; }
        public bool IsKey { get; set; }

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
            AutoIncremento = true;
            return this.Entity;
        }
        public Entity Key()
        {
            this.IsKey = true;
            return this.Entity;
        }

        internal string GetCsharpType()
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
                default:
                    throw new ArgumentException("Tipo SQL desconhecido: " + this.Type);
            }
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
                default:
                    throw new ArgumentException("Tipo SQL desconhecido: " + this.Type);
            }

        }
    }
}