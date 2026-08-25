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

namespace Input.Repository.Roteiro
{
    public partial class RoteiroWriteRepository : IRoteiroWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRoteiroQueryWrite _query; 

        public RoteiroWriteRepository(IUnitOfWork unitOfWork,IRoteiroQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRoteiroEntity Roteiro)
        {
            var query = _query.InserirRoteiroQuery(Roteiro);
        Roteiro.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRoteiroEntity Roteiro)
        {
            var query = _query.UpdateRoteiroQuery(Roteiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRoteiroEntity Roteiro)
        {
            var query = _query.DeleteRoteiroQuery(Roteiro);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMaquinaId(int id, string value)
        {
            var query = _query.UpdateMaquinaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoId(int id, string value)
        {
            var query = _query.UpdateProdutoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSequenciaTransformacao(int id, int value)
        {
            var query = _query.UpdateSequenciaTransformacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupoMaquinaId(int id, string value)
        {
            var query = _query.UpdateGrupoMaquinaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePecasPorPulso(int id, Decimal value)
        {
            var query = _query.UpdatePecasPorPulso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePrioridadeInformada(int id, Decimal value)
        {
            var query = _query.UpdatePrioridadeInformada(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAcao(int id, string value)
        {
            var query = _query.UpdateAcao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePerformance(int id, Decimal value)
        {
            var query = _query.UpdatePerformance(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetup(int id, Decimal value)
        {
            var query = _query.UpdateTempoSetup(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetupAjuste(int id, Decimal value)
        {
            var query = _query.UpdateTempoSetupAjuste(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProximaSequenciaTransformacao(int id, int value)
        {
            var query = _query.UpdateProximaSequenciaTransformacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, string value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHierarquiaSequenciaTransformacao(int id, Decimal value)
        {
            var query = _query.UpdateHierarquiaSequenciaTransformacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAvaliaCusto(int id, int value)
        {
            var query = _query.UpdateAvaliaCusto(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperacoes(int id, string value)
        {
            var query = _query.UpdateOperacoes(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExcecaoOperacoes(int id, string value)
        {
            var query = _query.UpdateExcecaoOperacoes(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePercentualInicioPassoAnterior(int id, Decimal value)
        {
            var query = _query.UpdatePercentualInicioPassoAnterior(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLinhaDireta(int id, string value)
        {
            var query = _query.UpdateLinhaDireta(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTemplateDeTestesId(int id, int value)
        {
            var query = _query.UpdateTemplateDeTestesId(id, value);
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