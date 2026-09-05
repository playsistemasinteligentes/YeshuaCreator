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
    public partial interface IDocumentoFiscalWriteRepository
    {
        void Insert(IDocumentoFiscalEntity documentofiscal);
        void Update(IDocumentoFiscalEntity documentofiscal);
        void Delete(IDocumentoFiscalEntity documentofiscal);
        void UpdateCorrelationId(int id, string value);
        void UpdateProdutoFiscal(int id, int value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateSerie(int id, int value);
        void UpdateNumero(int id, int value);
        void UpdateAmbiente(int id, int value);
        void UpdateUFEmitente(int id, string value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateDestinatarioDocumento(int id, string value);
        void UpdateXmlStorageKey(int id, string value);
        void UpdateXmlHash(int id, string value);
        void UpdateProtocoloAutorizacao(int id, string value);
        void UpdateCodigoRetorno(int id, string value);
        void UpdateMensagemRetorno(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration