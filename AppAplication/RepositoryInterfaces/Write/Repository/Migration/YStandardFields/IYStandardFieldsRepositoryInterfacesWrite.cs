using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYStandardFieldsWriteRepository
    {
        void Insert(IYStandardFieldsEntity ystandardfields);
        void Update(IYStandardFieldsEntity ystandardfields);
        void Delete(IYStandardFieldsEntity ystandardfields);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration