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
    public partial interface IT_FavoritosWriteRepository
    {
        void Insert(IT_FavoritosEntity t_favoritos);
        void Update(IT_FavoritosEntity t_favoritos);
        void Delete(IT_FavoritosEntity t_favoritos);
        void UpdateUSE_ID(int idfavorito, int value);
        void UpdateID_INDICADOR(int idfavorito, int value);
        void UpdateTenantID(int idfavorito, int value);
        void UpdateDeleted(int idfavorito, bool value);
        void UpdateChanged(int idfavorito, DateTime value);
        void UpdateUserId(int idfavorito, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration