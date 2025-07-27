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
    public interface IYuserPermitionsReadRepository
    {
        public DataPagination<YuserPermitionsDTO> getYuserPermitions(ICommandRead command);
        public YuserPermitionsDTO getById();
        public IEnumerable<YuserPermitionsPermitionsIdDTO> getYuserPermitionsReadFKPermitionsId(object command);
        public IEnumerable<YuserPermitionsUserIdDTO> getYuserPermitionsReadFKUserId(object command);
        public bool ExistsByPermitionsId(string value);
        public bool ExistsByUserId(int value);
        public YuserPermitionsDTO FirstByPermitionsId(string value);
        public YuserPermitionsDTO FirstByUserId(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration