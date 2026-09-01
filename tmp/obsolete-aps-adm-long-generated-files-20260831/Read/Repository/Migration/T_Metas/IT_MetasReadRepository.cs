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
    public partial interface IT_MetasReadRepository
    {
        public DataPagination<T_MetasDTO> getT_Metas(ICommandRead command );
        public IEnumerable<T_MetasIND_IDDTO> getT_MetasReadFKIND_ID(object command );
        public IEnumerable<T_MetasTenantIDDTO> getT_MetasReadFKTenantID(object command );
        public IEnumerable<T_MetasUserIdDTO> getT_MetasReadFKUserId(object command );
        public bool ExistsByMET_ID(int value );
        public bool ExistsByMET_DTINICIO(string value );
        public bool ExistsByMET_DTFIM(string value );
        public bool ExistsByMET_ALVO(string value );
        public bool ExistsByMET_TIPOALVO(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByMET_RANGE01(Decimal value );
        public bool ExistsByMET_RANGE02(Decimal value );
        public bool ExistsByMET_RANGE03(Decimal value );
        public bool ExistsByDIM_ID(int value );
        public bool ExistsByFAT_ID(string value );
        public bool ExistsByDIM_SUBDIMENSAO_ID(string value );
        public bool ExistsByPER_ID(string value );
        public bool ExistsByDOM_EMPRESA(string value );
        public bool ExistsByDOM_FILIAL(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_MetasDTO FirstByMET_ID(int value );
        public T_MetasDTO FirstByMET_DTINICIO(string value );
        public T_MetasDTO FirstByMET_DTFIM(string value );
        public T_MetasDTO FirstByMET_ALVO(string value );
        public T_MetasDTO FirstByMET_TIPOALVO(int value );
        public T_MetasDTO FirstByIND_ID(int value );
        public T_MetasDTO FirstByMET_RANGE01(Decimal value );
        public T_MetasDTO FirstByMET_RANGE02(Decimal value );
        public T_MetasDTO FirstByMET_RANGE03(Decimal value );
        public T_MetasDTO FirstByDIM_ID(int value );
        public T_MetasDTO FirstByFAT_ID(string value );
        public T_MetasDTO FirstByDIM_SUBDIMENSAO_ID(string value );
        public T_MetasDTO FirstByPER_ID(string value );
        public T_MetasDTO FirstByDOM_EMPRESA(string value );
        public T_MetasDTO FirstByDOM_FILIAL(string value );
        public T_MetasDTO FirstByTenantID(int value );
        public T_MetasDTO FirstByDeleted(bool value );
        public T_MetasDTO FirstByChanged(DateTime value );
        public T_MetasDTO FirstByUserId(int value );
        public IEnumerable<T_MetasDTO> GetAllByMET_ID(int value );
        public IEnumerable<T_MetasDTO> GetAllByMET_DTINICIO(string value );
        public IEnumerable<T_MetasDTO> GetAllByMET_DTFIM(string value );
        public IEnumerable<T_MetasDTO> GetAllByMET_ALVO(string value );
        public IEnumerable<T_MetasDTO> GetAllByMET_TIPOALVO(int value );
        public IEnumerable<T_MetasDTO> GetAllByIND_ID(int value );
        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE01(Decimal value );
        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE02(Decimal value );
        public IEnumerable<T_MetasDTO> GetAllByMET_RANGE03(Decimal value );
        public IEnumerable<T_MetasDTO> GetAllByDIM_ID(int value );
        public IEnumerable<T_MetasDTO> GetAllByFAT_ID(string value );
        public IEnumerable<T_MetasDTO> GetAllByDIM_SUBDIMENSAO_ID(string value );
        public IEnumerable<T_MetasDTO> GetAllByPER_ID(string value );
        public IEnumerable<T_MetasDTO> GetAllByDOM_EMPRESA(string value );
        public IEnumerable<T_MetasDTO> GetAllByDOM_FILIAL(string value );
        public IEnumerable<T_MetasDTO> GetAllByTenantID(int value );
        public IEnumerable<T_MetasDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_MetasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_MetasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration