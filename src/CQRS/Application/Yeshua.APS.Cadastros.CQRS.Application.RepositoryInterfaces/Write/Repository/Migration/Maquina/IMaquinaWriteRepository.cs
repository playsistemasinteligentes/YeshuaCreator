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
    public partial interface IMaquinaWriteRepository
    {
        void Insert(IMaquinaEntity maquina);
        void Update(IMaquinaEntity maquina);
        void Delete(IMaquinaEntity maquina);
        void UpdateMAQ_DESCRICAO(string maq_id, string value);
        void UpdateMAQ_STATUS(string maq_id, string value);
        void UpdateTenantID(string maq_id, int value);
        void UpdateDeleted(string maq_id, bool value);
        void UpdateChanged(string maq_id, DateTime value);
        void UpdateUserId(string maq_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration