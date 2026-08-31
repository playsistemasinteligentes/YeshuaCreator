// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface ICTeTentativaEmissaoReadRepository
    {
        public DataPagination<CTeTentativaEmissaoDTO> getCTeTentativaEmissao(ICommandRead command );
        public IEnumerable<CTeTentativaEmissaoCTeSolicitacaoFiscalIdDTO> getCTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId(object command );
        public IEnumerable<CTeTentativaEmissaoTenantIDDTO> getCTeTentativaEmissaoReadFKTenantID(object command );
        public IEnumerable<CTeTentativaEmissaoUserIdDTO> getCTeTentativaEmissaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCTeSolicitacaoFiscalId(int value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByNumero(int value );
        public bool ExistsBySerie(int value );
        public bool ExistsByTentativa(int value );
        public bool ExistsByXmlAssinadoStorageKey(string value );
        public bool ExistsByXmlProcStorageKey(string value );
        public bool ExistsByXmlHash(string value );
        public bool ExistsByCodigoRetorno(string value );
        public bool ExistsByMensagemRetorno(string value );
        public bool ExistsByProtocoloAutorizacao(string value );
        public bool ExistsByEnviadoEmUtc(DateTime value );
        public bool ExistsByAutorizadoEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeTentativaEmissaoDTO FirstById(int value );
        public CTeTentativaEmissaoDTO FirstByCTeSolicitacaoFiscalId(int value );
        public CTeTentativaEmissaoDTO FirstByChaveAcesso(string value );
        public CTeTentativaEmissaoDTO FirstByNumero(int value );
        public CTeTentativaEmissaoDTO FirstBySerie(int value );
        public CTeTentativaEmissaoDTO FirstByTentativa(int value );
        public CTeTentativaEmissaoDTO FirstByXmlAssinadoStorageKey(string value );
        public CTeTentativaEmissaoDTO FirstByXmlProcStorageKey(string value );
        public CTeTentativaEmissaoDTO FirstByXmlHash(string value );
        public CTeTentativaEmissaoDTO FirstByCodigoRetorno(string value );
        public CTeTentativaEmissaoDTO FirstByMensagemRetorno(string value );
        public CTeTentativaEmissaoDTO FirstByProtocoloAutorizacao(string value );
        public CTeTentativaEmissaoDTO FirstByEnviadoEmUtc(DateTime value );
        public CTeTentativaEmissaoDTO FirstByAutorizadoEmUtc(DateTime value );
        public CTeTentativaEmissaoDTO FirstByStatus(int value );
        public CTeTentativaEmissaoDTO FirstByTenantID(int value );
        public CTeTentativaEmissaoDTO FirstByDeleted(bool value );
        public CTeTentativaEmissaoDTO FirstByChanged(DateTime value );
        public CTeTentativaEmissaoDTO FirstByUserId(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllById(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByCTeSolicitacaoFiscalId(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByNumero(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllBySerie(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByTentativa(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlAssinadoStorageKey(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlProcStorageKey(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByXmlHash(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByCodigoRetorno(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByMensagemRetorno(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByProtocoloAutorizacao(string value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByEnviadoEmUtc(DateTime value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByAutorizadoEmUtc(DateTime value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByStatus(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeTentativaEmissaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration