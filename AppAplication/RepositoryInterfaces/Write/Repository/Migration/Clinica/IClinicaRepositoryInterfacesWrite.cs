using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Clinica
{
    public partial interface IClinicaWriteRepository
    {
        void Insert(ClinicaEntity clinica);
        void Update(ClinicaEntity clinica);
        void Delete(ClinicaEntity clinica);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration