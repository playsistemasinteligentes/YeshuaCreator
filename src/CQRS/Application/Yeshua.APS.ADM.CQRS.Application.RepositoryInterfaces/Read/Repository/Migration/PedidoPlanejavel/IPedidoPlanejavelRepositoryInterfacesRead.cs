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
    public partial interface IPedidoPlanejavelReadRepository
    {
        public DataPagination<PedidoPlanejavelDTO> getPedidoPlanejavel(ICommandRead command );
        public bool ExistsByPedidoId(string value );
        public bool ExistsByClienteId(string value );
        public bool ExistsByClienteNome(string value );
        public bool ExistsByEstado(string value );
        public bool ExistsByMunicipio(string value );
        public bool ExistsByRegiao(string value );
        public bool ExistsByBairro(string value );
        public bool ExistsByRotaId(string value );
        public bool ExistsByEmbarqueAlvo(DateTime value );
        public bool ExistsByDataEntregaDe(DateTime value );
        public bool ExistsByDataEntregaAte(DateTime value );
        public bool ExistsByPeso(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsBySaldoAExpedir(Decimal value );
        public bool ExistsByStatus(string value );
        public bool ExistsByCargaAtualId(string value );
        public bool ExistsByVersaoPlanejamento(string value );
        public bool ExistsByAlertasResumo(string value );
        public PedidoPlanejavelDTO FirstByPedidoId(string value );
        public PedidoPlanejavelDTO FirstByClienteId(string value );
        public PedidoPlanejavelDTO FirstByClienteNome(string value );
        public PedidoPlanejavelDTO FirstByEstado(string value );
        public PedidoPlanejavelDTO FirstByMunicipio(string value );
        public PedidoPlanejavelDTO FirstByRegiao(string value );
        public PedidoPlanejavelDTO FirstByBairro(string value );
        public PedidoPlanejavelDTO FirstByRotaId(string value );
        public PedidoPlanejavelDTO FirstByEmbarqueAlvo(DateTime value );
        public PedidoPlanejavelDTO FirstByDataEntregaDe(DateTime value );
        public PedidoPlanejavelDTO FirstByDataEntregaAte(DateTime value );
        public PedidoPlanejavelDTO FirstByPeso(Decimal value );
        public PedidoPlanejavelDTO FirstByVolume(Decimal value );
        public PedidoPlanejavelDTO FirstBySaldoAExpedir(Decimal value );
        public PedidoPlanejavelDTO FirstByStatus(string value );
        public PedidoPlanejavelDTO FirstByCargaAtualId(string value );
        public PedidoPlanejavelDTO FirstByVersaoPlanejamento(string value );
        public PedidoPlanejavelDTO FirstByAlertasResumo(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByPedidoId(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByClienteId(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByClienteNome(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByEstado(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByMunicipio(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByRegiao(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByBairro(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByRotaId(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByEmbarqueAlvo(DateTime value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByDataEntregaDe(DateTime value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByDataEntregaAte(DateTime value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByPeso(Decimal value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByVolume(Decimal value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllBySaldoAExpedir(Decimal value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByStatus(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByCargaAtualId(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByVersaoPlanejamento(string value );
        public IEnumerable<PedidoPlanejavelDTO> GetAllByAlertasResumo(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration