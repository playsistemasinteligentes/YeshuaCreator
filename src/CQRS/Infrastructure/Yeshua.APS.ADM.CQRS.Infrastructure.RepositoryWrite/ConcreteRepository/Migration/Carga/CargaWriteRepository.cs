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

namespace Input.Repository.Carga
{
    public partial class CargaWriteRepository : ICargaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICargaQueryWrite _query; 

        public CargaWriteRepository(IUnitOfWork unitOfWork,ICargaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICargaEntity Carga)
        {
            var query = _query.InserirCargaQuery(Carga);
        Carga.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICargaEntity Carga)
        {
            var query = _query.UpdateCargaQuery(Carga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICargaEntity Carga)
        {
            var query = _query.DeleteCargaQuery(Carga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int id, string value)
        {
            var query = _query.UpdateCAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PREVISAO_MATERIA_PRIMA(int id, DateTime value)
        {
            var query = _query.UpdateCAR_PREVISAO_MATERIA_PRIMA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_INICIO_PREVISTO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_INICIO_PREVISTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_INICIO_REALIZADO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_INICIO_REALIZADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_FIM_PREVISTO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_FIM_PREVISTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_FIM_REALIZADO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_FIM_REALIZADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_INICIO_JANELA_EMBARQUE(int id, DateTime value)
        {
            var query = _query.UpdateCAR_INICIO_JANELA_EMBARQUE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_FIM_JANELA_EMBARQUE(int id, DateTime value)
        {
            var query = _query.UpdateCAR_FIM_JANELA_EMBARQUE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_EMBARQUE_ALVO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_EMBARQUE_ALVO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_STATUS(int id, Decimal value)
        {
            var query = _query.UpdateCAR_STATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESO_TEORICO(int id, Decimal value)
        {
            var query = _query.UpdateCAR_PESO_TEORICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_VOLUME_TEORICO(int id, Decimal value)
        {
            var query = _query.UpdateCAR_VOLUME_TEORICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESO_REAL(int id, Decimal value)
        {
            var query = _query.UpdateCAR_PESO_REAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_VOLUME_REAL(int id, Decimal value)
        {
            var query = _query.UpdateCAR_VOLUME_REAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESO_EMBALAGEM(int id, Decimal value)
        {
            var query = _query.UpdateCAR_PESO_EMBALAGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESO_ENTRADA(int id, Decimal value)
        {
            var query = _query.UpdateCAR_PESO_ENTRADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESO_SAIDA(int id, Decimal value)
        {
            var query = _query.UpdateCAR_PESO_SAIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID_DOCA(int id, string value)
        {
            var query = _query.UpdateCAR_ID_DOCA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVEI_PLACA(int id, string value)
        {
            var query = _query.UpdateVEI_PLACA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(int id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_ID(int id, string value)
        {
            var query = _query.UpdateTRA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            var query = _query.UpdateCAR_GRUPO_PRODUTIVO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_ID(int id, string value)
        {
            var query = _query.UpdateROT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_OBSERVACAO_DE_TRANSPORTE(int id, string value)
        {
            var query = _query.UpdateCAR_OBSERVACAO_DE_TRANSPORTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(int id, string value)
        {
            var query = _query.UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID(int id, string value)
        {
            var query = _query.UpdateOCO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID_JUNTADA(int id, string value)
        {
            var query = _query.UpdateCAR_ID_JUNTADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_OBSERVACAO_OTIMIZADOR(int id, string value)
        {
            var query = _query.UpdateCAR_OBSERVACAO_OTIMIZADOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID_INTEGRACAO_BALANCA(int id, string value)
        {
            var query = _query.UpdateCAR_ID_INTEGRACAO_BALANCA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_PESAGEM_LIBERADA(int id, string value)
        {
            var query = _query.UpdateCAR_PESAGEM_LIBERADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_OBS_LIERACAO(int id, string value)
        {
            var query = _query.UpdateCAR_OBS_LIERACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_LIERACAO(int id, string value)
        {
            var query = _query.UpdateOCO_ID_LIERACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_ENTRADA_VEICULO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_ENTRADA_VEICULO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_SAIDA_VEICULO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_SAIDA_VEICULO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_ROMANEIO_CONSOLIDADO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_ROMANEIO_CONSOLIDADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(int id, string value)
        {
            var query = _query.UpdateCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DIFERENCA_PESAGEM(int id, Decimal value)
        {
            var query = _query.UpdateCAR_DIFERENCA_PESAGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_DATA_AGENCIAMENTO(int id, DateTime value)
        {
            var query = _query.UpdateCAR_DATA_AGENCIAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_ID(int id, string value)
        {
            var query = _query.UpdateTURN_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_ID(int id, string value)
        {
            var query = _query.UpdateTURM_ID(id, value);
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