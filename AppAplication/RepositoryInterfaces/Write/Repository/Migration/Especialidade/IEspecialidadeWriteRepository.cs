using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IEspecialidadeWriteRepository
    {
        void Insert(IEspecialidadeEntity especialidade);
        void Update(IEspecialidadeEntity especialidade);
        void Delete(IEspecialidadeEntity especialidade);
        public void UpdateDescricao(IEspecialidadeEntity entity);
        public void UpdateTenantID(IEspecialidadeEntity entity);
        public void UpdateDeleted(IEspecialidadeEntity entity);
        public void UpdateChanged(IEspecialidadeEntity entity);
        public void UpdateUserId(IEspecialidadeEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration