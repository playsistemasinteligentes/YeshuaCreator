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

namespace Input.Repository.CorridasOnduladeiraEstudo
{
    public partial class CorridasOnduladeiraEstudoWriteRepository : ICorridasOnduladeiraEstudoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICorridasOnduladeiraEstudoQueryWrite _query; 

        public CorridasOnduladeiraEstudoWriteRepository(IUnitOfWork unitOfWork,ICorridasOnduladeiraEstudoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            var query = _query.InserirCorridasOnduladeiraEstudoQuery(CorridasOnduladeiraEstudo);
        CorridasOnduladeiraEstudo.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            var query = _query.UpdateCorridasOnduladeiraEstudoQuery(CorridasOnduladeiraEstudo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            var query = _query.DeleteCorridasOnduladeiraEstudoQuery(CorridasOnduladeiraEstudo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID_ORIGEM(int id, string value)
        {
            var query = _query.UpdateBOL_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_PECA(int id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_PECA_PROGRAMADO(int id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_PECA_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_PECA(int id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int id, Decimal value)
        {
            var query = _query.UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_VINCOS_RECALCULADOS(int id, string value)
        {
            var query = _query.UpdatePRO_VINCOS_RECALCULADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SOLVER(int id, string value)
        {
            var query = _query.UpdateCOR_SOLVER(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_CUSTO_RESINA_PROGRAMADOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_TOLERANCIA_MENOS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_TOLERANCIA_MENOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_TOLERANCIA_MAIS(int id, Decimal value)
        {
            var query = _query.UpdateCOR_TOLERANCIA_MAIS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_PILHAS_POR_PALETE(int id, int value)
        {
            var query = _query.UpdateCOR_PILHAS_POR_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_M_LINEAR_REALIZADO(int id, Decimal value)
        {
            var query = _query.UpdateCOR_M_LINEAR_REALIZADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PALETE(int id, string value)
        {
            var query = _query.UpdatePRO_ID_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_STATUS_PALETE(int id, string value)
        {
            var query = _query.UpdateCOR_STATUS_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            var query = _query.UpdateCOR_GRUPO_PRODUTIVO(id, value);
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