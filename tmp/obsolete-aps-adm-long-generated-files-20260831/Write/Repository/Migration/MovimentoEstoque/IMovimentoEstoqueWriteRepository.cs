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
    public partial interface IMovimentoEstoqueWriteRepository
    {
        void Insert(IMovimentoEstoqueEntity movimentoestoque);
        void Update(IMovimentoEstoqueEntity movimentoestoque);
        void Delete(IMovimentoEstoqueEntity movimentoestoque);
        void UpdateProdutoId(int id, string value);
        void UpdateOrderId(int id, string value);
        void UpdateTipo(int id, string value);
        void UpdateTurnoId(int id, string value);
        void UpdateTurmaId(int id, string value);
        void UpdateQuantidade(int id, Decimal value);
        void UpdateMOV_PESO_UNITARIO(int id, Decimal value);
        void UpdateDataHoraCriacao(int id, DateTime value);
        void UpdateDataHoraEmissao(int id, DateTime value);
        void UpdateDiaTurma(int id, string value);
        void UpdateLote(int id, string value);
        void UpdateSubLote(int id, string value);
        void UpdateMaquinaId(int id, string value);
        void UpdateUSE_ID(int id, int value);
        void UpdateObservacao(int id, string value);
        void UpdateOcorrenciaId(int id, string value);
        void UpdateArmazem(int id, string value);
        void UpdateEndereco(int id, string value);
        void UpdateEstorno(int id, string value);
        void UpdateSequenciaTransformacao(int id, int value);
        void UpdateSequenciaRepeticao(int id, int value);
        void UpdateObsOpParcial(int id, string value);
        void UpdateOcoIdOpParcial(int id, string value);
        void UpdateMOV_ID_INTEGRACAO(int id, string value);
        void UpdateMOV_ID_INTEGRACAO_ERP(int id, string value);
        void UpdateCAR_ID(int id, string value);
        void UpdateMOV_ID_DESTINO(int id, int value);
        void UpdatePRO_ID_DESTINO(int id, string value);
        void UpdateMOV_LOTE_DESTINO(int id, string value);
        void UpdateMOV_SUB_LOTE_DESTINO(int id, string value);
        void UpdateMOV_ID_ORIGEM(int id, int value);
        void UpdatePRO_ID_ORIGEM(int id, string value);
        void UpdateMOV_LOTE_ORIGEM(int id, string value);
        void UpdateMOV_SUB_LOTE_ORIGEM(int id, string value);
        void UpdateMOV_TYPE(int id, int value);
        void UpdateMOV_DOC(int id, string value);
        void UpdateMOV_APROVEITAMENTO(int id, string value);
        void UpdateMOV_RETIDO(int id, string value);
        void UpdateMOV_VINCOS_ONDULADEIRA(int id, string value);
        void UpdateBOL_ID(int id, string value);
        void UpdateORD_ID_ORIGEM(int id, string value);
        void UpdateCOR_SEQUENCIA(int id, int value);
        void UpdateVER_ID(int id, int value);
        void UpdateMOV_TIPO_CUSTO(int id, string value);
        void UpdateMOV_GRUPO_CONTABIL(int id, string value);
        void UpdateFOR_ID(int id, string value);
        void UpdateCLI_ID(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration