// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Configuracoes
{
    public partial class ConfiguracoesWriteRepository : IConfiguracoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IConfiguracoesQueryWrite _query; 

        public ConfiguracoesWriteRepository(IUnitOfWork unitOfWork,IConfiguracoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IConfiguracoesEntity Configuracoes)
        {
            var query = _query.InserirConfiguracoesQuery(Configuracoes);
        Configuracoes.CON_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IConfiguracoesEntity Configuracoes)
        {
            var query = _query.UpdateConfiguracoesQuery(Configuracoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IConfiguracoesEntity Configuracoes)
        {
            var query = _query.DeleteConfiguracoesQuery(Configuracoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int con_id, int value)
        {
            var query = _query.UpdateTenantID(con_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int con_id, bool value)
        {
            var query = _query.UpdateDeleted(con_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int con_id, DateTime value)
        {
            var query = _query.UpdateChanged(con_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int con_id, int value)
        {
            var query = _query.UpdateUserId(con_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration