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
    public partial interface IMDFeSolicitacaoFiscalWriteRepository
    {
        void Insert(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal);
        void Update(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal);
        void Delete(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal);
        void UpdateCorrelationId(int id, string value);
        void UpdateCargaId(int id, string value);
        void UpdateAmbiente(int id, int value);
        void UpdateUFCarregamento(int id, string value);
        void UpdateUFDescarregamento(int id, string value);
        void UpdatePlacaVeiculo(int id, string value);
        void UpdateCondutorDocumento(int id, string value);
        void UpdateDocumentosOriginariosJson(int id, string value);
        void UpdateTransporteSnapshotJson(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration