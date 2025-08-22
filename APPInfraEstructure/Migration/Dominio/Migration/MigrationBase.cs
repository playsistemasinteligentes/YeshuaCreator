using Dominio.TiposPrimitivos;
using Migration.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Migration
{
    public abstract class MigrationBase
    {
        public List<Entity> Entitys = new List<Entity>();
        public List<Module> Modules = new List<Module>();
        public List<UseCaseGroup> UseCaseGroup = new List<UseCaseGroup>();
        private Entity _entity;
        private Module _module;
        private UseCaseGroup _hub;
        public int ID { get; set; }
        public string MigrationName { get; set; }


        public MigrationBase AlterEntity(string entityName)
        {
            AddToListEntity(entityName, false);
            return this;
        }
        public MigrationBase AddEntity(Entity entity)
        {
            Entitys.Add(entity);
            return this;
        }
        public MigrationBase AddModule(Module module)
        {
            Modules.Add(module);
            return this;
        }

        public Entity AddToListEntity(string EntityName, bool create)
        {
            _entity = Entitys.Where(x => x.EntityName == EntityName).FirstOrDefault();
            if (_entity == null)
            {
                _entity = new Entity(EntityName);
                Entitys.Add(_entity);
                _entity.create = create;
            }
            return _entity;
        }
        public UseCaseGroup AddToListHub(string hubName)
        {
            _hub = UseCaseGroup.Where(x => x.Name._value == hubName).FirstOrDefault();
            if (_hub == null)
            {
                _hub = new UseCaseGroup(hubName);
                UseCaseGroup.Add(_hub);
            }
            return _hub;
        }
        public MigrationBase AddEntity(string EntityName, string EntityDescription)
        {
            AddToListEntity(EntityName, true);
            return this;
        }
        public MigrationBase AddEntity(string EntityName)
        {
            Descricao descricao = new Descricao().Normalize(EntityName);
            AddToListEntity(EntityName, true);
            return this;
        }


        public MigrationBase AddModule(string key, string moduleDescription)
        {
            _module = Modules.Where(x => x.Key == key).FirstOrDefault();
            if (_module == null)
            {
                _module = new Module(key, Descricao.normalise(moduleDescription));
                _module.Inserir = true;
                Modules.Add(_module);
            }
            return this;
        }
        public UseCaseGroup AddUsecaseGroup(string hubName)
        {
            Descricao descricao = new Descricao().Normalize(hubName);
            AddToListHub(hubName);
            return this.UseCaseGroup.Last();
        }
        public Entity AddColumn(string columnName, string descrition)
        {
            _entity.StatusColuns = 1;
            return _entity.AddColumn(columnName, descrition);
        }
        public Entity AddModule(string key)
        {
            Module modulo = Modules.Where(x => x.Key == key).FirstOrDefault();
            if (modulo == null)
            {
                modulo = new Module(key);
                Modules.Add(modulo);
            }
            modulo.Entities.Add(_entity);
            return _entity.AddModule(modulo);
        }

        public Entity AddColumn(string columnName)
        {
            _entity.StatusColuns = 1;
            Descricao descricao = columnName;
            return _entity.AddColumn(columnName, descricao.Normalize(columnName));
        }
        public Entity AlterColumn(string columnName, string descrition)
        {
            _entity.StatusColuns = 2;
            return _entity.AlterColumn(columnName, descrition);
        }
        public Entity DropColumn(string columnName)
        {
            _entity.StatusColuns = 3;
            return _entity.DropColumn(columnName);
        }
        public abstract void Up();

        public void SetID(string name)
        {
            ID = int.Parse(name.Replace("M", "").Replace("S", ""));
            if (!string.IsNullOrEmpty(name) && name[0] == 'S')
                ID = ID * -1;
            MigrationName = name;
        }

        public Entity Cached()
        {
            _entity.CachedTable = true;
            return _entity;
        }
    }
}
