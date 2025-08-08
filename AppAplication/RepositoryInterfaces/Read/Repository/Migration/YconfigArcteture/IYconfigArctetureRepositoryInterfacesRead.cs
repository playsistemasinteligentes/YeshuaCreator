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
    public interface IyConfigArctetureReadRepository
    {
        public DataPagination<yConfigArctetureDTO> getyConfigArcteture(ICommandRead command );
        public IEnumerable<yConfigArctetureTenantIDDTO> getyConfigArctetureReadFKTenantID(object command );
        public IEnumerable<yConfigArctetureUserIdDTO> getyConfigArctetureReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByAuditTrackerActived(int value );
        public bool ExistsByAuditCRUDActived(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yConfigArctetureDTO FirstById(int value );
        public yConfigArctetureDTO FirstByAuditTrackerActived(int value );
        public yConfigArctetureDTO FirstByAuditCRUDActived(int value );
        public yConfigArctetureDTO FirstByTenantID(int value );
        public yConfigArctetureDTO FirstByDeleted(bool value );
        public yConfigArctetureDTO FirstByChanged(DateTime value );
        public yConfigArctetureDTO FirstByUserId(int value );
        public IEnumerable<yConfigArctetureDTO> GetAllById(int value );
        public IEnumerable<yConfigArctetureDTO> GetAllByAuditTrackerActived(int value );
        public IEnumerable<yConfigArctetureDTO> GetAllByAuditCRUDActived(int value );
        public IEnumerable<yConfigArctetureDTO> GetAllByTenantID(int value );
        public IEnumerable<yConfigArctetureDTO> GetAllByDeleted(bool value );
        public IEnumerable<yConfigArctetureDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yConfigArctetureDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration