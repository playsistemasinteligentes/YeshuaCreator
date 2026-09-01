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
    public partial interface ITemposLogisticosWriteRepository
    {
        void Insert(ITemposLogisticosEntity temposlogisticos);
        void Update(ITemposLogisticosEntity temposlogisticos);
        void Delete(ITemposLogisticosEntity temposlogisticos);
        void UpdateTMP_TIPO_TEMPO(int id, string value);
        void UpdateTMP_TIPO_CARGA(int id, string value);
        void UpdateTMP_TEMPO_MEDIO_UNITARIO(int id, Decimal value);
        void UpdateCLI_ID(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration