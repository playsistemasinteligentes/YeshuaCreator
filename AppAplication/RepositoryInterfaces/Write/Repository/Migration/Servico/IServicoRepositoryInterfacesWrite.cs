using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Servico
{
    public partial interface IServicoWriteRepository
    {
        void Insert(IServicoEntity servico);
        void Update(IServicoEntity servico);
        void Delete(IServicoEntity servico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration