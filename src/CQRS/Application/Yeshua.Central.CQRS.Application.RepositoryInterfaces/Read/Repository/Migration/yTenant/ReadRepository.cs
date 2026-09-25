// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IyTenantReadRepository
    {
        public DataPagination<yTenantDTO> getyTenant(ICommandRead command , bool TakeOffId = false);
        public bool ExistsById(int value , bool TakeOffId = false);
        public bool ExistsByCnpjCpf(string value , bool TakeOffId = false);
        public bool ExistsByNome(string value , bool TakeOffId = false);
        public bool ExistsByUserId(int value , bool TakeOffId = false);
        public bool ExistsByDeleted(bool value , bool TakeOffId = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffId = false);
        public yTenantDTO FirstById(int value , bool TakeOffId = false);
        public yTenantDTO FirstByCnpjCpf(string value , bool TakeOffId = false);
        public yTenantDTO FirstByNome(string value , bool TakeOffId = false);
        public yTenantDTO FirstByUserId(int value , bool TakeOffId = false);
        public yTenantDTO FirstByDeleted(bool value , bool TakeOffId = false);
        public yTenantDTO FirstByChanged(DateTime value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllById(int value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllByCnpjCpf(string value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllByNome(string value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllByUserId(int value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllByDeleted(bool value , bool TakeOffId = false);
        public IEnumerable<yTenantDTO> GetAllByChanged(DateTime value , bool TakeOffId = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration