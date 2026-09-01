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
    public partial interface IMaquinaImpressoraWriteRepository
    {
        void Insert(IMaquinaImpressoraEntity maquinaimpressora);
        void Update(IMaquinaImpressoraEntity maquinaimpressora);
        void Delete(IMaquinaImpressoraEntity maquinaimpressora);
        void UpdateMAQ_ID(int maq_imp_id, string value);
        void UpdateIMP_ID(int maq_imp_id, int value);
        void UpdateMAI_FACAO(int maq_imp_id, int value);
        void UpdateTenantID(int maq_imp_id, int value);
        void UpdateDeleted(int maq_imp_id, bool value);
        void UpdateChanged(int maq_imp_id, DateTime value);
        void UpdateUserId(int maq_imp_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration