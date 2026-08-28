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
    public partial interface ITurmaWriteRepository
    {
        void Insert(ITurmaEntity turma);
        void Update(ITurmaEntity turma);
        void Delete(ITurmaEntity turma);
        void UpdateDescricao(string id, string value);
        void UpdateTURM_HORA_INI_DIA1(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA1(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA2(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA2(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA3(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA3(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA4(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA4(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA5(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA5(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA6(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA6(string id, DateTime value);
        void UpdateTURM_HORA_INI_DIA7(string id, DateTime value);
        void UpdateTURM_HORA_FIM_DIA7(string id, DateTime value);
        void UpdateTenantID(string id, int value);
        void UpdateDeleted(string id, bool value);
        void UpdateChanged(string id, DateTime value);
        void UpdateUserId(string id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration