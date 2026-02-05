using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IPlanoContaWriteRepository
    {
        void Insert(IPlanoContaEntity planoconta);
        void Update(IPlanoContaEntity planoconta);
        void Delete(IPlanoContaEntity planoconta);
        public void UpdateCodigo(IPlanoContaEntity entity);
        public void UpdateNome(IPlanoContaEntity entity);
        public void UpdateTipo(IPlanoContaEntity entity);
        public void UpdateTenantID(IPlanoContaEntity entity);
        public void UpdateDeleted(IPlanoContaEntity entity);
        public void UpdateChanged(IPlanoContaEntity entity);
        public void UpdateUserId(IPlanoContaEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration