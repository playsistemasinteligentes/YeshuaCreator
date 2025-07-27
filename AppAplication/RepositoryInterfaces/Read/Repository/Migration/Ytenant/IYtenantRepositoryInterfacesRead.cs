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
    public interface IYtenantReadRepository
    {
        public DataPagination<YtenantDTO> getYtenant(ICommandRead command);
        public YtenantDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByCnpjCpf(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByUserId(int value);
        public YtenantDTO FirstById(int value);
        public YtenantDTO FirstByCnpjCpf(int value);
        public YtenantDTO FirstByNome(string value);
        public YtenantDTO FirstByUserId(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration