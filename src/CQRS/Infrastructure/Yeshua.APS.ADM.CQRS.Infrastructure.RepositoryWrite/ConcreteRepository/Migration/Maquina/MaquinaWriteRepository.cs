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

namespace Input.Repository.Maquina
{
    public partial class MaquinaWriteRepository : IMaquinaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMaquinaQueryWrite _query; 

        public MaquinaWriteRepository(IUnitOfWork unitOfWork,IMaquinaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMaquinaEntity Maquina)
        {
            var query = _query.InserirMaquinaQuery(Maquina);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IMaquinaEntity Maquina)
        {
            var query = _query.UpdateMaquinaQuery(Maquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMaquinaEntity Maquina)
        {
            var query = _query.DeleteMaquinaQuery(Maquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(string id, string value)
        {
            var query = _query.UpdateDescricao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string id, string value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_ID(string id, int value)
        {
            var query = _query.UpdateCAL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_CONTROL_IP(string id, string value)
        {
            var query = _query.UpdateMAQ_CONTROL_IP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_ID(string id, string value)
        {
            var query = _query.UpdateGMA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ULTIMA_ATUALIZACAO(string id, DateTime value)
        {
            var query = _query.UpdateMAQ_ULTIMA_ATUALIZACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_SIRENE_SEMAFORO(string id, int value)
        {
            var query = _query.UpdateMAQ_SIRENE_SEMAFORO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COR_SEMAFORO(string id, string value)
        {
            var query = _query.UpdateMAQ_COR_SEMAFORO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_MAQ_PAI(string id, string value)
        {
            var query = _query.UpdateMAQ_ID_MAQ_PAI(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TIPO_CONTADOR(string id, int value)
        {
            var query = _query.UpdateMAQ_TIPO_CONTADOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TIPO_PLANEJAMENTO(string id, string value)
        {
            var query = _query.UpdateMAQ_TIPO_PLANEJAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_AVALIA_CUSTO(string id, int value)
        {
            var query = _query.UpdateMAQ_AVALIA_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ID_OP_PRODUZINDO(string id, int value)
        {
            var query = _query.UpdateFPR_ID_OP_PRODUZINDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_CONGELA_FILA(string id, int value)
        {
            var query = _query.UpdateMAQ_CONGELA_FILA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TEMPO_MIN_PARADA(string id, int value)
        {
            var query = _query.UpdateMAQ_TEMPO_MIN_PARADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_QTD_CORES(string id, int value)
        {
            var query = _query.UpdateMAQ_QTD_CORES(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_INTEGRACAO(string id, string value)
        {
            var query = _query.UpdateMAQ_ID_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_INTEGRACAO_ERP(string id, string value)
        {
            var query = _query.UpdateMAQ_ID_INTEGRACAO_ERP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEQU_ID(string id, string value)
        {
            var query = _query.UpdateEQU_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ACOMPANHA_LOTE_PILOTO(string id, string value)
        {
            var query = _query.UpdateMAQ_ACOMPANHA_LOTE_PILOTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_SENSOR(string id, int value)
        {
            var query = _query.UpdateMAQ_ID_SENSOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_DEBOUNCING_LOW(string id, int value)
        {
            var query = _query.UpdateMAQ_DEBOUNCING_LOW(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_DEBOUNCING_HIGHT(string id, int value)
        {
            var query = _query.UpdateMAQ_DEBOUNCING_HIGHT(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TIPO_SINAL(string id, int value)
        {
            var query = _query.UpdateMAQ_TIPO_SINAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(string id, int value)
        {
            var query = _query.UpdateTEM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_CHAPA_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_CHAPA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_CHAPA_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_CHAPA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_ENTRE_VINCO_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_ENTRE_VINCO_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ALTURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ALTURA_ENTRE_VINCO_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ALTURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ALTURA_ENTRE_VINCO_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ABA_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ABA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ABA_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ABA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LAP_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LAP_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LAP_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LAP_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ONDAS(string id, string value)
        {
            var query = _query.UpdateMAQ_ONDAS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_PROLONGA_LAP(string id, string value)
        {
            var query = _query.UpdateMAQ_PROLONGA_LAP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_IMPRESSAO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_IMPRESSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_COMPRIMENTO_IMPRESSAO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_COMPRIMENTO_IMPRESSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ROLO_DISPOSITIVO_DE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ROLO_DISPOSITIVO_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ROLO_DISPOSITIVO_ATE(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_ROLO_DISPOSITIVO_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_FAMILIAS(string id, string value)
        {
            var query = _query.UpdateMAQ_FAMILIAS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_REFILE_MINIMO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_REFILE_MINIMO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_LARGURA_UTIL(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_LARGURA_UTIL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TOTAL_ACO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_TOTAL_ACO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_FECHAMENTO(string id, string value)
        {
            var query = _query.UpdateMAQ_FECHAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_OPERACAO_VINCAR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_OPERACAO_VINCAR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_OPERACAO_MONTA_DIVISAO(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_OPERACAO_MONTA_DIVISAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_OPERACAO_SERRAR(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_OPERACAO_SERRAR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TIPO_LAP(string id, string value)
        {
            var query = _query.UpdateMAQ_TIPO_LAP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_INDICE_PARADAS_POR_OP(string id, Decimal value)
        {
            var query = _query.UpdateMAQ_INDICE_PARADAS_POR_OP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_PERDA_MAXIMA(string id, int value)
        {
            var query = _query.UpdateMAQ_PERDA_MAXIMA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TOTAL_PECAS_REFILANDO(string id, int value)
        {
            var query = _query.UpdateMAQ_TOTAL_PECAS_REFILANDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TOTAL_PECAS_NAO_REFILANDO(string id, int value)
        {
            var query = _query.UpdateMAQ_TOTAL_PECAS_NAO_REFILANDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_TOTAL_VINCOS(string id, int value)
        {
            var query = _query.UpdateMAQ_TOTAL_VINCOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration