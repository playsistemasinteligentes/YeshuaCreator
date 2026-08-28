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

namespace Input.Repository.Tabela
{
    public partial class TabelaWriteRepository : ITabelaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITabelaQueryWrite _query; 

        public TabelaWriteRepository(IUnitOfWork unitOfWork,ITabelaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITabelaEntity Tabela)
        {
            var query = _query.InserirTabelaQuery(Tabela);
        Tabela.ID_TABELA =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITabelaEntity Tabela)
        {
            var query = _query.UpdateTabelaQuery(Tabela);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITabelaEntity Tabela)
        {
            var query = _query.DeleteTabelaQuery(Tabela);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCODIGO(int id_tabela, string value)
        {
            var query = _query.UpdateCODIGO(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNOME(int id_tabela, string value)
        {
            var query = _query.UpdateNOME(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id_tabela, int value)
        {
            var query = _query.UpdateTenantID(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id_tabela, bool value)
        {
            var query = _query.UpdateDeleted(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id_tabela, DateTime value)
        {
            var query = _query.UpdateChanged(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id_tabela, int value)
        {
            var query = _query.UpdateUserId(id_tabela, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration