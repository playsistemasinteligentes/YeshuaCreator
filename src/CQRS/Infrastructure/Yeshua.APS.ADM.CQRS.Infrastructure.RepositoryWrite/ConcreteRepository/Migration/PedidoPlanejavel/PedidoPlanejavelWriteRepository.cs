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

namespace Input.Repository.PedidoPlanejavel
{
    public partial class PedidoPlanejavelWriteRepository : IPedidoPlanejavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPedidoPlanejavelQueryWrite _query; 

        public PedidoPlanejavelWriteRepository(IUnitOfWork unitOfWork,IPedidoPlanejavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            var query = _query.InserirPedidoPlanejavelQuery(PedidoPlanejavel);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            var query = _query.UpdatePedidoPlanejavelQuery(PedidoPlanejavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPedidoPlanejavelEntity PedidoPlanejavel)
        {
            var query = _query.DeletePedidoPlanejavelQuery(PedidoPlanejavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClienteId(string pedidoid, string value)
        {
            var query = _query.UpdateClienteId(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateClienteNome(string pedidoid, string value)
        {
            var query = _query.UpdateClienteNome(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEstado(string pedidoid, string value)
        {
            var query = _query.UpdateEstado(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipio(string pedidoid, string value)
        {
            var query = _query.UpdateMunicipio(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRegiao(string pedidoid, string value)
        {
            var query = _query.UpdateRegiao(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBairro(string pedidoid, string value)
        {
            var query = _query.UpdateBairro(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRotaId(string pedidoid, string value)
        {
            var query = _query.UpdateRotaId(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmbarqueAlvo(string pedidoid, DateTime value)
        {
            var query = _query.UpdateEmbarqueAlvo(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataEntregaDe(string pedidoid, DateTime value)
        {
            var query = _query.UpdateDataEntregaDe(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataEntregaAte(string pedidoid, DateTime value)
        {
            var query = _query.UpdateDataEntregaAte(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePeso(string pedidoid, Decimal value)
        {
            var query = _query.UpdatePeso(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVolume(string pedidoid, Decimal value)
        {
            var query = _query.UpdateVolume(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSaldoAExpedir(string pedidoid, Decimal value)
        {
            var query = _query.UpdateSaldoAExpedir(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string pedidoid, string value)
        {
            var query = _query.UpdateStatus(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCargaAtualId(string pedidoid, string value)
        {
            var query = _query.UpdateCargaAtualId(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVersaoPlanejamento(string pedidoid, string value)
        {
            var query = _query.UpdateVersaoPlanejamento(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAlertasResumo(string pedidoid, string value)
        {
            var query = _query.UpdateAlertasResumo(pedidoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration