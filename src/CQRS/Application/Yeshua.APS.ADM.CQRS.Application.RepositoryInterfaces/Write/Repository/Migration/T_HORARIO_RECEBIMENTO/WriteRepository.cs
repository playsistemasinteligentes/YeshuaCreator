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
    public partial interface IT_HORARIO_RECEBIMENTOWriteRepository
    {
        void Insert(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento);
        void Update(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento);
        void Delete(IT_HORARIO_RECEBIMENTOEntity t_horario_recebimento);
        void UpdateHRE_DIA_DA_SEMANA(int hre_id, int value);
        void UpdateHRE_HORA_INICIAL(int hre_id, DateTime value);
        void UpdateHRE_HORA_FINAL(int hre_id, DateTime value);
        void UpdateCLI_ID(int hre_id, string value);
        void UpdateTenantID(int hre_id, int value);
        void UpdateDeleted(int hre_id, bool value);
        void UpdateChanged(int hre_id, DateTime value);
        void UpdateUserId(int hre_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration