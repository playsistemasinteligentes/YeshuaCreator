using Dominio.Migration;
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using static Dapper.SqlMapper;

namespace Dominio
{
    public class Entity
    {
        public string EntityName { get; private set; }
        public string EntityDescription { get; private set; }
        public List<Column> AddColumns = new List<Column>();
        public List<Index> AddIndexs = new List<Index>();
        public List<Column> DropColumns = new List<Column>();
        public List<Column> AlterColumns = new List<Column>();
        public List<string> GPTFunction = new List<string>();
        public List<string> IndexDB = new List<string>();
        public List<Module> AddModules = new List<Module>();
        public List<IMigrationQueryDefinition> Queries { get; } = new List<IMigrationQueryDefinition>();

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
        public bool CachedTable { get; set; } = false;

        public Entity AddColumn(string columnName)
        {
            var col = new Column(columnName, Descricao.normalise(columnName), this);
            AddColumns.Add(col);
            return this;
        }
        public Entity AddModule(Module module)
        {
            AddModules.Add(module);
            return this;
        }

        public Entity Cached()
        {
            this.CachedTable = true;
            return this;
        }

        public Entity AddColumn(string columnName, string description)
        {
            this.StatusColuns = 1;
            var col = new Column(columnName, description, this);
            AddColumns.Add(col);
            return this;
        }
        public Entity AddIndex()
        {
            var index = new Index(this);
            AddIndexs.Add(index);
            return this;
        }
        public void AddIndexColumn(string Name)
        {
            var column = new Column(Name);
            this.AddIndexs.Last().IndexColumns.Add(column);
        }

        public Entity AddColumn(string columnName, string description, string helper)
        {
            var col = new Column(columnName, description, this, helper);
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

        public Entity Varchar(int length, bool isMemo = false)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Varchar(length, isMemo);
            else
                return this.AlterColumns.Last().Varchar(length, isMemo);
        }
        public Entity WhereClauses(string WhereClauses)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().WhereClauses(WhereClauses);
            else
                return this.AlterColumns.Last().WhereClauses(WhereClauses);
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
        public Entity Group(string value)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().SetGroup(value);
            else
                return this.AlterColumns.Last().SetGroup(value);
        }
        public Entity Boolean()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Boolean();
            else
                return this.AlterColumns.Last().Boolean();
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
        public Entity DefaultValue(string value)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().DefaultValue(value);
            else
                return this.AlterColumns.Last().DefaultValue(value);
        }

        public Entity EditFront(bool value)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().EditFront(value);
            else
                return this.AlterColumns.Last().EditFront(value);
        }

        public Entity VisivelFront(bool value)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().VisivelFront(value);
            else
                return this.AlterColumns.Last().VisivelFront(value);
        }

        public Entity CanTakeOffWhere()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().CanTakeOffWhere();
            else
                return this.AlterColumns.Last().CanTakeOffWhere();
        }

        public Entity NeedBeWhere()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().NeedBeWhere();
            else
                return this.AlterColumns.Last().NeedBeWhere();
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

        public string getDescription()
        {
            if (string.IsNullOrEmpty(this.EntityDescription))
                return this.EntityName;
            else
                return this.EntityDescription;
        }


        public Entity Password()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().Password();
            else
                return this.AlterColumns.Last().Password();
        }
        public Entity UserEncryptedField()
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().UserEncryptedField();
            else
                return this.AlterColumns.Last().UserEncryptedField();
        }

        internal Entity NotEntity(string entidade)
        {
            if (this.StatusColuns == 1)
                return this.AddColumns.Last().NotAplicableEntityToStandardField(entidade);
            else
                return this.AlterColumns.Last().NotAplicableEntityToStandardField(entidade);

            return this;
        }


    }
}