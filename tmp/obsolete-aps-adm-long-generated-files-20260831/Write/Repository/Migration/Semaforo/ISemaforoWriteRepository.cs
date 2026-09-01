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
    public partial interface ISemaforoWriteRepository
    {
        void Insert(ISemaforoEntity semaforo);
        void Update(ISemaforoEntity semaforo);
        void Delete(ISemaforoEntity semaforo);
        void UpdateSEM_ID(int id, string value);
        void UpdateSEM_STATUS(int id, string value);
        void UpdateSEM_ORIGEM(int id, string value);
        void UpdateSEM_EMISSAO(int id, DateTime value);
        void UpdateSEM_ID_CONEXAO(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration