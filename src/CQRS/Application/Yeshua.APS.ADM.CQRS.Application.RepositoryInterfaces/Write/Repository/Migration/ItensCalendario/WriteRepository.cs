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
    public partial interface IItensCalendarioWriteRepository
    {
        void Insert(IItensCalendarioEntity itenscalendario);
        void Update(IItensCalendarioEntity itenscalendario);
        void Delete(IItensCalendarioEntity itenscalendario);
        void UpdateICA_DATA_DE(int ica_id, DateTime value);
        void UpdateICA_DATA_ATE(int ica_id, DateTime value);
        void UpdateICA_OBSERVACAO(int ica_id, string value);
        void UpdateICA_TIPO(int ica_id, int value);
        void UpdateURM_ID(int ica_id, string value);
        void UpdateURN_ID(int ica_id, string value);
        void UpdateCAL_ID(int ica_id, int value);
        void UpdateMAQ_ID(int ica_id, string value);
        void UpdatePRO_ID(int ica_id, string value);
        void UpdateICA_LIMPESA_MAQUINA(int ica_id, int value);
        void UpdateTenantID(int ica_id, int value);
        void UpdateDeleted(int ica_id, bool value);
        void UpdateChanged(int ica_id, DateTime value);
        void UpdateUserId(int ica_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration