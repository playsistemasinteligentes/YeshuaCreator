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
    public partial interface ICTeTentativaEmissaoWriteRepository
    {
        void Insert(ICTeTentativaEmissaoEntity ctetentativaemissao);
        void Update(ICTeTentativaEmissaoEntity ctetentativaemissao);
        void Delete(ICTeTentativaEmissaoEntity ctetentativaemissao);
        void UpdateCTeSolicitacaoFiscalId(int id, int value);
        void UpdateChaveAcesso(int id, string value);
        void UpdateNumero(int id, int value);
        void UpdateSerie(int id, int value);
        void UpdateTentativa(int id, int value);
        void UpdateXmlAssinadoStorageKey(int id, string value);
        void UpdateXmlProcStorageKey(int id, string value);
        void UpdateXmlHash(int id, string value);
        void UpdateCodigoRetorno(int id, string value);
        void UpdateMensagemRetorno(int id, string value);
        void UpdateProtocoloAutorizacao(int id, string value);
        void UpdateEnviadoEmUtc(int id, DateTime value);
        void UpdateAutorizadoEmUtc(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration