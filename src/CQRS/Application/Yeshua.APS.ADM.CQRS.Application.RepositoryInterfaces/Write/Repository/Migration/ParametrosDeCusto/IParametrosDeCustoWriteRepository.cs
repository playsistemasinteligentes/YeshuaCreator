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
    public partial interface IParametrosDeCustoWriteRepository
    {
        void Insert(IParametrosDeCustoEntity parametrosdecusto);
        void Update(IParametrosDeCustoEntity parametrosdecusto);
        void Delete(IParametrosDeCustoEntity parametrosdecusto);
        void UpdatePAR_ID(int id, int value);
        void UpdatePRO_ID(int id, string value);
        void UpdateCUS_ID(int id, string value);
        void UpdatePAR_VALOR(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration