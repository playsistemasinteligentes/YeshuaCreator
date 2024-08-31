using Repositorio.Outputs.DTOs.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Clinica
{
    public interface IClinicaReadRepositorys
    {
        public IEnumerable<ClincaDTO> getAllClinicas();
        public ClincaDTO getById();

    }
}
