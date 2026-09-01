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
    public partial interface IT_AGENDA_SCHEDULEReadRepository
    {
        public DataPagination<T_AGENDA_SCHEDULEDTO> getT_AGENDA_SCHEDULE(ICommandRead command );
        public IEnumerable<T_AGENDA_SCHEDULETenantIDDTO> getT_AGENDA_SCHEDULEReadFKTenantID(object command );
        public IEnumerable<T_AGENDA_SCHEDULEUserIdDTO> getT_AGENDA_SCHEDULEReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByAGE_ID(int value );
        public bool ExistsByAGE_DATA_ESPECIFICA(DateTime value );
        public bool ExistsByAGE_HORARIO_INICIO(string value );
        public bool ExistsByAGE_HORARIO_FIM(string value );
        public bool ExistsByAGE_SEGUNDA(string value );
        public bool ExistsByAGE_TERCA(string value );
        public bool ExistsByAGE_QUARTA(string value );
        public bool ExistsByAGE_QUINTA(string value );
        public bool ExistsByAGE_SEXTA(string value );
        public bool ExistsByAGE_SABADO(string value );
        public bool ExistsByAGE_DOMINGO(string value );
        public bool ExistsByAGE_INTERVALO(Decimal value );
        public bool ExistsByAGE_ORDEM_EXECUCAO(string value );
        public bool ExistsByAGE_PARAMETROS(string value );
        public bool ExistsByAGE_EXCECAO(string value );
        public bool ExistsByAGE_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_AGENDA_SCHEDULEDTO FirstById(int value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_ID(int value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_DATA_ESPECIFICA(DateTime value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_HORARIO_INICIO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_HORARIO_FIM(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_SEGUNDA(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_TERCA(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_QUARTA(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_QUINTA(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_SEXTA(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_SABADO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_DOMINGO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_INTERVALO(Decimal value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_ORDEM_EXECUCAO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_PARAMETROS(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_EXCECAO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByAGE_DESCRICAO(string value );
        public T_AGENDA_SCHEDULEDTO FirstByTenantID(int value );
        public T_AGENDA_SCHEDULEDTO FirstByDeleted(bool value );
        public T_AGENDA_SCHEDULEDTO FirstByChanged(DateTime value );
        public T_AGENDA_SCHEDULEDTO FirstByUserId(int value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllById(int value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_ID(int value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DATA_ESPECIFICA(DateTime value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_HORARIO_INICIO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_HORARIO_FIM(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SEGUNDA(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_TERCA(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_QUARTA(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_QUINTA(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SEXTA(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_SABADO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DOMINGO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_INTERVALO(Decimal value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_ORDEM_EXECUCAO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_PARAMETROS(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_EXCECAO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByAGE_DESCRICAO(string value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByTenantID(int value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_AGENDA_SCHEDULEDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration