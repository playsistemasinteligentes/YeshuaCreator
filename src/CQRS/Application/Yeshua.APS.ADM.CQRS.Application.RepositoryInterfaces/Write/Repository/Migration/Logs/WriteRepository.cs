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
    public partial interface ILogsWriteRepository
    {
        void Insert(ILogsEntity logs);
        void Update(ILogsEntity logs);
        void Delete(ILogsEntity logs);
        void UpdateLOG_CHAVE(int id, string value);
        void UpdateLOG_CONTEXTO(int id, string value);
        void UpdateLOG_CONTEUDO(int id, string value);
        void UpdateLOG_ID(int id, int value);
        void UpdateLOG_EMISSAO(int id, DateTime value);
        void UpdateOperationalEntityId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration