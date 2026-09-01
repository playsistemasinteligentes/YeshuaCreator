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
    public partial interface ITesteFisicoWriteRepository
    {
        void Insert(ITesteFisicoEntity testefisico);
        void Update(ITesteFisicoEntity testefisico);
        void Delete(ITesteFisicoEntity testefisico);
        void UpdateTES_ID(int id, int value);
        void UpdateITE_ID(int id, int value);
        void UpdateUSR_ID(int id, int value);
        void UpdateTES_NOME_TECNICO(int id, string value);
        void UpdateTES_AMOSTRA(int id, int value);
        void UpdateTES_OP(int id, string value);
        void UpdateTES_VALOR_NUMERICO(int id, Decimal value);
        void UpdateTES_VALOR_DATA(int id, DateTime value);
        void UpdateTES_VALOR_TEXTO(int id, string value);
        void UpdateTES_EMISSAO(int id, DateTime value);
        void UpdateORD_ID(int id, string value);
        void UpdatePRO_ID(int id, string value);
        void UpdateMAQ_ID(int id, string value);
        void UpdateFPR_SEQ_REPETICAO(int id, int value);
        void UpdateFPR_SEQ_TRANFORMACAO(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration