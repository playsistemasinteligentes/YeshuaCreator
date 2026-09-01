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
    public partial interface IEtiquetaWriteRepository
    {
        void Insert(IEtiquetaEntity etiqueta);
        void Update(IEtiquetaEntity etiqueta);
        void Delete(IEtiquetaEntity etiqueta);
        void UpdateETI_EMISSAO(int eti_id, DateTime value);
        void UpdateETI_CODIGO_BARRAS(int eti_id, string value);
        void UpdateETI_SEQUENCIA(int eti_id, int value);
        void UpdateETI_NUMERO_COPIAS(int eti_id, int value);
        void UpdateETI_STATUS(int eti_id, string value);
        void UpdateETI_DATA_FABRICACAO(int eti_id, DateTime value);
        void UpdateETI_COD_BARRAS_ORIGINAL(int eti_id, string value);
        void UpdateETI_OP_ORIGINAL(int eti_id, string value);
        void UpdateMAQ_ID(int eti_id, string value);
        void UpdateIMP_ID(int eti_id, int value);
        void UpdateUSE_ID(int eti_id, int value);
        void UpdateORD_ID(int eti_id, string value);
        void UpdateROT_PRO_ID(int eti_id, string value);
        void UpdateROT_SEQ_TRANFORMACAO(int eti_id, int value);
        void UpdateFPR_SEQ_REPETICAO(int eti_id, int value);
        void UpdateETI_QUANTIDADE_PALETE(int eti_id, Decimal value);
        void UpdateETI_LOTE(int eti_id, string value);
        void UpdateETI_SUB_LOTE(int eti_id, string value);
        void UpdateETI_IMPRIMIR_DE(int eti_id, int value);
        void UpdateETI_IMPRIMIR_ATE(int eti_id, int value);
        void UpdateBOL_ID(int eti_id, string value);
        void UpdateCOR_SEQUENCIA(int eti_id, int value);
        void UpdateTenantID(int eti_id, int value);
        void UpdateDeleted(int eti_id, bool value);
        void UpdateChanged(int eti_id, DateTime value);
        void UpdateUserId(int eti_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration