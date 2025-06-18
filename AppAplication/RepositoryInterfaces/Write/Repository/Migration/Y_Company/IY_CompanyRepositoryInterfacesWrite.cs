using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Company
{
    public partial interface IY_CompanyWriteRepository
    {
        void Insert(Y_CompanyEntity y_company);
        void Update(Y_CompanyEntity y_company);
        void Delete(Y_CompanyEntity y_company);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration