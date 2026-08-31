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
    public partial interface ICTeDocumentoOriginarioWriteRepository
    {
        void Insert(ICTeDocumentoOriginarioEntity ctedocumentooriginario);
        void Update(ICTeDocumentoOriginarioEntity ctedocumentooriginario);
        void Delete(ICTeDocumentoOriginarioEntity ctedocumentooriginario);
        void UpdateCTeSolicitacaoFiscalId(int id, int value);
        void UpdateTipoDocumento(int id, string value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateNumero(int id, string value);
        void UpdateSerie(int id, string value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateDestinatarioDocumento(int id, string value);
        void UpdateValorDocumento(int id, Decimal value);
        void UpdatePesoBruto(int id, Decimal value);
        void UpdateSnapshotJson(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration