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
    public partial interface IMovimentosWriteRepository
    {
        void Insert(IMovimentosEntity movimentos);
        void Update(IMovimentosEntity movimentos);
        void Delete(IMovimentosEntity movimentos);
        void UpdateMOV_DATA(int mov_id, string value);
        void UpdateMOV_VALOR(int mov_id, Decimal value);
        void UpdateMOV_PLAID(int mov_id, int value);
        void UpdateMOV_UNID(int mov_id, int value);
        void UpdateTr_Unidade_UNI_ID(int mov_id, int value);
        void UpdateTenantID(int mov_id, int value);
        void UpdateDeleted(int mov_id, bool value);
        void UpdateChanged(int mov_id, DateTime value);
        void UpdateUserId(int mov_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration