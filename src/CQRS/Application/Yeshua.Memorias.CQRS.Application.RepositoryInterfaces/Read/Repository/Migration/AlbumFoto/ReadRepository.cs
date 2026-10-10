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
    public partial interface IAlbumFotoReadRepository
    {
        public DataPagination<AlbumFotoDTO> getAlbumFoto(ICommandRead command );
        public IEnumerable<AlbumFotoAlbumIdDTO> getAlbumFotoReadFKAlbumId(object command );
        public IEnumerable<AlbumFotoFotoIdDTO> getAlbumFotoReadFKFotoId(object command );
        public IEnumerable<AlbumFotoTenantIDDTO> getAlbumFotoReadFKTenantID(object command );
        public IEnumerable<AlbumFotoUserIdDTO> getAlbumFotoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByAlbumId(int value );
        public bool ExistsByFotoId(int value );
        public bool ExistsByOrdem(int value );
        public bool ExistsByLegenda(string value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public AlbumFotoDTO FirstById(int value );
        public AlbumFotoDTO FirstByAlbumId(int value );
        public AlbumFotoDTO FirstByFotoId(int value );
        public AlbumFotoDTO FirstByOrdem(int value );
        public AlbumFotoDTO FirstByLegenda(string value );
        public AlbumFotoDTO FirstByOperationalEntityId(string value );
        public AlbumFotoDTO FirstByTenantID(int value );
        public AlbumFotoDTO FirstByDeleted(bool value );
        public AlbumFotoDTO FirstByChanged(DateTime value );
        public AlbumFotoDTO FirstByUserId(int value );
        public IEnumerable<AlbumFotoDTO> GetAllById(int value );
        public IEnumerable<AlbumFotoDTO> GetAllByAlbumId(int value );
        public IEnumerable<AlbumFotoDTO> GetAllByFotoId(int value );
        public IEnumerable<AlbumFotoDTO> GetAllByOrdem(int value );
        public IEnumerable<AlbumFotoDTO> GetAllByLegenda(string value );
        public IEnumerable<AlbumFotoDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<AlbumFotoDTO> GetAllByTenantID(int value );
        public IEnumerable<AlbumFotoDTO> GetAllByDeleted(bool value );
        public IEnumerable<AlbumFotoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<AlbumFotoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration