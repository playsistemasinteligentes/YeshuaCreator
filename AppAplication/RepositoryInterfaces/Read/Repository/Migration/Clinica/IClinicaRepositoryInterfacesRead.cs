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
    public interface IClinicaReadRepository
    {
        public DataPagination<ClinicaDTO> getClinica(ICommandRead command );
        public IEnumerable<ClinicaTenantIDDTO> getClinicaReadFKTenantID(object command );
        public IEnumerable<ClinicaUserIdDTO> getClinicaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByNome(string value );
        public bool ExistsByEndereco(string value );
        public bool ExistsByTelefone(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ClinicaDTO FirstById(int value );
        public ClinicaDTO FirstByNome(string value );
        public ClinicaDTO FirstByEndereco(string value );
        public ClinicaDTO FirstByTelefone(string value );
        public ClinicaDTO FirstByTenantID(int value );
        public ClinicaDTO FirstByDeleted(bool value );
        public ClinicaDTO FirstByChanged(DateTime value );
        public ClinicaDTO FirstByUserId(int value );
        public IEnumerable<ClinicaDTO> GetAllById(int value );
        public IEnumerable<ClinicaDTO> GetAllByNome(string value );
        public IEnumerable<ClinicaDTO> GetAllByEndereco(string value );
        public IEnumerable<ClinicaDTO> GetAllByTelefone(string value );
        public IEnumerable<ClinicaDTO> GetAllByTenantID(int value );
        public IEnumerable<ClinicaDTO> GetAllByDeleted(bool value );
        public IEnumerable<ClinicaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ClinicaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration