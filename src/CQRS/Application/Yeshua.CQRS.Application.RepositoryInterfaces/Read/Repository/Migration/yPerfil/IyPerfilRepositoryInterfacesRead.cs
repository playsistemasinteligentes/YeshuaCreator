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
    public partial interface IyPerfilReadRepository
    {
        public DataPagination<yPerfilDTO> getyPerfil(ICommandRead command );
        public IEnumerable<yPerfilTenantIDDTO> getyPerfilReadFKTenantID(object command );
        public IEnumerable<yPerfilUserIdDTO> getyPerfilReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDescription(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yPerfilDTO FirstById(int value );
        public yPerfilDTO FirstByDescription(string value );
        public yPerfilDTO FirstByTenantID(int value );
        public yPerfilDTO FirstByDeleted(bool value );
        public yPerfilDTO FirstByChanged(DateTime value );
        public yPerfilDTO FirstByUserId(int value );
        public IEnumerable<yPerfilDTO> GetAllById(int value );
        public IEnumerable<yPerfilDTO> GetAllByDescription(string value );
        public IEnumerable<yPerfilDTO> GetAllByTenantID(int value );
        public IEnumerable<yPerfilDTO> GetAllByDeleted(bool value );
        public IEnumerable<yPerfilDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yPerfilDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration