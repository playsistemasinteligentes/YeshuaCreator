using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.GrupoServico
{
    public partial interface IGrupoServicoWriteRepository
    {
        void Insert(GrupoServicoEntity gruposervico);
        void Update(GrupoServicoEntity gruposervico);
        void Delete(GrupoServicoEntity gruposervico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration