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

namespace Input.Repository.ExperienciaPlanejamentoTransporte
{
    public partial class ExperienciaPlanejamentoTransporteWriteRepository : IExperienciaPlanejamentoTransporteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IExperienciaPlanejamentoTransporteQueryWrite _query; 

        public ExperienciaPlanejamentoTransporteWriteRepository(IUnitOfWork unitOfWork,IExperienciaPlanejamentoTransporteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            var query = _query.InserirExperienciaPlanejamentoTransporteQuery(ExperienciaPlanejamentoTransporte);
        ExperienciaPlanejamentoTransporte.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            var query = _query.UpdateExperienciaPlanejamentoTransporteQuery(ExperienciaPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte)
        {
            var query = _query.DeleteExperienciaPlanejamentoTransporteQuery(ExperienciaPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipo(int id, int value)
        {
            var query = _query.UpdateTipo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateReferencia(int id, string value)
        {
            var query = _query.UpdateReferencia(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePedidoId(int id, string value)
        {
            var query = _query.UpdatePedidoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClienteId(int id, string value)
        {
            var query = _query.UpdateClienteId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipio(int id, string value)
        {
            var query = _query.UpdateMunicipio(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRegiao(int id, string value)
        {
            var query = _query.UpdateRegiao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRotaId(int id, string value)
        {
            var query = _query.UpdateRotaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePeso(int id, Decimal value)
        {
            var query = _query.UpdatePeso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVolume(int id, Decimal value)
        {
            var query = _query.UpdateVolume(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObservacao(int id, string value)
        {
            var query = _query.UpdateObservacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCriadoEm(int id, DateTime value)
        {
            var query = _query.UpdateCriadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCriadoPor(int id, string value)
        {
            var query = _query.UpdateCriadoPor(id, value);
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