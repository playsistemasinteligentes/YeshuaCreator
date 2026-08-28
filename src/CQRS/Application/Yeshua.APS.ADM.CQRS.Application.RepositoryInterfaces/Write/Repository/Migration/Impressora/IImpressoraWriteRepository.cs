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
    public partial interface IImpressoraWriteRepository
    {
        void Insert(IImpressoraEntity impressora);
        void Update(IImpressoraEntity impressora);
        void Delete(IImpressoraEntity impressora);
        void UpdateIMP_IP(int imp_id, string value);
        void UpdateIMP_NOME(int imp_id, string value);
        void UpdateTenantID(int imp_id, int value);
        void UpdateDeleted(int imp_id, bool value);
        void UpdateChanged(int imp_id, DateTime value);
        void UpdateUserId(int imp_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration