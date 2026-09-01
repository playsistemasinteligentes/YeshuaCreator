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
    public partial interface ITurnoReadRepository
    {
        public DataPagination<TurnoDTO> getTurno(ICommandRead command );
        public IEnumerable<TurnoTenantIDDTO> getTurnoReadFKTenantID(object command );
        public IEnumerable<TurnoUserIdDTO> getTurnoReadFKUserId(object command );
        public bool ExistsById(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByTURN_PRIORIDADE(int value );
        public bool ExistsByTURN_HORA_INI_DIA1(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA1(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA2(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA2(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA3(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA3(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA4(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA4(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA5(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA5(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA6(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA6(DateTime value );
        public bool ExistsByTURN_HORA_INI_DIA7(DateTime value );
        public bool ExistsByTURN_HORA_FIM_DIA7(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TurnoDTO FirstById(string value );
        public TurnoDTO FirstByDescricao(string value );
        public TurnoDTO FirstByTURN_PRIORIDADE(int value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA1(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA1(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA2(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA2(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA3(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA3(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA4(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA4(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA5(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA5(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA6(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA6(DateTime value );
        public TurnoDTO FirstByTURN_HORA_INI_DIA7(DateTime value );
        public TurnoDTO FirstByTURN_HORA_FIM_DIA7(DateTime value );
        public TurnoDTO FirstByTenantID(int value );
        public TurnoDTO FirstByDeleted(bool value );
        public TurnoDTO FirstByChanged(DateTime value );
        public TurnoDTO FirstByUserId(int value );
        public IEnumerable<TurnoDTO> GetAllById(string value );
        public IEnumerable<TurnoDTO> GetAllByDescricao(string value );
        public IEnumerable<TurnoDTO> GetAllByTURN_PRIORIDADE(int value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA1(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA1(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA2(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA2(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA3(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA3(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA4(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA4(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA5(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA5(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA6(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA6(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA7(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA7(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByTenantID(int value );
        public IEnumerable<TurnoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TurnoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TurnoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration