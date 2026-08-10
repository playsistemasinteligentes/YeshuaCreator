using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IServicoWriteRepository
    {
        void Insert(IServicoEntity servico);
        void Update(IServicoEntity servico);
        void Delete(IServicoEntity servico);
        void UpdateGrupoServicoId(int id, int value);
        void UpdateNome(int id, string value);
        void UpdateValor(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration