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
    public interface IYuserReadRepository
    {
        public DataPagination<YuserDTO> getYuser(ICommandRead command);
        public YuserDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByEmail(string value);
        public bool ExistsBySenha(string value);
        public YuserDTO FirstById(int value);
        public YuserDTO FirstByNome(string value);
        public YuserDTO FirstByEmail(string value);
        public YuserDTO FirstBySenha(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration