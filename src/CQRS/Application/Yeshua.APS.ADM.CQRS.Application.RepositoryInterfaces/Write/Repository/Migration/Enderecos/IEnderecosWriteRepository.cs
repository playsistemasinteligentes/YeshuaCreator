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
    public partial interface IEnderecosWriteRepository
    {
        void Insert(IEnderecosEntity enderecos);
        void Update(IEnderecosEntity enderecos);
        void Delete(IEnderecosEntity enderecos);
        void UpdateEND_GRUPO(string end_id, string value);
        void UpdateTenantID(string end_id, int value);
        void UpdateDeleted(string end_id, bool value);
        void UpdateChanged(string end_id, DateTime value);
        void UpdateUserId(string end_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration