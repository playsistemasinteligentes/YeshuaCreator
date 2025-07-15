using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IGrupoServicoReadRepository
    {
        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command);
        public GrupoServicoDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByDescricao(string value);
        public GrupoServicoDTO FirstById(int value);
        public GrupoServicoDTO FirstByDescricao(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration