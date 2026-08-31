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
    public partial interface ICTeSaidaMDFeWriteRepository
    {
        void Insert(ICTeSaidaMDFeEntity ctesaidamdfe);
        void Update(ICTeSaidaMDFeEntity ctesaidamdfe);
        void Delete(ICTeSaidaMDFeEntity ctesaidamdfe);
        void UpdateCTeTentativaEmissaoId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateChaveAcessoCTe(int id, string value);
        void UpdateSnapshotHash(int id, string value);
        void UpdateOutboxMessageId(int id, string value);
        void UpdatePublicadoEmUtc(int id, DateTime value);
        void UpdateUltimoErro(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration