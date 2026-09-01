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
    public partial interface IObservacoesWriteRepository
    {
        void Insert(IObservacoesEntity observacoes);
        void Update(IObservacoesEntity observacoes);
        void Delete(IObservacoesEntity observacoes);
        void UpdateOBS_TIPO(int obs_id, string value);
        void UpdateOBS_DESCRICAO(int obs_id, string value);
        void UpdateCLI_ID(int obs_id, string value);
        void UpdateMAQ_ID(int obs_id, string value);
        void UpdatePRO_ID(int obs_id, string value);
        void UpdateROT_SEQ_TRANFORMACAO(int obs_id, int value);
        void UpdateOBS_INTEGRACAO(int obs_id, string value);
        void UpdateTenantID(int obs_id, int value);
        void UpdateDeleted(int obs_id, bool value);
        void UpdateChanged(int obs_id, DateTime value);
        void UpdateUserId(int obs_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration