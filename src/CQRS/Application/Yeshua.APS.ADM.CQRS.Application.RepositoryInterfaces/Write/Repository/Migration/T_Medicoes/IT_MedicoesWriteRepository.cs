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
    public partial interface IT_MedicoesWriteRepository
    {
        void Insert(IT_MedicoesEntity t_medicoes);
        void Update(IT_MedicoesEntity t_medicoes);
        void Delete(IT_MedicoesEntity t_medicoes);
        void UpdateMED_ID(int id, int value);
        void UpdateIND_ID(int id, int value);
        void UpdateMET_ID(int id, int value);
        void UpdateUNI_ID(int id, int value);
        void UpdateMED_DATA(int id, DateTime value);
        void UpdateMED_VALOR(int id, string value);
        void UpdateMED_AC_ANO(int id, string value);
        void UpdateMED_DATAMEDICAO(int id, string value);
        void UpdateMED_PONDERACAO(int id, Decimal value);
        void UpdateDIM_ID(int id, string value);
        void UpdateDIM_DESCRICAO(int id, string value);
        void UpdateDIM_SUBDIMENSAO_ID(int id, string value);
        void UpdateDIM_SUB_DESCRICAO(int id, string value);
        void UpdatePER_ID(int id, string value);
        void UpdatePER_DESCRICAO(int id, string value);
        void UpdateFAT_ID(int id, string value);
        void UpdateFAT_DESCRICAO(int id, string value);
        void UpdateMED_SQL(int id, string value);
        void UpdateDOM_EMPRESA(int id, string value);
        void UpdateDOM_FILIAL(int id, string value);
        void UpdateMED_VALOR_DISPER(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration