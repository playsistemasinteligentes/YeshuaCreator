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
    public partial interface IT_HORARIO_RECEBIMENTOReadRepository
    {
        public DataPagination<T_HORARIO_RECEBIMENTODTO> getT_HORARIO_RECEBIMENTO(ICommandRead command );
        public IEnumerable<T_HORARIO_RECEBIMENTOCLI_IDDTO> getT_HORARIO_RECEBIMENTOReadFKCLI_ID(object command );
        public IEnumerable<T_HORARIO_RECEBIMENTOTenantIDDTO> getT_HORARIO_RECEBIMENTOReadFKTenantID(object command );
        public IEnumerable<T_HORARIO_RECEBIMENTOUserIdDTO> getT_HORARIO_RECEBIMENTOReadFKUserId(object command );
        public bool ExistsByHRE_DIA_DA_SEMANA(int value );
        public bool ExistsByHRE_HORA_INICIAL(DateTime value );
        public bool ExistsByHRE_HORA_FINAL(DateTime value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByHRE_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_HORARIO_RECEBIMENTODTO FirstByHRE_DIA_DA_SEMANA(int value );
        public T_HORARIO_RECEBIMENTODTO FirstByHRE_HORA_INICIAL(DateTime value );
        public T_HORARIO_RECEBIMENTODTO FirstByHRE_HORA_FINAL(DateTime value );
        public T_HORARIO_RECEBIMENTODTO FirstByCLI_ID(string value );
        public T_HORARIO_RECEBIMENTODTO FirstByHRE_ID(int value );
        public T_HORARIO_RECEBIMENTODTO FirstByTenantID(int value );
        public T_HORARIO_RECEBIMENTODTO FirstByDeleted(bool value );
        public T_HORARIO_RECEBIMENTODTO FirstByChanged(DateTime value );
        public T_HORARIO_RECEBIMENTODTO FirstByUserId(int value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_DIA_DA_SEMANA(int value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_HORA_INICIAL(DateTime value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_HORA_FINAL(DateTime value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByCLI_ID(string value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByHRE_ID(int value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByTenantID(int value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByDeleted(bool value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_HORARIO_RECEBIMENTODTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration