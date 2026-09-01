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
    public partial interface IParamWriteRepository
    {
        void Insert(IParamEntity param);
        void Update(IParamEntity param);
        void Delete(IParamEntity param);
        void UpdatePAR_DESCRICAO(string par_id, string value);
        void UpdatePAR_VALOR_S(string par_id, string value);
        void UpdatePAR_VALOR_N(string par_id, Decimal value);
        void UpdatePAR_VALOR_D(string par_id, DateTime value);
        void UpdateTenantID(string par_id, int value);
        void UpdateDeleted(string par_id, bool value);
        void UpdateChanged(string par_id, DateTime value);
        void UpdateUserId(string par_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration