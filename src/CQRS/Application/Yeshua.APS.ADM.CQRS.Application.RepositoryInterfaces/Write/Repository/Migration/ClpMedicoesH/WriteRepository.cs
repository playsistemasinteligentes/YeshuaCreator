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
    public partial interface IClpMedicoesHWriteRepository
    {
        void Insert(IClpMedicoesHEntity clpmedicoesh);
        void Update(IClpMedicoesHEntity clpmedicoesh);
        void Delete(IClpMedicoesHEntity clpmedicoesh);
        void UpdateMAQUINA_ID(int id, string value);
        void UpdateDATA_INI(int id, DateTime value);
        void UpdateDATA_FIM(int id, DateTime value);
        void UpdateCLP_EMISSAO(int id, DateTime value);
        void UpdateQTD(int id, Decimal value);
        void UpdateGRUPO(int id, Decimal value);
        void UpdateSTATUS(int id, int value);
        void UpdateURN_ID(int id, string value);
        void UpdateURM_ID(int id, string value);
        void UpdateID_LOTE_CLP(int id, int value);
        void UpdateOCO_ID(int id, string value);
        void UpdateFASE(int id, int value);
        void UpdateCLP_ORIGEM(int id, string value);
        void UpdateCLP_LOTE(int id, int value);
        void UpdateCOMPACTA(int id, int value);
        void UpdateBOL_ID(int id, string value);
        void UpdateCOR_SEQUENCIA(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration