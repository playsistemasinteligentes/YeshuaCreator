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
        void UpdateGMA_ID(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateROT_PECAS_POR_PULSO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_PRIORIDADE_INFORMADA(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_ACAO(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateROT_PERFORMANCE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_TEMPO_SETUP(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_TEMPO_SETUP_AJUSTE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_VA_PARA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        void UpdateROT_STATUS(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateROT_HIERARQUIA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_AVALIA_CUSTO(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        void UpdateROT_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateROT_EXCECAO_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        void UpdateROT_LINHA_DIRETA(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        void UpdateTEM_ID(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        void UpdateTenantID(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        void UpdateDeleted(string maq_id, string pro_id, int rot_seq_tranformacao, bool value);
        void UpdateChanged(string maq_id, string pro_id, int rot_seq_tranformacao, DateTime value);
        void UpdateUserId(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration