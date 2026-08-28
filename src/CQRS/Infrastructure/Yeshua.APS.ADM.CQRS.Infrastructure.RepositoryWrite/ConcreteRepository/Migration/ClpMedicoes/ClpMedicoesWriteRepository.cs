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

namespace Input.Repository.ClpMedicoes
{
    public partial class ClpMedicoesWriteRepository : IClpMedicoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IClpMedicoesQueryWrite _query; 

        public ClpMedicoesWriteRepository(IUnitOfWork unitOfWork,IClpMedicoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IClpMedicoesEntity ClpMedicoes)
        {
            var query = _query.InserirClpMedicoesQuery(ClpMedicoes);
        ClpMedicoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IClpMedicoesEntity ClpMedicoes)
        {
            var query = _query.UpdateClpMedicoesQuery(ClpMedicoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IClpMedicoesEntity ClpMedicoes)
        {
            var query = _query.DeleteClpMedicoesQuery(ClpMedicoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateId2(int id, int value)
        {
            var query = _query.UpdateId2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMaquinaId(int id, string value)
        {
            var query = _query.UpdateMaquinaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataInicio(int id, DateTime value)
        {
            var query = _query.UpdateDataInicio(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataFim(int id, DateTime value)
        {
            var query = _query.UpdateDataFim(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmissao(int id, DateTime value)
        {
            var query = _query.UpdateEmissao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidade(int id, Decimal value)
        {
            var query = _query.UpdateQuantidade(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupo(int id, Decimal value)
        {
            var query = _query.UpdateGrupo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTurnoId(int id, string value)
        {
            var query = _query.UpdateTurnoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTurmaId(int id, string value)
        {
            var query = _query.UpdateTurmaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIdLoteClp(int id, int value)
        {
            var query = _query.UpdateIdLoteClp(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOcorrenciaId(int id, string value)
        {
            var query = _query.UpdateOcorrenciaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFase(int id, int value)
        {
            var query = _query.UpdateFase(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClpOrigem(int id, string value)
        {
            var query = _query.UpdateClpOrigem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLP_LOTE(int id, int value)
        {
            var query = _query.UpdateCLP_LOTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOMPACTA(int id, int value)
        {
            var query = _query.UpdateCOMPACTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration