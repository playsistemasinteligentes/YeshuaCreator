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
    public partial interface ITipoTesteWriteRepository
    {
        void Insert(ITipoTesteEntity tipoteste);
        void Update(ITipoTesteEntity tipoteste);
        void Delete(ITipoTesteEntity tipoteste);
        void UpdateTT_ESPECIFICACAO(int tt_id, Decimal value);
        void UpdateTT_ORIGEM_ESPECIFICACAO(int tt_id, string value);
        void UpdateTT_IMPRIME_NO_LAUDO(int tt_id, string value);
        void UpdateTenantID(int tt_id, int value);
        void UpdateDeleted(int tt_id, bool value);
        void UpdateChanged(int tt_id, DateTime value);
        void UpdateUserId(int tt_id, int value);
        void UpdateTT_NOME(int tt_id, string value);
        void UpdateTT_DESC(int tt_id, string value);
        void UpdateTT_TOL_MAIS(int tt_id, Decimal value);
        void UpdateTT_TOL_MENOS(int tt_id, Decimal value);
        void UpdateTT_NORMA(int tt_id, string value);
        void UpdateTT_INICIO_PROCESSO(int tt_id, string value);
        void UpdateTA_ID(int tt_id, int value);
        void UpdateUNI_ID(int tt_id, string value);
        void UpdateTT_N_AMOSTRAS_P_TESTE(int tt_id, int value);
        void UpdateTT_MAX_DEF_CRITICO(int tt_id, int value);
        void UpdateTT_MAX_DEF_GRAVE(int tt_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration