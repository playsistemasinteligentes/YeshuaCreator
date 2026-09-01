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
    public partial interface IAuditoriaReadRepository
    {
        public DataPagination<AuditoriaDTO> getAuditoria(ICommandRead command );
        public IEnumerable<AuditoriaUSE_IDDTO> getAuditoriaReadFKUSE_ID(object command );
        public IEnumerable<AuditoriaTenantIDDTO> getAuditoriaReadFKTenantID(object command );
        public IEnumerable<AuditoriaUserIdDTO> getAuditoriaReadFKUserId(object command );
        public bool ExistsByID(int value );
        public bool ExistsByDATA(DateTime value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByROTINA(string value );
        public bool ExistsByHISTORICO(string value );
        public bool ExistsByCHAVE(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public AuditoriaDTO FirstByID(int value );
        public AuditoriaDTO FirstByDATA(DateTime value );
        public AuditoriaDTO FirstByUSE_ID(int value );
        public AuditoriaDTO FirstByROTINA(string value );
        public AuditoriaDTO FirstByHISTORICO(string value );
        public AuditoriaDTO FirstByCHAVE(string value );
        public AuditoriaDTO FirstByTenantID(int value );
        public AuditoriaDTO FirstByDeleted(bool value );
        public AuditoriaDTO FirstByChanged(DateTime value );
        public AuditoriaDTO FirstByUserId(int value );
        public IEnumerable<AuditoriaDTO> GetAllByID(int value );
        public IEnumerable<AuditoriaDTO> GetAllByDATA(DateTime value );
        public IEnumerable<AuditoriaDTO> GetAllByUSE_ID(int value );
        public IEnumerable<AuditoriaDTO> GetAllByROTINA(string value );
        public IEnumerable<AuditoriaDTO> GetAllByHISTORICO(string value );
        public IEnumerable<AuditoriaDTO> GetAllByCHAVE(string value );
        public IEnumerable<AuditoriaDTO> GetAllByTenantID(int value );
        public IEnumerable<AuditoriaDTO> GetAllByDeleted(bool value );
        public IEnumerable<AuditoriaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<AuditoriaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration