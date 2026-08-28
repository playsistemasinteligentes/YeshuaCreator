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
    public partial interface IEtiquetaReadRepository
    {
        public DataPagination<EtiquetaDTO> getEtiqueta(ICommandRead command );
        public IEnumerable<EtiquetaUSE_IDDTO> getEtiquetaReadFKUSE_ID(object command );
        public IEnumerable<EtiquetaORD_IDDTO> getEtiquetaReadFKORD_ID(object command );
        public IEnumerable<EtiquetaTenantIDDTO> getEtiquetaReadFKTenantID(object command );
        public IEnumerable<EtiquetaUserIdDTO> getEtiquetaReadFKUserId(object command );
        public bool ExistsByETI_ID(int value );
        public bool ExistsByETI_EMISSAO(DateTime value );
        public bool ExistsByETI_CODIGO_BARRAS(string value );
        public bool ExistsByETI_SEQUENCIA(int value );
        public bool ExistsByETI_NUMERO_COPIAS(int value );
        public bool ExistsByETI_STATUS(string value );
        public bool ExistsByETI_DATA_FABRICACAO(DateTime value );
        public bool ExistsByETI_COD_BARRAS_ORIGINAL(string value );
        public bool ExistsByETI_OP_ORIGINAL(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByIMP_ID(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByROT_PRO_ID(string value );
        public bool ExistsByROT_SEQ_TRANFORMACAO(int value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByETI_QUANTIDADE_PALETE(Decimal value );
        public bool ExistsByETI_LOTE(string value );
        public bool ExistsByETI_SUB_LOTE(string value );
        public bool ExistsByETI_IMPRIMIR_DE(int value );
        public bool ExistsByETI_IMPRIMIR_ATE(int value );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByCOR_SEQUENCIA(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EtiquetaDTO FirstByETI_ID(int value );
        public EtiquetaDTO FirstByETI_EMISSAO(DateTime value );
        public EtiquetaDTO FirstByETI_CODIGO_BARRAS(string value );
        public EtiquetaDTO FirstByETI_SEQUENCIA(int value );
        public EtiquetaDTO FirstByETI_NUMERO_COPIAS(int value );
        public EtiquetaDTO FirstByETI_STATUS(string value );
        public EtiquetaDTO FirstByETI_DATA_FABRICACAO(DateTime value );
        public EtiquetaDTO FirstByETI_COD_BARRAS_ORIGINAL(string value );
        public EtiquetaDTO FirstByETI_OP_ORIGINAL(string value );
        public EtiquetaDTO FirstByMAQ_ID(string value );
        public EtiquetaDTO FirstByIMP_ID(int value );
        public EtiquetaDTO FirstByUSE_ID(int value );
        public EtiquetaDTO FirstByORD_ID(string value );
        public EtiquetaDTO FirstByROT_PRO_ID(string value );
        public EtiquetaDTO FirstByROT_SEQ_TRANFORMACAO(int value );
        public EtiquetaDTO FirstByFPR_SEQ_REPETICAO(int value );
        public EtiquetaDTO FirstByETI_QUANTIDADE_PALETE(Decimal value );
        public EtiquetaDTO FirstByETI_LOTE(string value );
        public EtiquetaDTO FirstByETI_SUB_LOTE(string value );
        public EtiquetaDTO FirstByETI_IMPRIMIR_DE(int value );
        public EtiquetaDTO FirstByETI_IMPRIMIR_ATE(int value );
        public EtiquetaDTO FirstByBOL_ID(string value );
        public EtiquetaDTO FirstByCOR_SEQUENCIA(int value );
        public EtiquetaDTO FirstByTenantID(int value );
        public EtiquetaDTO FirstByDeleted(bool value );
        public EtiquetaDTO FirstByChanged(DateTime value );
        public EtiquetaDTO FirstByUserId(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_ID(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_EMISSAO(DateTime value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_CODIGO_BARRAS(string value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_SEQUENCIA(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_NUMERO_COPIAS(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_STATUS(string value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_DATA_FABRICACAO(DateTime value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_COD_BARRAS_ORIGINAL(string value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_OP_ORIGINAL(string value );
        public IEnumerable<EtiquetaDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<EtiquetaDTO> GetAllByIMP_ID(int value );
        public IEnumerable<EtiquetaDTO> GetAllByUSE_ID(int value );
        public IEnumerable<EtiquetaDTO> GetAllByORD_ID(string value );
        public IEnumerable<EtiquetaDTO> GetAllByROT_PRO_ID(string value );
        public IEnumerable<EtiquetaDTO> GetAllByROT_SEQ_TRANFORMACAO(int value );
        public IEnumerable<EtiquetaDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_QUANTIDADE_PALETE(Decimal value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_LOTE(string value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_SUB_LOTE(string value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_IMPRIMIR_DE(int value );
        public IEnumerable<EtiquetaDTO> GetAllByETI_IMPRIMIR_ATE(int value );
        public IEnumerable<EtiquetaDTO> GetAllByBOL_ID(string value );
        public IEnumerable<EtiquetaDTO> GetAllByCOR_SEQUENCIA(int value );
        public IEnumerable<EtiquetaDTO> GetAllByTenantID(int value );
        public IEnumerable<EtiquetaDTO> GetAllByDeleted(bool value );
        public IEnumerable<EtiquetaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EtiquetaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration