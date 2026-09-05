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
    public partial interface IMDFeDocumentoOriginarioWriteRepository
    {
        void Insert(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario);
        void Update(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario);
        void Delete(IMDFeDocumentoOriginarioEntity mdfedocumentooriginario);
        void UpdateMDFeSolicitacaoFiscalId(int id, int value);
        void UpdateDocumentoFiscalOriginarioId(int id, int value);
        void UpdateTipoDocumento(int id, string value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateSnapshotJson(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration