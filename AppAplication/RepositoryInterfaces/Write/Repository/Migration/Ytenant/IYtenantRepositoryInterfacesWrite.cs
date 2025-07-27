using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYtenantWriteRepository
    {
        void Insert(IYtenantEntity ytenant);
        void Update(IYtenantEntity ytenant);
        void Delete(IYtenantEntity ytenant);
        public void UpdateCnpjCpf(IYtenantEntity entity);
        public void UpdateNome(IYtenantEntity entity);
        public void UpdateUserId(IYtenantEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration