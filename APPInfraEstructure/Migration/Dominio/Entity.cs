


using Dominio.TiposPrimitivos;

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

        internal Entity AddColumn(string columnName)
        {
            Descricao description = new Descricao();
            var col = new Column(columnName, Descricao.normalise(columnName), this);
            AddColumns.Add(col);
            return this;
        }

        internal Entity AddColumn(string columnName, string description)
        {
            var col = new Column(columnName, description, this);
            AddColumns.Add(col);
            return this;
        }
        internal Entity AlterColumn(string columnName, string description)
        {
            var col = new Column(columnName, description, this);
            AlterColumns.Add(col);
            return this;
        }
        internal Entity DropColumn(string columnName)
        {
            var col = new Column(columnName, "", this);
            DropColumns.Add(col);
            return this;
        }

        internal Entity Varchar(int length)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Varchar(length);
            else
                return this.AlterColumns.Last().Varchar(length);
        }
        internal Entity DateTime()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().DateTime();
            else
                return this.AlterColumns.Last().DateTime();
        }

        internal Entity Int()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Int();
            else
                return this.AlterColumns.Last().Int();
        }
        internal Entity Key()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Key();
            else
                return this.AlterColumns.Last().Key();
        }
        internal Entity Incremento()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Incremento();
            else
                return this.AlterColumns.Last().Incremento();
        }

    }
}