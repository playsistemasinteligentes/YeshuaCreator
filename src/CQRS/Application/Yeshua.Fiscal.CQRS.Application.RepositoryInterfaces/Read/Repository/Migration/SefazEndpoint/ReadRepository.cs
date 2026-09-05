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
    public partial interface ISefazEndpointReadRepository
    {
        public DataPagination<SefazEndpointDTO> getSefazEndpoint(ICommandRead command );
        public IEnumerable<SefazEndpointTenantIDDTO> getSefazEndpointReadFKTenantID(object command );
        public IEnumerable<SefazEndpointUserIdDTO> getSefazEndpointReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByProdutoFiscal(int value );
        public bool ExistsByUF(string value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByServico(string value );
        public bool ExistsByVersao(string value );
        public bool ExistsByUrl(string value );
        public bool ExistsByAtivo(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public SefazEndpointDTO FirstById(int value );
        public SefazEndpointDTO FirstByProdutoFiscal(int value );
        public SefazEndpointDTO FirstByUF(string value );
        public SefazEndpointDTO FirstByAmbiente(int value );
        public SefazEndpointDTO FirstByServico(string value );
        public SefazEndpointDTO FirstByVersao(string value );
        public SefazEndpointDTO FirstByUrl(string value );
        public SefazEndpointDTO FirstByAtivo(int value );
        public SefazEndpointDTO FirstByTenantID(int value );
        public SefazEndpointDTO FirstByDeleted(bool value );
        public SefazEndpointDTO FirstByChanged(DateTime value );
        public SefazEndpointDTO FirstByUserId(int value );
        public IEnumerable<SefazEndpointDTO> GetAllById(int value );
        public IEnumerable<SefazEndpointDTO> GetAllByProdutoFiscal(int value );
        public IEnumerable<SefazEndpointDTO> GetAllByUF(string value );
        public IEnumerable<SefazEndpointDTO> GetAllByAmbiente(int value );
        public IEnumerable<SefazEndpointDTO> GetAllByServico(string value );
        public IEnumerable<SefazEndpointDTO> GetAllByVersao(string value );
        public IEnumerable<SefazEndpointDTO> GetAllByUrl(string value );
        public IEnumerable<SefazEndpointDTO> GetAllByAtivo(int value );
        public IEnumerable<SefazEndpointDTO> GetAllByTenantID(int value );
        public IEnumerable<SefazEndpointDTO> GetAllByDeleted(bool value );
        public IEnumerable<SefazEndpointDTO> GetAllByChanged(DateTime value );
        public IEnumerable<SefazEndpointDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration