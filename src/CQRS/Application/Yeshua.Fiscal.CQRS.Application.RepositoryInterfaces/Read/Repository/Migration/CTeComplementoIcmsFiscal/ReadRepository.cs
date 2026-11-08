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
    public partial interface ICTeComplementoIcmsFiscalReadRepository
    {
        public DataPagination<CTeComplementoIcmsFiscalDTO> getCTeComplementoIcmsFiscal(ICommandRead command );
        public IEnumerable<CTeComplementoIcmsFiscalCTeSolicitacaoFiscalIdDTO> getCTeComplementoIcmsFiscalReadFKCTeSolicitacaoFiscalId(object command );
        public IEnumerable<CTeComplementoIcmsFiscalTenantIDDTO> getCTeComplementoIcmsFiscalReadFKTenantID(object command );
        public IEnumerable<CTeComplementoIcmsFiscalUserIdDTO> getCTeComplementoIcmsFiscalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCTeSolicitacaoFiscalId(int value );
        public bool ExistsByValorPrestacaoComplementar(Decimal value );
        public bool ExistsByCST(string value );
        public bool ExistsByValorBaseCalculo(Decimal value );
        public bool ExistsByAliquotaICMS(Decimal value );
        public bool ExistsByValorICMS(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByOperationalEntityId(string value );
        public CTeComplementoIcmsFiscalDTO FirstById(int value );
        public CTeComplementoIcmsFiscalDTO FirstByCTeSolicitacaoFiscalId(int value );
        public CTeComplementoIcmsFiscalDTO FirstByValorPrestacaoComplementar(Decimal value );
        public CTeComplementoIcmsFiscalDTO FirstByCST(string value );
        public CTeComplementoIcmsFiscalDTO FirstByValorBaseCalculo(Decimal value );
        public CTeComplementoIcmsFiscalDTO FirstByAliquotaICMS(Decimal value );
        public CTeComplementoIcmsFiscalDTO FirstByValorICMS(Decimal value );
        public CTeComplementoIcmsFiscalDTO FirstByTenantID(int value );
        public CTeComplementoIcmsFiscalDTO FirstByDeleted(bool value );
        public CTeComplementoIcmsFiscalDTO FirstByChanged(DateTime value );
        public CTeComplementoIcmsFiscalDTO FirstByUserId(int value );
        public CTeComplementoIcmsFiscalDTO FirstByOperationalEntityId(string value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllById(int value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByCTeSolicitacaoFiscalId(int value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorPrestacaoComplementar(Decimal value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByCST(string value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorBaseCalculo(Decimal value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByAliquotaICMS(Decimal value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByValorICMS(Decimal value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByUserId(int value );
        public IEnumerable<CTeComplementoIcmsFiscalDTO> GetAllByOperationalEntityId(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration