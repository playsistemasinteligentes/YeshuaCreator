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
    public partial interface IT_GrupoWriteRepository
    {
        void Insert(IT_GrupoEntity t_grupo);
        void Update(IT_GrupoEntity t_grupo);
        void Delete(IT_GrupoEntity t_grupo);
        void UpdateNOME(int gru_id, string value);
        void UpdateEXIBELISTA(int gru_id, int value);
        void UpdateGRU_DESCRICAO(int gru_id, string value);
        void UpdateTenantID(int gru_id, int value);
        void UpdateDeleted(int gru_id, bool value);
        void UpdateChanged(int gru_id, DateTime value);
        void UpdateUserId(int gru_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration