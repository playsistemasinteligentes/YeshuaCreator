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
    public partial interface ICTeSolicitacaoFiscalWriteRepository
    {
        void Insert(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal);
        void Update(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal);
        void Delete(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal);
        void UpdateEntradaOficialId(int id, int value);
        void UpdateRomaneioConsolidadoId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateAmbiente(int id, int value);
        void UpdateUFEmitente(int id, string value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateProdutoFiscal(int id, int value);
        void UpdateTipoCTe(int id, int value);
        void UpdateTipoServico(int id, int value);
        void UpdateModal(int id, int value);
        void UpdateGlobalizado(int id, int value);
        void UpdateUFInicio(int id, string value);
        void UpdateUFFim(int id, string value);
        void UpdateMunicipioInicioCodigoIbge(int id, string value);
        void UpdateMunicipioFimCodigoIbge(int id, string value);
        void UpdateValorServico(int id, Decimal value);
        void UpdateValorCarga(int id, Decimal value);
        void UpdatePreferenciasManifestoJson(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration