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
    public interface IYconfigArctetureReadRepository
    {
        public DataPagination<YconfigArctetureDTO> getYconfigArcteture(ICommandRead command);
        public YconfigArctetureDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByAuditTrackerActived(int value);
        public bool ExistsByAuditCRUDActived(int value);
        public YconfigArctetureDTO FirstById(int value);
        public YconfigArctetureDTO FirstByAuditTrackerActived(int value);
        public YconfigArctetureDTO FirstByAuditCRUDActived(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration