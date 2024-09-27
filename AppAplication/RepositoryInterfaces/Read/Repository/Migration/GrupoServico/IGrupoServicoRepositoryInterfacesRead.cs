using Repositorio.Outputs.DTOs.GrupoServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.GrupoServico
{
    public interface IGrupoServicoReadRepository
    {
        public IEnumerable<GrupoServicoDTO> getAllGrupoServico();
        public GrupoServicoDTO getById();
    }
}
