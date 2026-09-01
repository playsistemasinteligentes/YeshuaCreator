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
    public partial interface IT_IndicadoresWriteRepository
    {
        void Insert(IT_IndicadoresEntity t_indicadores);
        void Update(IT_IndicadoresEntity t_indicadores);
        void Delete(IT_IndicadoresEntity t_indicadores);
        void UpdateIND_DESCRICAO(int ind_id, string value);
        void UpdateNEG_ID(int ind_id, int value);
        void UpdateDESC_CALCULO(int ind_id, string value);
        void UpdateIND_TIPOCOMPARADOR(int ind_id, int value);
        void UpdateIND_GRAFICO(int ind_id, int value);
        void UpdateIND_CONEXAO(int ind_id, string value);
        void UpdateIND_DTCRIACAO(int ind_id, DateTime value);
        void UpdateRESPOSAVELIND(int ind_id, string value);
        void UpdateRESPOSAVELCARGA(int ind_id, string value);
        void UpdatePROCEXTRACAO(int ind_id, string value);
        void UpdatePER_ID(int ind_id, string value);
        void UpdateDIM_ID(int ind_id, string value);
        void UpdateDOM_EMPRESA(int ind_id, string value);
        void UpdateDOM_FILIAL(int ind_id, string value);
        void UpdateTenantID(int ind_id, int value);
        void UpdateDeleted(int ind_id, bool value);
        void UpdateChanged(int ind_id, DateTime value);
        void UpdateUserId(int ind_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration