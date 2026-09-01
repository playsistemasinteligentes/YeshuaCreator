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
    public partial interface IOcorrenciaWriteRepository
    {
        void Insert(IOcorrenciaEntity ocorrencia);
        void Update(IOcorrenciaEntity ocorrencia);
        void Delete(IOcorrenciaEntity ocorrencia);
        void UpdateOCO_DESCRICAO(string oco_id, string value);
        void UpdateTIP_ID(string oco_id, int value);
        void UpdateGMA_ID(string oco_id, string value);
        void UpdateMAQ_ID(string oco_id, string value);
        void UpdateSPR(string oco_id, int value);
        void UpdateOCO_SUB_TIPO(string oco_id, string value);
        void UpdateSUB_ID(string oco_id, string value);
        void UpdateTenantID(string oco_id, int value);
        void UpdateDeleted(string oco_id, bool value);
        void UpdateChanged(string oco_id, DateTime value);
        void UpdateUserId(string oco_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration