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
    public partial interface IIndicadoresFatosDimencoesWriteRepository
    {
        void Insert(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes);
        void Update(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes);
        void Delete(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes);
        void UpdateFAT_ID(int id, string value);
        void UpdateIND_ID(int id, int value);
        void UpdateDIM_ID(int id, int value);
        void UpdateFAT_DESCRICAO(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration