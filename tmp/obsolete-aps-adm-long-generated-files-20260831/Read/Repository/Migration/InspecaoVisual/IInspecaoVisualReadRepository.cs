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
    public partial interface IInspecaoVisualReadRepository
    {
        public DataPagination<InspecaoVisualDTO> getInspecaoVisual(ICommandRead command );
        public IEnumerable<InspecaoVisualTURN_IDDTO> getInspecaoVisualReadFKTURN_ID(object command );
        public IEnumerable<InspecaoVisualTURM_IDDTO> getInspecaoVisualReadFKTURM_ID(object command );
        public IEnumerable<InspecaoVisualTenantIDDTO> getInspecaoVisualReadFKTenantID(object command );
        public IEnumerable<InspecaoVisualUserIdDTO> getInspecaoVisualReadFKUserId(object command );
        public bool ExistsByIPV_ID(int value );
        public bool ExistsByIPV_VALOR(string value );
        public bool ExistsByIPV_ID_OPERADOR(int value );
        public bool ExistsByIPV_ID_LIBERACAO(int value );
        public bool ExistsByIPV_OBS(string value );
        public bool ExistsByIPV_DATA_COLETA(DateTime value );
        public bool ExistsByIPV_DATA_AVAL(DateTime value );
        public bool ExistsByTIV_ID(int value );
        public bool ExistsByTURN_ID(string value );
        public bool ExistsByTURM_ID(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByROT_PRO_ID(string value );
        public bool ExistsByROT_MAQ_ID(string value );
        public bool ExistsByROT_SEQ_TRANSFORMACAO(int value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByIPV_STATUS_LIBERACAO(string value );
        public bool ExistsByIPV_VALOR_MEDIDA(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public InspecaoVisualDTO FirstByIPV_ID(int value );
        public InspecaoVisualDTO FirstByIPV_VALOR(string value );
        public InspecaoVisualDTO FirstByIPV_ID_OPERADOR(int value );
        public InspecaoVisualDTO FirstByIPV_ID_LIBERACAO(int value );
        public InspecaoVisualDTO FirstByIPV_OBS(string value );
        public InspecaoVisualDTO FirstByIPV_DATA_COLETA(DateTime value );
        public InspecaoVisualDTO FirstByIPV_DATA_AVAL(DateTime value );
        public InspecaoVisualDTO FirstByTIV_ID(int value );
        public InspecaoVisualDTO FirstByTURN_ID(string value );
        public InspecaoVisualDTO FirstByTURM_ID(string value );
        public InspecaoVisualDTO FirstByORD_ID(string value );
        public InspecaoVisualDTO FirstByROT_PRO_ID(string value );
        public InspecaoVisualDTO FirstByROT_MAQ_ID(string value );
        public InspecaoVisualDTO FirstByROT_SEQ_TRANSFORMACAO(int value );
        public InspecaoVisualDTO FirstByFPR_SEQ_REPETICAO(int value );
        public InspecaoVisualDTO FirstByIPV_STATUS_LIBERACAO(string value );
        public InspecaoVisualDTO FirstByIPV_VALOR_MEDIDA(Decimal value );
        public InspecaoVisualDTO FirstByTenantID(int value );
        public InspecaoVisualDTO FirstByDeleted(bool value );
        public InspecaoVisualDTO FirstByChanged(DateTime value );
        public InspecaoVisualDTO FirstByUserId(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_VALOR(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID_OPERADOR(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_ID_LIBERACAO(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_OBS(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_DATA_COLETA(DateTime value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_DATA_AVAL(DateTime value );
        public IEnumerable<InspecaoVisualDTO> GetAllByTIV_ID(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByTURN_ID(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByTURM_ID(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByORD_ID(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByROT_PRO_ID(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByROT_MAQ_ID(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByROT_SEQ_TRANSFORMACAO(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_STATUS_LIBERACAO(string value );
        public IEnumerable<InspecaoVisualDTO> GetAllByIPV_VALOR_MEDIDA(Decimal value );
        public IEnumerable<InspecaoVisualDTO> GetAllByTenantID(int value );
        public IEnumerable<InspecaoVisualDTO> GetAllByDeleted(bool value );
        public IEnumerable<InspecaoVisualDTO> GetAllByChanged(DateTime value );
        public IEnumerable<InspecaoVisualDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration