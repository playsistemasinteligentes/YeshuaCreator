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
    public partial interface ICTeParticipanteSnapshotReadRepository
    {
        public DataPagination<CTeParticipanteSnapshotDTO> getCTeParticipanteSnapshot(ICommandRead command );
        public IEnumerable<CTeParticipanteSnapshotCTeSolicitacaoFiscalIdDTO> getCTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId(object command );
        public IEnumerable<CTeParticipanteSnapshotTenantIDDTO> getCTeParticipanteSnapshotReadFKTenantID(object command );
        public IEnumerable<CTeParticipanteSnapshotUserIdDTO> getCTeParticipanteSnapshotReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCTeSolicitacaoFiscalId(int value );
        public bool ExistsByPapel(string value );
        public bool ExistsByDocumento(string value );
        public bool ExistsByNome(string value );
        public bool ExistsByInscricaoEstadual(string value );
        public bool ExistsByUF(string value );
        public bool ExistsByMunicipioCodigoIbge(string value );
        public bool ExistsByEnderecoJson(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeParticipanteSnapshotDTO FirstById(int value );
        public CTeParticipanteSnapshotDTO FirstByCTeSolicitacaoFiscalId(int value );
        public CTeParticipanteSnapshotDTO FirstByPapel(string value );
        public CTeParticipanteSnapshotDTO FirstByDocumento(string value );
        public CTeParticipanteSnapshotDTO FirstByNome(string value );
        public CTeParticipanteSnapshotDTO FirstByInscricaoEstadual(string value );
        public CTeParticipanteSnapshotDTO FirstByUF(string value );
        public CTeParticipanteSnapshotDTO FirstByMunicipioCodigoIbge(string value );
        public CTeParticipanteSnapshotDTO FirstByEnderecoJson(string value );
        public CTeParticipanteSnapshotDTO FirstByTenantID(int value );
        public CTeParticipanteSnapshotDTO FirstByDeleted(bool value );
        public CTeParticipanteSnapshotDTO FirstByChanged(DateTime value );
        public CTeParticipanteSnapshotDTO FirstByUserId(int value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllById(int value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByCTeSolicitacaoFiscalId(int value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByPapel(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByDocumento(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByNome(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByInscricaoEstadual(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByUF(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByMunicipioCodigoIbge(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByEnderecoJson(string value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeParticipanteSnapshotDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration