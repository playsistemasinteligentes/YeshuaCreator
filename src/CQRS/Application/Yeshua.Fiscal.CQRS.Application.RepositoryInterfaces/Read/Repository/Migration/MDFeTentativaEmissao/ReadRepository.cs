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
    public partial interface IMDFeTentativaEmissaoReadRepository
    {
        public DataPagination<MDFeTentativaEmissaoDTO> getMDFeTentativaEmissao(ICommandRead command );
        public IEnumerable<MDFeTentativaEmissaoMDFeSolicitacaoFiscalIdDTO> getMDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId(object command );
        public IEnumerable<MDFeTentativaEmissaoTenantIDDTO> getMDFeTentativaEmissaoReadFKTenantID(object command );
        public IEnumerable<MDFeTentativaEmissaoUserIdDTO> getMDFeTentativaEmissaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeSolicitacaoFiscalId(int value );
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
        public MDFeTentativaEmissaoDTO FirstById(int value );
        public MDFeTentativaEmissaoDTO FirstByMDFeSolicitacaoFiscalId(int value );
        public MDFeTentativaEmissaoDTO FirstByChaveAcesso(string value );
        public MDFeTentativaEmissaoDTO FirstByNumero(int value );
        public MDFeTentativaEmissaoDTO FirstBySerie(int value );
        public MDFeTentativaEmissaoDTO FirstByTentativa(int value );
        public MDFeTentativaEmissaoDTO FirstByXmlAssinadoStorageKey(string value );
        public MDFeTentativaEmissaoDTO FirstByXmlProcStorageKey(string value );
        public MDFeTentativaEmissaoDTO FirstByXmlHash(string value );
        public MDFeTentativaEmissaoDTO FirstByCodigoRetorno(string value );
        public MDFeTentativaEmissaoDTO FirstByMensagemRetorno(string value );
        public MDFeTentativaEmissaoDTO FirstByProtocoloAutorizacao(string value );
        public MDFeTentativaEmissaoDTO FirstByEnviadoEmUtc(DateTime value );
        public MDFeTentativaEmissaoDTO FirstByAutorizadoEmUtc(DateTime value );
        public MDFeTentativaEmissaoDTO FirstByStatus(int value );
        public MDFeTentativaEmissaoDTO FirstByTenantID(int value );
        public MDFeTentativaEmissaoDTO FirstByDeleted(bool value );
        public MDFeTentativaEmissaoDTO FirstByChanged(DateTime value );
        public MDFeTentativaEmissaoDTO FirstByUserId(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllById(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByMDFeSolicitacaoFiscalId(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByNumero(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllBySerie(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByTentativa(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlAssinadoStorageKey(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlProcStorageKey(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByXmlHash(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByCodigoRetorno(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByMensagemRetorno(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByProtocoloAutorizacao(string value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByEnviadoEmUtc(DateTime value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByAutorizadoEmUtc(DateTime value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByStatus(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeTentativaEmissaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration