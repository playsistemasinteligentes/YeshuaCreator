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
    public partial interface IRoteiroWriteRepository
    {
        void Insert(IRoteiroEntity roteiro);
        void Update(IRoteiroEntity roteiro);
        void Delete(IRoteiroEntity roteiro);
        void UpdateGrupoMaquinaId(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdatePecasPorPulso(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdatePrioridadeInformada(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateAcao(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdatePerformance(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateTempoSetup(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateTempoSetupAjuste(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateProximaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdateStatus(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateHierarquiaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateAvaliaCusto(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdateOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateExcecaoOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdatePercentualInicioPassoAnterior(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value);
        void UpdateLinhaDireta(string maquinaid, string produtoid, int sequenciatransformacao, string value);
        void UpdateTemplateDeTestesId(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdateTenantID(string maquinaid, string produtoid, int sequenciatransformacao, int value);
        void UpdateDeleted(string maquinaid, string produtoid, int sequenciatransformacao, bool value);
        void UpdateChanged(string maquinaid, string produtoid, int sequenciatransformacao, DateTime value);
        void UpdateUserId(string maquinaid, string produtoid, int sequenciatransformacao, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration