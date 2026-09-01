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
    public partial interface IRecursosWriteRepository
    {
        void Insert(IRecursosEntity recursos);
        void Update(IRecursosEntity recursos);
        void Delete(IRecursosEntity recursos);
        void UpdateREC_DESCRICAO(string rec_id, string value);
        void UpdateCAL_ID(string rec_id, int value);
        void UpdateREC_CONTROL_IP(string rec_id, string value);
        void UpdateGRE_ID(string rec_id, string value);
        void UpdateTenantID(string rec_id, int value);
        void UpdateDeleted(string rec_id, bool value);
        void UpdateChanged(string rec_id, DateTime value);
        void UpdateUserId(string rec_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration