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
    public partial interface INFeProdutoSnapshotWriteRepository
    {
        void Insert(INFeProdutoSnapshotEntity nfeprodutosnapshot);
        void Update(INFeProdutoSnapshotEntity nfeprodutosnapshot);
        void Delete(INFeProdutoSnapshotEntity nfeprodutosnapshot);
        void UpdateDocumentoFiscalOriginarioId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateCargaId(int id, string value);
        void UpdatePedidoId(int id, string value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateDestinatarioDocumento(int id, string value);
        void UpdateUFOrigem(int id, string value);
        void UpdateUFDestino(int id, string value);
        void UpdateMunicipioOrigemCodigoIbge(int id, string value);
        void UpdateMunicipioDestinoCodigoIbge(int id, string value);
        void UpdateValorDocumento(int id, Decimal value);
        void UpdatePesoBruto(int id, Decimal value);
        void UpdateVolume(int id, Decimal value);
        void UpdateXmlStorageKey(int id, string value);
        void UpdateSnapshotJson(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration