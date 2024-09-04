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
        public string Type { get; set; }
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
            Type = "Varchar";
            Length = length;
            return this.Entity;
        }
        public Entity Float()
        {
            Type = "Float";
            return this.Entity;
        }

        public Entity DateTime()
        {
            Type = "DateTime";
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
    }
}