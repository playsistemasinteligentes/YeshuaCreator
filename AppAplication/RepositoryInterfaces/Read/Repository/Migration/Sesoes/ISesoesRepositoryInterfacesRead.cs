using Repositorio.Outputs.DTOs.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Sesoes
{
    public interface ISesoesReadRepository
    {
        public IEnumerable<SesoesDTO> getAllSesoes();
        public SesoesDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration