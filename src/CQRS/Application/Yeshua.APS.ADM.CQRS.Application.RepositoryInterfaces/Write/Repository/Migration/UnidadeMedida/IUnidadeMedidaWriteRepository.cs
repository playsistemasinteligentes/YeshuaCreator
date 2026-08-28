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
    public partial interface IUnidadeMedidaWriteRepository
    {
        void Insert(IUnidadeMedidaEntity unidademedida);
        void Update(IUnidadeMedidaEntity unidademedida);
        void Delete(IUnidadeMedidaEntity unidademedida);
        void UpdateUNI_DESCRICAO(string uni_id, string value);
        void UpdateUNI_ESCALA_TEMPO(string uni_id, string value);
        void UpdateTenantID(string uni_id, int value);
        void UpdateDeleted(string uni_id, bool value);
        void UpdateChanged(string uni_id, DateTime value);
        void UpdateUserId(string uni_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration