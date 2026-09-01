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
        void UpdateMaquinaId(int id, string value);
        void UpdateProdutoId(int id, string value);
        void UpdateSequenciaTransformacao(int id, int value);
        void UpdateGrupoMaquinaId(int id, string value);
        void UpdatePecasPorPulso(int id, Decimal value);
        void UpdatePrioridadeInformada(int id, Decimal value);
        void UpdateAcao(int id, string value);
        void UpdatePerformance(int id, Decimal value);
        void UpdateTempoSetup(int id, Decimal value);
        void UpdateTempoSetupAjuste(int id, Decimal value);
        void UpdateProximaSequenciaTransformacao(int id, int value);
        void UpdateStatus(int id, string value);
        void UpdateHierarquiaSequenciaTransformacao(int id, Decimal value);
        void UpdateAvaliaCusto(int id, int value);
        void UpdateOperacoes(int id, string value);
        void UpdateExcecaoOperacoes(int id, string value);
        void UpdatePercentualInicioPassoAnterior(int id, Decimal value);
        void UpdateLinhaDireta(int id, string value);
        void UpdateTemplateDeTestesId(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration