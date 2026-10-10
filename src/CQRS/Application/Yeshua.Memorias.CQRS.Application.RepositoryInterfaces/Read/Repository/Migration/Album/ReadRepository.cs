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
    public partial interface IAlbumReadRepository
    {
        public DataPagination<AlbumDTO> getAlbum(ICommandRead command );
        public IEnumerable<AlbumTenantIDDTO> getAlbumReadFKTenantID(object command );
        public IEnumerable<AlbumUserIdDTO> getAlbumReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTitulo(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByPrivacidade(int value );
        public bool ExistsBySegundosPorFoto(int value );
        public bool ExistsByStatus(int value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public AlbumDTO FirstById(int value );
        public AlbumDTO FirstByTitulo(string value );
        public AlbumDTO FirstByDescricao(string value );
        public AlbumDTO FirstByPrivacidade(int value );
        public AlbumDTO FirstBySegundosPorFoto(int value );
        public AlbumDTO FirstByStatus(int value );
        public AlbumDTO FirstByOperationalEntityId(string value );
        public AlbumDTO FirstByTenantID(int value );
        public AlbumDTO FirstByDeleted(bool value );
        public AlbumDTO FirstByChanged(DateTime value );
        public AlbumDTO FirstByUserId(int value );
        public IEnumerable<AlbumDTO> GetAllById(int value );
        public IEnumerable<AlbumDTO> GetAllByTitulo(string value );
        public IEnumerable<AlbumDTO> GetAllByDescricao(string value );
        public IEnumerable<AlbumDTO> GetAllByPrivacidade(int value );
        public IEnumerable<AlbumDTO> GetAllBySegundosPorFoto(int value );
        public IEnumerable<AlbumDTO> GetAllByStatus(int value );
        public IEnumerable<AlbumDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<AlbumDTO> GetAllByTenantID(int value );
        public IEnumerable<AlbumDTO> GetAllByDeleted(bool value );
        public IEnumerable<AlbumDTO> GetAllByChanged(DateTime value );
        public IEnumerable<AlbumDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration