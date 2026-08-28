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
    public partial interface IInformacoesComplementaresWriteRepository
    {
        void Insert(IInformacoesComplementaresEntity informacoescomplementares);
        void Update(IInformacoesComplementaresEntity informacoescomplementares);
        void Delete(IInformacoesComplementaresEntity informacoescomplementares);
        void UpdateINF_DESCRICAO(int inf_id, string value);
        void UpdateINF_VALOR(int inf_id, Decimal value);
        void UpdateMET_ID(int inf_id, int value);
        void UpdateINF_DATA(int inf_id, string value);
        void UpdateTenantID(int inf_id, int value);
        void UpdateDeleted(int inf_id, bool value);
        void UpdateChanged(int inf_id, DateTime value);
        void UpdateUserId(int inf_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration