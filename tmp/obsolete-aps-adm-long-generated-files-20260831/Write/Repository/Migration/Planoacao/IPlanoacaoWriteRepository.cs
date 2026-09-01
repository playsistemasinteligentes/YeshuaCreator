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
    public partial interface IPlanoacaoWriteRepository
    {
        void Insert(IPlanoacaoEntity planoacao);
        void Update(IPlanoacaoEntity planoacao);
        void Delete(IPlanoacaoEntity planoacao);
        void UpdatePLA_DESCRICAO(int pla_id, string value);
        void UpdateMET_ID(int pla_id, int value);
        void UpdatePLA_STATUS(int pla_id, string value);
        void UpdatePLA_DATA(int pla_id, DateTime value);
        void UpdatePLA_METAPERIODO(int pla_id, string value);
        void UpdatePLA_VLRPERIODO(int pla_id, string value);
        void UpdatePLA_METACULADO(int pla_id, string value);
        void UpdatePLA_VLRACUMULADO(int pla_id, string value);
        void UpdatePLA_REFERENCIA(int pla_id, string value);
        void UpdateUSE_ID(int pla_id, int value);
        void UpdateTenantID(int pla_id, int value);
        void UpdateDeleted(int pla_id, bool value);
        void UpdateChanged(int pla_id, DateTime value);
        void UpdateUserId(int pla_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration