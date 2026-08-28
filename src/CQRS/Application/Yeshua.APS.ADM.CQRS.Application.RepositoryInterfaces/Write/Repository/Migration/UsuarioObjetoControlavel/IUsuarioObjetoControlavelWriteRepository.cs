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
    public partial interface IUsuarioObjetoControlavelWriteRepository
    {
        void Insert(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel);
        void Update(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel);
        void Delete(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel);
        void UpdateUSE_ID(int id, int value);
        void UpdateOBJ_ID(int id, string value);
        void UpdateUSU_OBJETO_ACAO(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration