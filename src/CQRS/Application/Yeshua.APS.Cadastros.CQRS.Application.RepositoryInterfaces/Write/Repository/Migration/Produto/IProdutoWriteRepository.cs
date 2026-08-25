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
    public partial interface IProdutoWriteRepository
    {
        void Insert(IProdutoEntity produto);
        void Update(IProdutoEntity produto);
        void Delete(IProdutoEntity produto);
        void UpdatePRO_DESCRICAO(string pro_id, string value);
        void UpdatePRO_STATUS(string pro_id, string value);
        void UpdateTenantID(string pro_id, int value);
        void UpdateDeleted(string pro_id, bool value);
        void UpdateChanged(string pro_id, DateTime value);
        void UpdateUserId(string pro_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration