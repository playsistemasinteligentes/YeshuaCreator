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
        public DataPagination<ClinicaDTO> getClinica(ICommandRead command);
        public ClinicaDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByEndereco(string value);
        public bool ExistsByTelefone(string value);
        public ClinicaDTO FirstById(int value);
        public ClinicaDTO FirstByNome(string value);
        public ClinicaDTO FirstByEndereco(string value);
        public ClinicaDTO FirstByTelefone(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration