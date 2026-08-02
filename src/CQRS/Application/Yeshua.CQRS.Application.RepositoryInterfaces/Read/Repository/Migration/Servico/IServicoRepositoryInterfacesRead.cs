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
    public partial interface IServicoReadRepository
    {
        public DataPagination<ServicoDTO> getServico(ICommandRead command );
        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command );
        public IEnumerable<ServicoTenantIDDTO> getServicoReadFKTenantID(object command );
        public IEnumerable<ServicoUserIdDTO> getServicoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByGrupoServicoId(int value );
        public bool ExistsByNome(string value );
        public bool ExistsByValor(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ServicoDTO FirstById(int value );
        public ServicoDTO FirstByGrupoServicoId(int value );
        public ServicoDTO FirstByNome(string value );
        public ServicoDTO FirstByValor(Decimal value );
        public ServicoDTO FirstByTenantID(int value );
        public ServicoDTO FirstByDeleted(bool value );
        public ServicoDTO FirstByChanged(DateTime value );
        public ServicoDTO FirstByUserId(int value );
        public IEnumerable<ServicoDTO> GetAllById(int value );
        public IEnumerable<ServicoDTO> GetAllByGrupoServicoId(int value );
        public IEnumerable<ServicoDTO> GetAllByNome(string value );
        public IEnumerable<ServicoDTO> GetAllByValor(Decimal value );
        public IEnumerable<ServicoDTO> GetAllByTenantID(int value );
        public IEnumerable<ServicoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ServicoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ServicoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration