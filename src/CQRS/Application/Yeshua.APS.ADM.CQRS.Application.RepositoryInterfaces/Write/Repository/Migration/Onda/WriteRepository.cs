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
    public partial interface IOndaWriteRepository
    {
        void Insert(IOndaEntity onda);
        void Update(IOndaEntity onda);
        void Delete(IOndaEntity onda);
        void UpdateOND_ESPESSURA(string ond_id, Decimal value);
        void UpdateOND_PESO_COLA(string ond_id, Decimal value);
        void UpdateOND_RENDIMENTO_ONDA_1(string ond_id, Decimal value);
        void UpdateOND_RENDIMENTO_ONDA_2(string ond_id, Decimal value);
        void UpdateOND_PROFUNDIDADE_VINCO(string ond_id, int value);
        void UpdateOND_ID_INTEGRACAO(string ond_id, string value);
        void UpdateVIN_ID(string ond_id, int value);
        void UpdateTenantID(string ond_id, int value);
        void UpdateDeleted(string ond_id, bool value);
        void UpdateChanged(string ond_id, DateTime value);
        void UpdateUserId(string ond_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration