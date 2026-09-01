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
    public partial interface IProtocoloOnduladeiraReadRepository
    {
        public DataPagination<ProtocoloOnduladeiraDTO> getProtocoloOnduladeira(ICommandRead command );
        public IEnumerable<ProtocoloOnduladeiraTenantIDDTO> getProtocoloOnduladeiraReadFKTenantID(object command );
        public IEnumerable<ProtocoloOnduladeiraUserIdDTO> getProtocoloOnduladeiraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPTO_ID(string value );
        public bool ExistsByPTO_CHAVE(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByPTO_COMANDO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ProtocoloOnduladeiraDTO FirstById(int value );
        public ProtocoloOnduladeiraDTO FirstByPTO_ID(string value );
        public ProtocoloOnduladeiraDTO FirstByPTO_CHAVE(string value );
        public ProtocoloOnduladeiraDTO FirstByMAQ_ID(string value );
        public ProtocoloOnduladeiraDTO FirstByPTO_COMANDO(string value );
        public ProtocoloOnduladeiraDTO FirstByTenantID(int value );
        public ProtocoloOnduladeiraDTO FirstByDeleted(bool value );
        public ProtocoloOnduladeiraDTO FirstByChanged(DateTime value );
        public ProtocoloOnduladeiraDTO FirstByUserId(int value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllById(int value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_ID(string value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_CHAVE(string value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByPTO_COMANDO(string value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ProtocoloOnduladeiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration