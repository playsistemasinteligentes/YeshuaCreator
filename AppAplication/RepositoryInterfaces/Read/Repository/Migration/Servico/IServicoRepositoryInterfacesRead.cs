using Repositorio.Outputs.DTOs.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Servico
{
    public interface IServicoReadRepository
    {
        public IEnumerable<ServicoReadDTO> getServico(object command);
        public ServicoDTO getById();
        public IEnumerable<ServicoDTO> getServicoReadFKGrupoServicoId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration