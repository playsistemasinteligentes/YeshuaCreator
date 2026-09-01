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
    public partial interface ITabelaWriteRepository
    {
        void Insert(ITabelaEntity tabela);
        void Update(ITabelaEntity tabela);
        void Delete(ITabelaEntity tabela);
        void UpdateCODIGO(int id_tabela, string value);
        void UpdateNOME(int id_tabela, string value);
        void UpdateTenantID(int id_tabela, int value);
        void UpdateDeleted(int id_tabela, bool value);
        void UpdateChanged(int id_tabela, DateTime value);
        void UpdateUserId(int id_tabela, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration