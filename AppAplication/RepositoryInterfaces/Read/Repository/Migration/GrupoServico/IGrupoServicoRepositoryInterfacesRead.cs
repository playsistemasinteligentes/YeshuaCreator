using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.GrupoServico
{
    public interface IGrupoServicoReadRepository
    {
        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command);
        public GrupoServicoDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration