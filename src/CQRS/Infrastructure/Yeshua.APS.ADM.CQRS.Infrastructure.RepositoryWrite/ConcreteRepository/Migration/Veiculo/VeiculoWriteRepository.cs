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

namespace Input.Repository.Veiculo
{
    public partial class VeiculoWriteRepository : IVeiculoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IVeiculoQueryWrite _query; 

        public VeiculoWriteRepository(IUnitOfWork unitOfWork,IVeiculoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IVeiculoEntity Veiculo)
        {
            var query = _query.InserirVeiculoQuery(Veiculo);
        Veiculo.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IVeiculoEntity Veiculo)
        {
            var query = _query.UpdateVeiculoQuery(Veiculo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IVeiculoEntity Veiculo)
        {
            var query = _query.DeleteVeiculoQuery(Veiculo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_PLACA(int id, string value)
        {
            var query = _query.UpdateVEI_PLACA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_UF(int id, string value)
        {
            var query = _query.UpdateVEI_UF(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(int id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_CAPACIDADE_M3(int id, Decimal value)
        {
            var query = _query.UpdateVEI_CAPACIDADE_M3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_CAPACIDADE_LARGURA(int id, Decimal value)
        {
            var query = _query.UpdateVEI_CAPACIDADE_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_CAPACIDADE_COMPRIMENTO(int id, Decimal value)
        {
            var query = _query.UpdateVEI_CAPACIDADE_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_CAPACIDADE_ALTURA(int id, Decimal value)
        {
            var query = _query.UpdateVEI_CAPACIDADE_ALTURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_MODELO(int id, string value)
        {
            var query = _query.UpdateVEI_MODELO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_NOME_MOTORISTA(int id, string value)
        {
            var query = _query.UpdateVEI_NOME_MOTORISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_DADOS_CONTATO(int id, string value)
        {
            var query = _query.UpdateVEI_DADOS_CONTATO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_CPF_MOTORISTA(int id, string value)
        {
            var query = _query.UpdateVEI_CPF_MOTORISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTCA_ID(int id, string value)
        {
            var query = _query.UpdateTCA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateVEI_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_VENCIMENTO(int id, DateTime value)
        {
            var query = _query.UpdateVEI_VENCIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_STATUS(int id, string value)
        {
            var query = _query.UpdateVEI_STATUS(id, value);
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