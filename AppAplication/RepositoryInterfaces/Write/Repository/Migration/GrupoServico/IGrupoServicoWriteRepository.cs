using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IGrupoServicoWriteRepository
    {
        void Insert(IGrupoServicoEntity gruposervico);
        void Update(IGrupoServicoEntity gruposervico);
        void Delete(IGrupoServicoEntity gruposervico);
        void UpdateDescricao(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration