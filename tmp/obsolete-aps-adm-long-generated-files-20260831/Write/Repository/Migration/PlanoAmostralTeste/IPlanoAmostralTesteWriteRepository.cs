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
    public partial interface IPlanoAmostralTesteWriteRepository
    {
        void Insert(IPlanoAmostralTesteEntity planoamostralteste);
        void Update(IPlanoAmostralTesteEntity planoamostralteste);
        void Delete(IPlanoAmostralTesteEntity planoamostralteste);
        void UpdateGRP_TIPO(int pat_id, Decimal value);
        void UpdateTenantID(int pat_id, int value);
        void UpdateDeleted(int pat_id, bool value);
        void UpdateChanged(int pat_id, DateTime value);
        void UpdateUserId(int pat_id, int value);
        void UpdatePAT_QTD_CAIXAS_DE(int pat_id, int value);
        void UpdatePAT_QTD_CAIXAS_ATE(int pat_id, int value);
        void UpdatePAT_N_AMOSTRAGEM(int pat_id, int value);
        void UpdatePAT_PERCENT_ESPECIF(int pat_id, Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration