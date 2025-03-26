using Repositorio.Outputs.DTOs.Yuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Yuser
{
    public interface IYuserReadRepository
    {
        public IEnumerable<YuserDTO> getYuser(object command);
        public YuserDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration