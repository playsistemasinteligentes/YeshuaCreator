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
    public partial interface ITransportadoraReadRepository
    {
        public DataPagination<TransportadoraDTO> getTransportadora(ICommandRead command );
        public IEnumerable<TransportadoraTenantIDDTO> getTransportadoraReadFKTenantID(object command );
        public IEnumerable<TransportadoraUserIdDTO> getTransportadoraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTRA_ID(string value );
        public bool ExistsByTRA_NOME(string value );
        public bool ExistsByTRA_EMAIL(string value );
        public bool ExistsByTRA_RESPONSAVEL(string value );
        public bool ExistsByTRA_FONE(string value );
        public bool ExistsByTRA_ID_INTEGRACAO(string value );
        public bool ExistsByTRA_ID_INTEGRACAO_ERP(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TransportadoraDTO FirstById(int value );
        public TransportadoraDTO FirstByTRA_ID(string value );
        public TransportadoraDTO FirstByTRA_NOME(string value );
        public TransportadoraDTO FirstByTRA_EMAIL(string value );
        public TransportadoraDTO FirstByTRA_RESPONSAVEL(string value );
        public TransportadoraDTO FirstByTRA_FONE(string value );
        public TransportadoraDTO FirstByTRA_ID_INTEGRACAO(string value );
        public TransportadoraDTO FirstByTRA_ID_INTEGRACAO_ERP(string value );
        public TransportadoraDTO FirstByTenantID(int value );
        public TransportadoraDTO FirstByDeleted(bool value );
        public TransportadoraDTO FirstByChanged(DateTime value );
        public TransportadoraDTO FirstByUserId(int value );
        public IEnumerable<TransportadoraDTO> GetAllById(int value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_NOME(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_EMAIL(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_RESPONSAVEL(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_FONE(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID_INTEGRACAO(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTRA_ID_INTEGRACAO_ERP(string value );
        public IEnumerable<TransportadoraDTO> GetAllByTenantID(int value );
        public IEnumerable<TransportadoraDTO> GetAllByDeleted(bool value );
        public IEnumerable<TransportadoraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TransportadoraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration