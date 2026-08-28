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
    public partial interface ISegmentoWriteRepository
    {
        void Insert(ISegmentoEntity segmento);
        void Update(ISegmentoEntity segmento);
        void Delete(ISegmentoEntity segmento);
        void UpdateSEG_ID(int id, string value);
        void UpdateSEG_DESCRICAO(int id, string value);
        void UpdateSEG_ID_SEGUIMENTO_PAI(int id, string value);
        void UpdateGRS_ID(int id, string value);
        void UpdateSEG_INTEGRACAO_ERP(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration