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
    public partial interface IT_IndicadoresReadRepository
    {
        public DataPagination<T_IndicadoresDTO> getT_Indicadores(ICommandRead command );
        public IEnumerable<T_IndicadoresNEG_IDDTO> getT_IndicadoresReadFKNEG_ID(object command );
        public IEnumerable<T_IndicadoresTenantIDDTO> getT_IndicadoresReadFKTenantID(object command );
        public IEnumerable<T_IndicadoresUserIdDTO> getT_IndicadoresReadFKUserId(object command );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByIND_DESCRICAO(string value );
        public bool ExistsByNEG_ID(int value );
        public bool ExistsByDESC_CALCULO(string value );
        public bool ExistsByIND_TIPOCOMPARADOR(int value );
        public bool ExistsByIND_GRAFICO(int value );
        public bool ExistsByIND_CONEXAO(string value );
        public bool ExistsByIND_DTCRIACAO(DateTime value );
        public bool ExistsByRESPOSAVELIND(string value );
        public bool ExistsByRESPOSAVELCARGA(string value );
        public bool ExistsByPROCEXTRACAO(string value );
        public bool ExistsByPER_ID(string value );
        public bool ExistsByDIM_ID(string value );
        public bool ExistsByDOM_EMPRESA(string value );
        public bool ExistsByDOM_FILIAL(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_IndicadoresDTO FirstByIND_ID(int value );
        public T_IndicadoresDTO FirstByIND_DESCRICAO(string value );
        public T_IndicadoresDTO FirstByNEG_ID(int value );
        public T_IndicadoresDTO FirstByDESC_CALCULO(string value );
        public T_IndicadoresDTO FirstByIND_TIPOCOMPARADOR(int value );
        public T_IndicadoresDTO FirstByIND_GRAFICO(int value );
        public T_IndicadoresDTO FirstByIND_CONEXAO(string value );
        public T_IndicadoresDTO FirstByIND_DTCRIACAO(DateTime value );
        public T_IndicadoresDTO FirstByRESPOSAVELIND(string value );
        public T_IndicadoresDTO FirstByRESPOSAVELCARGA(string value );
        public T_IndicadoresDTO FirstByPROCEXTRACAO(string value );
        public T_IndicadoresDTO FirstByPER_ID(string value );
        public T_IndicadoresDTO FirstByDIM_ID(string value );
        public T_IndicadoresDTO FirstByDOM_EMPRESA(string value );
        public T_IndicadoresDTO FirstByDOM_FILIAL(string value );
        public T_IndicadoresDTO FirstByTenantID(int value );
        public T_IndicadoresDTO FirstByDeleted(bool value );
        public T_IndicadoresDTO FirstByChanged(DateTime value );
        public T_IndicadoresDTO FirstByUserId(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_ID(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_DESCRICAO(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByNEG_ID(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByDESC_CALCULO(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_TIPOCOMPARADOR(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_GRAFICO(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_CONEXAO(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByIND_DTCRIACAO(DateTime value );
        public IEnumerable<T_IndicadoresDTO> GetAllByRESPOSAVELIND(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByRESPOSAVELCARGA(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByPROCEXTRACAO(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByPER_ID(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByDIM_ID(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByDOM_EMPRESA(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByDOM_FILIAL(string value );
        public IEnumerable<T_IndicadoresDTO> GetAllByTenantID(int value );
        public IEnumerable<T_IndicadoresDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_IndicadoresDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_IndicadoresDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration