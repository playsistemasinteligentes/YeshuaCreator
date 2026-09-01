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
    public partial interface IItemTestavelWriteRepository
    {
        void Insert(IItemTestavelEntity itemtestavel);
        void Update(IItemTestavelEntity itemtestavel);
        void Delete(IItemTestavelEntity itemtestavel);
        void UpdateITE_ID(int id, int value);
        void UpdateITE_DESCRICAO(int id, string value);
        void UpdateITE_OBS(int id, string value);
        void UpdateITE_NUMERO_DE_TESTES(int id, int value);
        void UpdateITE_CONDICIONAL_DE_AVALIACAO(int id, string value);
        void UpdateITE_VALOR_DA_CONDICIONAL(int id, Decimal value);
        void UpdateITE_VALOR_CALCULADO_DA_CONDICIONAL(int id, string value);
        void UpdateITE_TIPO_AVALIACAO_FINAL(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration