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
    public partial interface IT_PREFERENCIASWriteRepository
    {
        void Insert(IT_PREFERENCIASEntity t_preferencias);
        void Update(IT_PREFERENCIASEntity t_preferencias);
        void Delete(IT_PREFERENCIASEntity t_preferencias);
        void UpdatePRE_ID(int id, int value);
        void UpdatePRE_DESCRICAO(int id, string value);
        void UpdatePRE_NAMESPACE(int id, string value);
        void UpdatePRE_TIPO(int id, string value);
        void UpdatePRE_VALOR(int id, string value);
        void UpdateUSE_ID(int id, int value);
        void UpdatePER_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration