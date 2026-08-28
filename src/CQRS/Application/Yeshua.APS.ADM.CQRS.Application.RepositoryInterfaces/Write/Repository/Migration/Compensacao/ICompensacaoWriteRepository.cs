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
    public partial interface ICompensacaoWriteRepository
    {
        void Insert(ICompensacaoEntity compensacao);
        void Update(ICompensacaoEntity compensacao);
        void Delete(ICompensacaoEntity compensacao);
        void UpdateCOM_ID(int id, int value);
        void UpdateGRP_ID(int id, string value);
        void UpdateOND_ID(int id, string value);
        void UpdateCOM_VINCO1_OND(int id, int value);
        void UpdateCOM_VINCO2_OND(int id, int value);
        void UpdateCOM_VINCO3_OND(int id, int value);
        void UpdateCOM_VINCO4_OND(int id, int value);
        void UpdateCOM_VINCO5_OND(int id, int value);
        void UpdateCOM_VINCO6_OND(int id, int value);
        void UpdateCOM_VINCO7_OND(int id, int value);
        void UpdateCOM_VINCO8_OND(int id, int value);
        void UpdateCOM_VINCO9_OND(int id, int value);
        void UpdateCOM_VINCO10_OND(int id, int value);
        void UpdateCOM_VINCO1_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO2_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO3_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO4_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO5_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO6_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO7_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO8_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO9_CONVERSAO(int id, int value);
        void UpdateCOM_VINCO10_CONVERSAO(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration