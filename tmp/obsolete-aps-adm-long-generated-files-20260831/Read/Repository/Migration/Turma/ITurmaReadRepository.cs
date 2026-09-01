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
    public partial interface ITurmaReadRepository
    {
        public DataPagination<TurmaDTO> getTurma(ICommandRead command );
        public IEnumerable<TurmaTenantIDDTO> getTurmaReadFKTenantID(object command );
        public IEnumerable<TurmaUserIdDTO> getTurmaReadFKUserId(object command );
        public bool ExistsById(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByTURM_HORA_INI_DIA1(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA1(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA2(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA2(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA3(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA3(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA4(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA4(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA5(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA5(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA6(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA6(DateTime value );
        public bool ExistsByTURM_HORA_INI_DIA7(DateTime value );
        public bool ExistsByTURM_HORA_FIM_DIA7(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TurmaDTO FirstById(string value );
        public TurmaDTO FirstByDescricao(string value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA1(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA1(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA2(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA2(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA3(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA3(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA4(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA4(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA5(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA5(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA6(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA6(DateTime value );
        public TurmaDTO FirstByTURM_HORA_INI_DIA7(DateTime value );
        public TurmaDTO FirstByTURM_HORA_FIM_DIA7(DateTime value );
        public TurmaDTO FirstByTenantID(int value );
        public TurmaDTO FirstByDeleted(bool value );
        public TurmaDTO FirstByChanged(DateTime value );
        public TurmaDTO FirstByUserId(int value );
        public IEnumerable<TurmaDTO> GetAllById(string value );
        public IEnumerable<TurmaDTO> GetAllByDescricao(string value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA1(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA1(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA2(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA2(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA3(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA3(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA4(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA4(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA5(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA5(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA6(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA6(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA7(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA7(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByTenantID(int value );
        public IEnumerable<TurmaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TurmaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TurmaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration