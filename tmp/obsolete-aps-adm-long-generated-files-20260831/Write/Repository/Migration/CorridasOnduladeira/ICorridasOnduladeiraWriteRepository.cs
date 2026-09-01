// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface ICorridasOnduladeiraWriteRepository
    {
        void Insert(ICorridasOnduladeiraEntity corridasonduladeira);
        void Update(ICorridasOnduladeiraEntity corridasonduladeira);
        void Delete(ICorridasOnduladeiraEntity corridasonduladeira);
        void UpdateBOL_ID(int cor_id, string value);
        void UpdateBOL_ID_ORIGEM(int cor_id, string value);
        void UpdatePRO_LARGURA_PECA(int cor_id, Decimal value);
        void UpdatePRO_LARGURA_PECA_PROGRAMADO(int cor_id, Decimal value);
        void UpdatePRO_COMPRIMENTO_PECA(int cor_id, Decimal value);
        void UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int cor_id, Decimal value);
        void UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int cor_id, Decimal value);
        void UpdatePRO_VINCOS_RECALCULADOS(int cor_id, string value);
        void UpdateCOR_SOLVER(int cor_id, string value);
        void UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int cor_id, Decimal value);
        void UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int cor_id, Decimal value);
        void UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int cor_id, Decimal value);
        void UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int cor_id, Decimal value);
        void UpdateCOR_TOLERANCIA_MENOS(int cor_id, Decimal value);
        void UpdateCOR_TOLERANCIA_MAIS(int cor_id, Decimal value);
        void UpdateCOR_PILHAS_POR_PALETE(int cor_id, int value);
        void UpdateCOR_COR_FILA(int cor_id, string value);
        void UpdateCOR_M_LINEAR_REALIZADO(int cor_id, Decimal value);
        void UpdatePRO_ID_PALETE(int cor_id, string value);
        void UpdateCOR_STATUS_PALETE(int cor_id, string value);
        void UpdateCOR_GRUPO_PRODUTIVO(int cor_id, Decimal value);
        void UpdateTenantID(int cor_id, int value);
        void UpdateDeleted(int cor_id, bool value);
        void UpdateChanged(int cor_id, DateTime value);
        void UpdateUserId(int cor_id, int value);
        void UpdateCOR_STATUS(int cor_id, string value);
        void UpdateCOR_STATUS_INTERFACE(int cor_id, string value);
        void UpdateMAQ_ID(int cor_id, string value);
        void UpdateCOR_ID_INTERFACE(int cor_id, int value);
        void UpdateCOR_SEQUENCIA(int cor_id, int value);
        void UpdateCOR_SEQUENCIA_ORIGEM(int cor_id, int value);
        void UpdateORD_ID(int cor_id, string value);
        void UpdateFPR_SEQ_REPETICAO(int cor_id, int value);
        void UpdateROT_SEQ_TRANFORMACAO(int cor_id, int value);
        void UpdateCOR_FACAO(int cor_id, int value);
        void UpdateCOR_FORMATO_BOBINA(int cor_id, int value);
        void UpdateCOR_INICIO_PREVISTO(int cor_id, DateTime value);
        void UpdateCOR_FIM_PREVISTO(int cor_id, DateTime value);
        void UpdatePRO_ID(int cor_id, string value);
        void UpdateCOR_QTD_PLANEJADO(int cor_id, int value);
        void UpdatePRO_QTD_PACAS(int cor_id, int value);
        void UpdateCOR_PECAS_LARGURA(int cor_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration