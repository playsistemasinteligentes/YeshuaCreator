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
    public partial interface ICorConfiguracaoGraficoWriteRepository
    {
        void Insert(ICorConfiguracaoGraficoEntity corconfiguracaografico);
        void Update(ICorConfiguracaoGraficoEntity corconfiguracaografico);
        void Delete(ICorConfiguracaoGraficoEntity corconfiguracaografico);
        void UpdateCOR_PERCENTUAL_INI(string cor_id, Decimal value);
        void UpdateCOR_PERCENTUAL_FIM(string cor_id, Decimal value);
        void UpdateCOR_DESCRICAO(string cor_id, string value);
        void UpdateTenantID(string cor_id, int value);
        void UpdateDeleted(string cor_id, bool value);
        void UpdateChanged(string cor_id, DateTime value);
        void UpdateUserId(string cor_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration