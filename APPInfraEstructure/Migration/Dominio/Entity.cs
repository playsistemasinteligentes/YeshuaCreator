using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using System.Runtime.CompilerServices;

namespace Dominio
{
    public class Entity
    {
        public string EntityName { get; private set; }
        public string EntityDescription { get; private set; }
        public List<Column> AddColumns = new List<Column>();
        public List<Column> DropColumns = new List<Column>();
        public List<Column> AlterColumns = new List<Column>();
        public List<string> GPTFunction = new List<string>();
        public List<string> IndexDB = new List<string>();
        public bool create { get; set; }
        public int StatusColuns { get; set; }

        public Entity(string entityName)
        {
            this.EntityName = entityName;
        }

        public Entity(string entityName, string entityDescription) : this(entityName)
        {
            this.EntityDescription = entityDescription;
        }

        private string Name { get; set; }
        private string Description { get; set; }

        public Entity AddColumn(string columnName)
        {
            Descricao description = new Descricao();
            var col = new Column(columnName, Descricao.normalise(columnName), this);
            AddColumns.Add(col);
            return this;
        }

        public Entity AddColumn(string columnName, string description)
        {
            var col = new Column(columnName, description, this);
            AddColumns.Add(col);
            return this;
        }
        public Entity AlterColumn(string columnName, string description)
        {
            var col = new Column(columnName, description, this);
            AlterColumns.Add(col);
            return this;
        }
        public Entity DropColumn(string columnName)
        {
            var col = new Column(columnName, "", this);
            DropColumns.Add(col);
            return this;
        }

        public Entity Varchar(int length)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Varchar(length);
            else
                return this.AlterColumns.Last().Varchar(length);
        }
        public Entity DateTime()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().DateTime();
            else
                return this.AlterColumns.Last().DateTime();
        }

        public Entity Int()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Int();
            else
                return this.AlterColumns.Last().Int();
        }
        public Entity Decimal(int length, int precision)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Decimal(length, precision);
            else
                return this.AlterColumns.Last().Decimal(length, precision);
        }
        public Entity Key()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Key();
            else
                return this.AlterColumns.Last().Key();
        }
        public Entity Incremento()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Incremento();
            else
                return this.AlterColumns.Last().Incremento();
        }
        public Entity Enumerable(int id, string description)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Enumerable(id, description);
            else
                return this.AlterColumns.Last().Enumerable(id, description);
        }

        public Entity FK(string EntityName, string columnReference)
        {
            Entity entity = null;
            if (this.StatusColuns == 1)
                entity = this.AddColumns.Last().FK(EntityName, columnReference);
            else
                entity = this.AlterColumns.Last().FK(EntityName, columnReference);



            return entity;
        }
        public Entity NotNull()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().NotNull();
            else
                return this.AlterColumns.Last().NotNull();
        }
    }
}