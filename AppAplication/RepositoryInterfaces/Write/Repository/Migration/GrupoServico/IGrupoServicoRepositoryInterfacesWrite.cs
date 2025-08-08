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
        public void UpdateDescricao(IGrupoServicoEntity entity);
        public void UpdateTenantID(IGrupoServicoEntity entity);
        public void UpdateDeleted(IGrupoServicoEntity entity);
        public void UpdateChanged(IGrupoServicoEntity entity);
        public void UpdateUserId(IGrupoServicoEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration