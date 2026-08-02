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
    public partial interface IGrupoServicoReadRepository
    {
        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command );
        public IEnumerable<GrupoServicoTenantIDDTO> getGrupoServicoReadFKTenantID(object command );
        public IEnumerable<GrupoServicoUserIdDTO> getGrupoServicoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoServicoDTO FirstById(int value );
        public GrupoServicoDTO FirstByDescricao(string value );
        public GrupoServicoDTO FirstByTenantID(int value );
        public GrupoServicoDTO FirstByDeleted(bool value );
        public GrupoServicoDTO FirstByChanged(DateTime value );
        public GrupoServicoDTO FirstByUserId(int value );
        public IEnumerable<GrupoServicoDTO> GetAllById(int value );
        public IEnumerable<GrupoServicoDTO> GetAllByDescricao(string value );
        public IEnumerable<GrupoServicoDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoServicoDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoServicoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoServicoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration