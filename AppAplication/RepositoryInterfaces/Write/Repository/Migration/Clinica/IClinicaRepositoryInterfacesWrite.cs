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
        void Insert(IClinicaEntity clinica);
        void Update(IClinicaEntity clinica);
        void Delete(IClinicaEntity clinica);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration