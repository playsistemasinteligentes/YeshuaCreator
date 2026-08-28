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
    public partial interface IOperacoesWriteRepository
    {
        void Insert(IOperacoesEntity operacoes);
        void Update(IOperacoesEntity operacoes);
        void Delete(IOperacoesEntity operacoes);
        void UpdateOPE_TIPO_REGISTRO(int id, string value);
        void UpdateOPE_ID(int id, string value);
        void UpdateGMA_ID(int id, string value);
        void UpdateMAQ_ID(int id, string value);
        void UpdatePRO_ID(int id, string value);
        void UpdateOPE_EXCECAO(int id, string value);
        void UpdateROT_SEQ_TRANFORMACAO(int id, int value);
        void UpdateORD_ID(int id, string value);
        void UpdateFPR_SEQ_REPETICAO(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration