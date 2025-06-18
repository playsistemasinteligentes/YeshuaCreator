using Repositorio.Outputs.DTOs.GrupoServico;

namespace RepositoryInterfaces.Read.Repository.GrupoServico
{
    public interface IGrupoServicoReadRepository
    {
        public IEnumerable<GrupoServicoDTO> getGrupoServico(object command);
        public GrupoServicoDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration