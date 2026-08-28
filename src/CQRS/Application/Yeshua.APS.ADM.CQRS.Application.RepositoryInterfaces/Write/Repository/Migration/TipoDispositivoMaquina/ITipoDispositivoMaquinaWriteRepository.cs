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
    public partial interface ITipoDispositivoMaquinaWriteRepository
    {
        void Insert(ITipoDispositivoMaquinaEntity tipodispositivomaquina);
        void Update(ITipoDispositivoMaquinaEntity tipodispositivomaquina);
        void Delete(ITipoDispositivoMaquinaEntity tipodispositivomaquina);
        void UpdateTDI_ID(int id, string value);
        void UpdateMAQ_ID(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration