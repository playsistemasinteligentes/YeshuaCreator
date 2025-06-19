using Repositorio.Outputs.DTOs.Servico;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Servico
{
    public interface IServicoReadRepository
    {
        public DataPagination<ServicoDTO> getServico(ICommandRead command);
        public ServicoDTO getById();
        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration