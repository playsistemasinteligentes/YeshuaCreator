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
    public partial interface IPlanocontasWriteRepository
    {
        void Insert(IPlanocontasEntity planocontas);
        void Update(IPlanocontasEntity planocontas);
        void Delete(IPlanocontasEntity planocontas);
        void UpdatePLA_CODIGO(int pla_id, string value);
        void UpdatePLA_DESCRICAO(int pla_id, string value);
        void UpdatePLA_TIPO(int pla_id, int value);
        void UpdatePLA_NATUREZA(int pla_id, string value);
        void UpdateTenantID(int pla_id, int value);
        void UpdateDeleted(int pla_id, bool value);
        void UpdateChanged(int pla_id, DateTime value);
        void UpdateUserId(int pla_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration