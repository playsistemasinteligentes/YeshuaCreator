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
    public interface IYuserReadRepository
    {
        public DataPagination<YuserDTO> getYuser(ICommandRead command);
        public YuserDTO getById();
        public IEnumerable<YuserTenantIDDTO> getYuserReadFKTenantID(object command);
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByEmail(string value);
        public bool ExistsBySenha(string value);
        public bool ExistsByTenantID(int value);
        public YuserDTO FirstById(int value);
        public YuserDTO FirstByNome(string value);
        public YuserDTO FirstByEmail(string value);
        public YuserDTO FirstBySenha(string value);
        public YuserDTO FirstByTenantID(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration