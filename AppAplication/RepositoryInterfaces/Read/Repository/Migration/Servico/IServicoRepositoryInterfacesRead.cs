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
    public interface IServicoReadRepository
    {
        public DataPagination<ServicoDTO> getServico(ICommandRead command);
        public ServicoDTO getById();
        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command);
        public bool ExistsById(int value);
        public bool ExistsByGrupoServicoId(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByValor(Decimal value);
        public ServicoDTO FirstById(int value);
        public ServicoDTO FirstByGrupoServicoId(int value);
        public ServicoDTO FirstByNome(string value);
        public ServicoDTO FirstByValor(Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration