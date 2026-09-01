// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IOrderTrackWriteRepository
    {
        void Insert(IOrderTrackEntity ordertrack);
        void Update(IOrderTrackEntity ordertrack);
        void Delete(IOrderTrackEntity ordertrack);
        void UpdateOTK_ID(int id, int value);
        void UpdateOTK_SEQUENCIA(int id, Decimal value);
        void UpdateOTK_VERSSAO(int id, int value);
        void UpdateORD_ID(int id, string value);
        void UpdateOTK_EVENTO(int id, string value);
        void UpdateOTK_DATA_NECESSIDADE_DE(int id, DateTime value);
        void UpdateOTK_DATA_NECESSIDADE_ATE(int id, DateTime value);
        void UpdateOTK_DATA_PREVISTA(int id, DateTime value);
        void UpdateOTK_DATA_REALIZADA(int id, DateTime value);
        void UpdateFPR_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration