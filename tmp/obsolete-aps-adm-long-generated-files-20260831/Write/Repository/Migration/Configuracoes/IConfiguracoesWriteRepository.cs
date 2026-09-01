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
    public partial interface IConfiguracoesWriteRepository
    {
        void Insert(IConfiguracoesEntity configuracoes);
        void Update(IConfiguracoesEntity configuracoes);
        void Delete(IConfiguracoesEntity configuracoes);
        void UpdateTenantID(int con_id, int value);
        void UpdateDeleted(int con_id, bool value);
        void UpdateChanged(int con_id, DateTime value);
        void UpdateUserId(int con_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration