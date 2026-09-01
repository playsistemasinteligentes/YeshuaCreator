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
    public partial interface IEstruturaImpressaoWriteRepository
    {
        void Insert(IEstruturaImpressaoEntity estruturaimpressao);
        void Update(IEstruturaImpressaoEntity estruturaimpressao);
        void Delete(IEstruturaImpressaoEntity estruturaimpressao);
        void UpdateHTML_ESTRUTURA(int est_id, string value);
        void UpdateCLI_ID(int est_id, string value);
        void UpdateEST_DESCRICAO(int est_id, string value);
        void UpdateTenantID(int est_id, int value);
        void UpdateDeleted(int est_id, bool value);
        void UpdateChanged(int est_id, DateTime value);
        void UpdateUserId(int est_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration