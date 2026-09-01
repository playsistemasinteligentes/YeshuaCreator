// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IEstruturaCustoReadRepository
    {
        public DataPagination<EstruturaCustoDTO> getEstruturaCusto(ICommandRead command );
        public IEnumerable<EstruturaCustoORD_IDDTO> getEstruturaCustoReadFKORD_ID(object command );
        public IEnumerable<EstruturaCustoTenantIDDTO> getEstruturaCustoReadFKTenantID(object command );
        public IEnumerable<EstruturaCustoUserIdDTO> getEstruturaCustoReadFKUserId(object command );
        public bool ExistsByEST_ID(int value );
        public bool ExistsByITO_ID(int value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByPRO_ID_PRODUTO(string value );
        public bool ExistsByPRO_ID_COMPONENTE(string value );
        public bool ExistsByPRO_TIPO_CUSTO(string value );
        public bool ExistsByPRO_GRUPO_CONTABIL(string value );
        public bool ExistsByEST_ORDEM(int value );
        public bool ExistsByEST_GRUPO(string value );
        public bool ExistsByEST_QUANT(Decimal value );
        public bool ExistsByEST_VALOR_TOTAL(Decimal value );
        public bool ExistsByEST_DATA_BASE(string value );
        public bool ExistsByEST_BASE_PRODUCAO(Decimal value );
        public bool ExistsByEST_NIVEL(Decimal value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EstruturaCustoDTO FirstByEST_ID(int value );
        public EstruturaCustoDTO FirstByITO_ID(int value );
        public EstruturaCustoDTO FirstByORD_ID(string value );
        public EstruturaCustoDTO FirstByPRO_ID(string value );
        public EstruturaCustoDTO FirstByPRO_ID_PRODUTO(string value );
        public EstruturaCustoDTO FirstByPRO_ID_COMPONENTE(string value );
        public EstruturaCustoDTO FirstByPRO_TIPO_CUSTO(string value );
        public EstruturaCustoDTO FirstByPRO_GRUPO_CONTABIL(string value );
        public EstruturaCustoDTO FirstByEST_ORDEM(int value );
        public EstruturaCustoDTO FirstByEST_GRUPO(string value );
        public EstruturaCustoDTO FirstByEST_QUANT(Decimal value );
        public EstruturaCustoDTO FirstByEST_VALOR_TOTAL(Decimal value );
        public EstruturaCustoDTO FirstByEST_DATA_BASE(string value );
        public EstruturaCustoDTO FirstByEST_BASE_PRODUCAO(Decimal value );
        public EstruturaCustoDTO FirstByEST_NIVEL(Decimal value );
        public EstruturaCustoDTO FirstByFPR_SEQ_REPETICAO(int value );
        public EstruturaCustoDTO FirstByTenantID(int value );
        public EstruturaCustoDTO FirstByDeleted(bool value );
        public EstruturaCustoDTO FirstByChanged(DateTime value );
        public EstruturaCustoDTO FirstByUserId(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_ID(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByITO_ID(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByORD_ID(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID_PRODUTO(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID_COMPONENTE(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_TIPO_CUSTO(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_GRUPO_CONTABIL(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_ORDEM(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_GRUPO(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_QUANT(Decimal value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_VALOR_TOTAL(Decimal value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_DATA_BASE(string value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_BASE_PRODUCAO(Decimal value );
        public IEnumerable<EstruturaCustoDTO> GetAllByEST_NIVEL(Decimal value );
        public IEnumerable<EstruturaCustoDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByTenantID(int value );
        public IEnumerable<EstruturaCustoDTO> GetAllByDeleted(bool value );
        public IEnumerable<EstruturaCustoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EstruturaCustoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration