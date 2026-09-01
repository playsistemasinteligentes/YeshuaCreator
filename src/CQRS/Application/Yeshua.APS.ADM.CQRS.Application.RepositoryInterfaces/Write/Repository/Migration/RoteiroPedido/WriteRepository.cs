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
    public partial interface IRoteiroPedidoWriteRepository
    {
        void Insert(IRoteiroPedidoEntity roteiropedido);
        void Update(IRoteiroPedidoEntity roteiropedido);
        void Delete(IRoteiroPedidoEntity roteiropedido);
        void UpdateStatusCadastro(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateTipoPlanejamento(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateCalendarioId(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdateHierarquiaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateProximaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdatePerformance(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateTempoSetup(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateTempoSetupAjuste(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdatePecasPorPulso(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdatePrioridadeInformada(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateStatus(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateExcecaoOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateLinhaDireta(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateAvaliaCusto(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdatePercentualInicioPassoAnterior(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateMaquinaLarguraUtil(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateGrupoTipo(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateGrupoPerformanceMetroLinear(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration