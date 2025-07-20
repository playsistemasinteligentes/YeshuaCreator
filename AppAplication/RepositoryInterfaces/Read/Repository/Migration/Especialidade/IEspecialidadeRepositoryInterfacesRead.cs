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
    public interface IEspecialidadeReadRepository
    {
        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command);
        public EspecialidadeDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByDescricao(string value);
        public EspecialidadeDTO FirstById(int value);
        public EspecialidadeDTO FirstByDescricao(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration