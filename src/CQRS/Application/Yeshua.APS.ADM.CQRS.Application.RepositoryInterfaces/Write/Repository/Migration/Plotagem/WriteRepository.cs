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
    public partial interface IPlotagemWriteRepository
    {
        void Insert(IPlotagemEntity plotagem);
        void Update(IPlotagemEntity plotagem);
        void Delete(IPlotagemEntity plotagem);
        void UpdatePLO_ID(int id, int value);
        void UpdatePLO_NOME(int id, string value);
        void UpdatePLO_DIMENSAO(int id, string value);
        void UpdatePLO_X(int id, string value);
        void UpdatePLO_Y(int id, string value);
        void UpdatePLO_Z(int id, string value);
        void UpdatePLO_GRAFICO(int id, string value);
        void UpdateCON_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration