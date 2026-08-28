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

namespace Input.Repository.MovimentoEstoque
{
    public partial class MovimentoEstoqueWriteRepository : IMovimentoEstoqueWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMovimentoEstoqueQueryWrite _query; 

        public MovimentoEstoqueWriteRepository(IUnitOfWork unitOfWork,IMovimentoEstoqueQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            var query = _query.InserirMovimentoEstoqueQuery(MovimentoEstoque);
        MovimentoEstoque.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            var query = _query.UpdateMovimentoEstoqueQuery(MovimentoEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            var query = _query.DeleteMovimentoEstoqueQuery(MovimentoEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoId(int id, string value)
        {
            var query = _query.UpdateProdutoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOrderId(int id, string value)
        {
            var query = _query.UpdateOrderId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipo(int id, string value)
        {
            var query = _query.UpdateTipo(id, value);
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
        public void UpdateQuantidade(int id, Decimal value)
        {
            var query = _query.UpdateQuantidade(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_PESO_UNITARIO(int id, Decimal value)
        {
            var query = _query.UpdateMOV_PESO_UNITARIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataHoraCriacao(int id, DateTime value)
        {
            var query = _query.UpdateDataHoraCriacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataHoraEmissao(int id, DateTime value)
        {
            var query = _query.UpdateDataHoraEmissao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiaTurma(int id, string value)
        {
            var query = _query.UpdateDiaTurma(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLote(int id, string value)
        {
            var query = _query.UpdateLote(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSubLote(int id, string value)
        {
            var query = _query.UpdateSubLote(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMaquinaId(int id, string value)
        {
            var query = _query.UpdateMaquinaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int id, int value)
        {
            var query = _query.UpdateUSE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObservacao(int id, string value)
        {
            var query = _query.UpdateObservacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOcorrenciaId(int id, string value)
        {
            var query = _query.UpdateOcorrenciaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateArmazem(int id, string value)
        {
            var query = _query.UpdateArmazem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEndereco(int id, string value)
        {
            var query = _query.UpdateEndereco(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEstorno(int id, string value)
        {
            var query = _query.UpdateEstorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSequenciaTransformacao(int id, int value)
        {
            var query = _query.UpdateSequenciaTransformacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSequenciaRepeticao(int id, int value)
        {
            var query = _query.UpdateSequenciaRepeticao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObsOpParcial(int id, string value)
        {
            var query = _query.UpdateObsOpParcial(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOcoIdOpParcial(int id, string value)
        {
            var query = _query.UpdateOcoIdOpParcial(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_ID_INTEGRACAO(int id, string value)
        {
            var query = _query.UpdateMOV_ID_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_ID_INTEGRACAO_ERP(int id, string value)
        {
            var query = _query.UpdateMOV_ID_INTEGRACAO_ERP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int id, string value)
        {
            var query = _query.UpdateCAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_ID_DESTINO(int id, int value)
        {
            var query = _query.UpdateMOV_ID_DESTINO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_DESTINO(int id, string value)
        {
            var query = _query.UpdatePRO_ID_DESTINO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_LOTE_DESTINO(int id, string value)
        {
            var query = _query.UpdateMOV_LOTE_DESTINO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_SUB_LOTE_DESTINO(int id, string value)
        {
            var query = _query.UpdateMOV_SUB_LOTE_DESTINO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_ID_ORIGEM(int id, int value)
        {
            var query = _query.UpdateMOV_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_ORIGEM(int id, string value)
        {
            var query = _query.UpdatePRO_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_LOTE_ORIGEM(int id, string value)
        {
            var query = _query.UpdateMOV_LOTE_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_SUB_LOTE_ORIGEM(int id, string value)
        {
            var query = _query.UpdateMOV_SUB_LOTE_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_TYPE(int id, int value)
        {
            var query = _query.UpdateMOV_TYPE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_DOC(int id, string value)
        {
            var query = _query.UpdateMOV_DOC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_APROVEITAMENTO(int id, string value)
        {
            var query = _query.UpdateMOV_APROVEITAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_RETIDO(int id, string value)
        {
            var query = _query.UpdateMOV_RETIDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_VINCOS_ONDULADEIRA(int id, string value)
        {
            var query = _query.UpdateMOV_VINCOS_ONDULADEIRA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID_ORIGEM(int id, string value)
        {
            var query = _query.UpdateORD_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVER_ID(int id, int value)
        {
            var query = _query.UpdateVER_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_TIPO_CUSTO(int id, string value)
        {
            var query = _query.UpdateMOV_TIPO_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_GRUPO_CONTABIL(int id, string value)
        {
            var query = _query.UpdateMOV_GRUPO_CONTABIL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFOR_ID(int id, string value)
        {
            var query = _query.UpdateFOR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int id, string value)
        {
            var query = _query.UpdateCLI_ID(id, value);
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