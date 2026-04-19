using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IProfissionalWriteRepository
    {
        void Insert(IProfissionalEntity profissional);
        void Update(IProfissionalEntity profissional);
        void Delete(IProfissionalEntity profissional);
        public void UpdateNome(IProfissionalEntity entity);
        public void UpdateEspecialidadeId(IProfissionalEntity entity);
        public void UpdateTelefone(IProfissionalEntity entity);
        public void UpdateTenantID(IProfissionalEntity entity);
        public void UpdateDeleted(IProfissionalEntity entity);
        public void UpdateChanged(IProfissionalEntity entity);
        public void UpdateUserId(IProfissionalEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration