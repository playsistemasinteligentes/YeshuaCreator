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

namespace Input.Repository.TipoVeiculo
{
    public partial class TipoVeiculoWriteRepository : ITipoVeiculoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoVeiculoQueryWrite _query; 

        public TipoVeiculoWriteRepository(IUnitOfWork unitOfWork,ITipoVeiculoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoVeiculoEntity TipoVeiculo)
        {
            var query = _query.InserirTipoVeiculoQuery(TipoVeiculo);
        TipoVeiculo.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoVeiculoEntity TipoVeiculo)
        {
            var query = _query.UpdateTipoVeiculoQuery(TipoVeiculo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoVeiculoEntity TipoVeiculo)
        {
            var query = _query.DeleteTipoVeiculoQuery(TipoVeiculo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(int id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateTIP_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_QTD_DISPONIVEL(int id, int value)
        {
            var query = _query.UpdateTIP_QTD_DISPONIVEL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_VALOR_KM(int id, Decimal value)
        {
            var query = _query.UpdateTIP_VALOR_KM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_VALOR_DIARIA(int id, Decimal value)
        {
            var query = _query.UpdateTIP_VALOR_DIARIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_VALOR_AJUDANTE(int id, Decimal value)
        {
            var query = _query.UpdateTIP_VALOR_AJUDANTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_QTD_EIXOS(int id, Decimal value)
        {
            var query = _query.UpdateTIP_QTD_EIXOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_VELOCIDADE_MEDIA(int id, Decimal value)
        {
            var query = _query.UpdateTIP_VELOCIDADE_MEDIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_ALTURA(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_ALTURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_COMPRIMENTO(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_LARGURA(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_E(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_E(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_E(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_E(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_D(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_D(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_D(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_D(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_CAPACIDADE_M3(int id, Decimal value)
        {
            var query = _query.UpdateTIP_CAPACIDADE_M3(id, value);
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