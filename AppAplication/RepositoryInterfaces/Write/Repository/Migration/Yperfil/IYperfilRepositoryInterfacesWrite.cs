using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYperfilWriteRepository
    {
        void Insert(IYperfilEntity yperfil);
        void Update(IYperfilEntity yperfil);
        void Delete(IYperfilEntity yperfil);
        public void UpdateDescription(IYperfilEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration