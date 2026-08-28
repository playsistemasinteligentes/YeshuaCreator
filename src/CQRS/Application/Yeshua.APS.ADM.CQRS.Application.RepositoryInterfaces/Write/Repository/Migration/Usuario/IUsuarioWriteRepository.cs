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
    public partial interface IUsuarioWriteRepository
    {
        void Insert(IUsuarioEntity usuario);
        void Update(IUsuarioEntity usuario);
        void Delete(IUsuarioEntity usuario);
        void UpdateUSE_NOME(int use_id, string value);
        void UpdateUSE_EMAIL(int use_id, string value);
        void UpdateUSE_SENHA(int use_id, string value);
        void UpdateTURM_ID(int use_id, string value);
        void UpdateUSE_ATIVO(int use_id, int value);
        void UpdateUSE_CODERP(int use_id, string value);
        void UpdateTenantID(int use_id, int value);
        void UpdateDeleted(int use_id, bool value);
        void UpdateChanged(int use_id, DateTime value);
        void UpdateUserId(int use_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration