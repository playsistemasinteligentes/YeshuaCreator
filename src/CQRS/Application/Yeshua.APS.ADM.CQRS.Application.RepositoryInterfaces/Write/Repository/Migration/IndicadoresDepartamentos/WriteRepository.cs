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
    public partial interface IIndicadoresDepartamentosWriteRepository
    {
        void Insert(IIndicadoresDepartamentosEntity indicadoresdepartamentos);
        void Update(IIndicadoresDepartamentosEntity indicadoresdepartamentos);
        void Delete(IIndicadoresDepartamentosEntity indicadoresdepartamentos);
        void UpdateDEP_ID(int inddep_id, int value);
        void UpdateIND_ID(int inddep_id, int value);
        void UpdateTenantID(int inddep_id, int value);
        void UpdateDeleted(int inddep_id, bool value);
        void UpdateChanged(int inddep_id, DateTime value);
        void UpdateUserId(int inddep_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration