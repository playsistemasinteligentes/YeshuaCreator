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
    public partial interface IRevisaoRegistroSessaoWriteRepository
    {
        void Insert(IRevisaoRegistroSessaoEntity revisaoregistrosessao);
        void Update(IRevisaoRegistroSessaoEntity revisaoregistrosessao);
        void Delete(IRevisaoRegistroSessaoEntity revisaoregistrosessao);
        void UpdateSessaoId(int id, int value);
        void UpdateVersao(int id, int value);
        void UpdateAutorUserId(int id, int value);
        void UpdateRevisadoEm(int id, DateTime value);
        void UpdateMotivo(int id, string value);
        void UpdateRegistro(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
        void UpdateOperationalEntityId(int id, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration