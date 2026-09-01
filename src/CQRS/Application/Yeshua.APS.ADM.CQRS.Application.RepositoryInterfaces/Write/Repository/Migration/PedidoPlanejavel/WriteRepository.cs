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
    public partial interface IPedidoPlanejavelWriteRepository
    {
        void Insert(IPedidoPlanejavelEntity pedidoplanejavel);
        void Update(IPedidoPlanejavelEntity pedidoplanejavel);
        void Delete(IPedidoPlanejavelEntity pedidoplanejavel);
        void UpdateClienteId(string pedidoid, string value);
        void UpdateClienteNome(string pedidoid, string value);
        void UpdateEstado(string pedidoid, string value);
        void UpdateMunicipio(string pedidoid, string value);
        void UpdateRegiao(string pedidoid, string value);
        void UpdateBairro(string pedidoid, string value);
        void UpdateRotaId(string pedidoid, string value);
        void UpdateEmbarqueAlvo(string pedidoid, DateTime value);
        void UpdateDataEntregaDe(string pedidoid, DateTime value);
        void UpdateDataEntregaAte(string pedidoid, DateTime value);
        void UpdatePeso(string pedidoid, Decimal value);
        void UpdateVolume(string pedidoid, Decimal value);
        void UpdateSaldoAExpedir(string pedidoid, Decimal value);
        void UpdateStatus(string pedidoid, string value);
        void UpdateCargaAtualId(string pedidoid, string value);
        void UpdateVersaoPlanejamento(string pedidoid, string value);
        void UpdateAlertasResumo(string pedidoid, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration