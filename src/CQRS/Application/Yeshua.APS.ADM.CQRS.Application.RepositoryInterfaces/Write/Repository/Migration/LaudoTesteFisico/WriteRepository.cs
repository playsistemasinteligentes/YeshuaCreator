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
    public partial interface ILaudoTesteFisicoWriteRepository
    {
        void Insert(ILaudoTesteFisicoEntity laudotestefisico);
        void Update(ILaudoTesteFisicoEntity laudotestefisico);
        void Delete(ILaudoTesteFisicoEntity laudotestefisico);
        void UpdateLTF_ID(int id, int value);
        void UpdateLTF_EMISSAO(int id, DateTime value);
        void UpdateLTF_VALOR(int id, Decimal value);
        void UpdateLTF_OBS(int id, string value);
        void UpdateLTF_STATUS(int id, string value);
        void UpdateORD_ID(int id, string value);
        void UpdateROT_PRO_ID(int id, string value);
        void UpdateFPR_SEQ_REPETICAO(int id, int value);
        void UpdateUSE_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration