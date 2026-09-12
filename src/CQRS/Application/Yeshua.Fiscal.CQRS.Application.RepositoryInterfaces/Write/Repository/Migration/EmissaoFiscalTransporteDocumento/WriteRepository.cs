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
    public partial interface IEmissaoFiscalTransporteDocumentoWriteRepository
    {
        void Insert(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento);
        void Update(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento);
        void Delete(IEmissaoFiscalTransporteDocumentoEntity emissaofiscaltransportedocumento);
        void UpdateEmissaoFiscalTransporteId(int id, int value);
        void UpdateDocumentoFiscalId(int id, int value);
        void UpdateDocumentoFiscalOriginarioId(int id, int value);
        void UpdateNFeProdutoSnapshotId(int id, int value);
        void UpdateProdutoFiscal(int id, int value);
        void UpdatePapel(int id, int value);
        void UpdateTipoEvento(int id, string value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateXmlStorageKey(int id, string value);
        void UpdatePdfStorageKey(int id, string value);
        void UpdateProtocolo(int id, string value);
        void UpdateCodigoRetorno(int id, string value);
        void UpdateMensagemRetorno(int id, string value);
        void UpdateCriadoEmUtc(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration