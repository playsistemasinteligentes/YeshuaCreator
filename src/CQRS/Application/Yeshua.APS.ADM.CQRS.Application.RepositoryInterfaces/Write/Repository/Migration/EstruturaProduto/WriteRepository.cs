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
    public partial interface IEstruturaProdutoWriteRepository
    {
        void Insert(IEstruturaProdutoEntity estruturaproduto);
        void Update(IEstruturaProdutoEntity estruturaproduto);
        void Delete(IEstruturaProdutoEntity estruturaproduto);
        void UpdateEST_DATA_VALIDADE(int id, DateTime value);
        void UpdatePRO_ID_PRODUTO(int id, string value);
        void UpdatePRO_ID_COMPONENTE(int id, string value);
        void UpdateEST_QUANT(int id, Decimal value);
        void UpdateEST_DATA_INCLUSAO(int id, DateTime value);
        void UpdateEST_BASE_PRODUCAO(int id, Decimal value);
        void UpdateEST_TIPO_REQUISICAO(int id, string value);
        void UpdateEST_CODIGO_DE_EXCECAO(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration