using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dominio.Migration
{
    public abstract class MigrationBase
    {
        public List<Entity> Entitys = new List<Entity>();
        private Entity _entity;
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
        public Entity AddColumn(string columnName, string descrition)
        {
            _entity.StatusColuns = 1;
            return _entity.AddColumn(columnName, descrition);
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

        internal void SetID(string name)
        {
            ID = int.Parse(name.Replace("M", ""));
            MigrationName = name;
        }
    }
}
