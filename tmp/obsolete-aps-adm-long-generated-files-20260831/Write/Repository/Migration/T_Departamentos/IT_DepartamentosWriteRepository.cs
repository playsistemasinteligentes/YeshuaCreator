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
    public partial interface IT_DepartamentosWriteRepository
    {
        void Insert(IT_DepartamentosEntity t_departamentos);
        void Update(IT_DepartamentosEntity t_departamentos);
        void Delete(IT_DepartamentosEntity t_departamentos);
        void UpdateDEP_NOME(int dep_id, string value);
        void UpdateTenantID(int dep_id, int value);
        void UpdateDeleted(int dep_id, bool value);
        void UpdateChanged(int dep_id, DateTime value);
        void UpdateUserId(int dep_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration