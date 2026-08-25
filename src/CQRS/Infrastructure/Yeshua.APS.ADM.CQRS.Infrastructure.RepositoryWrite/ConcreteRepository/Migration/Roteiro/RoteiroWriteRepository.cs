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
                _UnitOfWork.Execute(query.Query, query.Parameters);
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
        public void UpdateGrupoMaquinaId(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateGrupoMaquinaId(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePecasPorPulso(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePecasPorPulso(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePrioridadeInformada(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePrioridadeInformada(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAcao(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateAcao(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePerformance(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePerformance(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetup(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateTempoSetup(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetupAjuste(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateTempoSetupAjuste(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProximaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateProximaSequenciaTransformacao(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateStatus(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHierarquiaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateHierarquiaSequenciaTransformacao(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAvaliaCusto(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateAvaliaCusto(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateOperacoes(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExcecaoOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateExcecaoOperacoes(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePercentualInicioPassoAnterior(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePercentualInicioPassoAnterior(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLinhaDireta(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateLinhaDireta(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTemplateDeTestesId(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateTemplateDeTestesId(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateTenantID(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string maquinaid, string produtoid, int sequenciatransformacao, bool value)
        {
            var query = _query.UpdateDeleted(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string maquinaid, string produtoid, int sequenciatransformacao, DateTime value)
        {
            var query = _query.UpdateChanged(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateUserId(maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration