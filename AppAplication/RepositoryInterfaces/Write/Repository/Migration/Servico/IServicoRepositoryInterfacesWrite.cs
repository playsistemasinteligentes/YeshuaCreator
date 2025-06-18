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
        void Insert(ServicoEntity servico);
        void Update(ServicoEntity servico);
        void Delete(ServicoEntity servico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration