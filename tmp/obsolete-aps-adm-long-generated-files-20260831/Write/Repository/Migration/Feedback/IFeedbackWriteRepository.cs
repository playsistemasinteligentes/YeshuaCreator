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
    public partial interface IFeedbackWriteRepository
    {
        void Insert(IFeedbackEntity feedback);
        void Update(IFeedbackEntity feedback);
        void Delete(IFeedbackEntity feedback);
        void UpdateDataInicial(int id, DateTime value);
        void UpdateDatafinal(int id, DateTime value);
        void UpdateMaquinaId(int id, string value);
        void UpdateOcorrenciaId(int id, string value);
        void UpdateTurnoId(int id, string value);
        void UpdateTurmaId(int id, string value);
        void UpdateUsuarioId(int id, int value);
        void UpdateOrderId(int id, string value);
        void UpdateProdutoId(int id, string value);
        void UpdateObservacoes(int id, string value);
        void UpdateGrupo(int id, Decimal value);
        void UpdateDiaTurma(int id, string value);
        void UpdateSequenciaTransformacao(int id, int value);
        void UpdateSequenciaRepeticao(int id, int value);
        void UpdateQuantidadePulsos(int id, Decimal value);
        void UpdateQuantidadePecasPorPulso(int id, Decimal value);
        void UpdateFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(int id, Decimal value);
        void UpdateBOL_ID(int id, string value);
        void UpdateCOR_SEQUENCIA(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration