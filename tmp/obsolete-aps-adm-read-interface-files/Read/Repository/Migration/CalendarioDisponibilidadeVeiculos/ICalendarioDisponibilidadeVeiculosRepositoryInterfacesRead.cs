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
    public partial interface ICalendarioDisponibilidadeVeiculosReadRepository
    {
        public DataPagination<CalendarioDisponibilidadeVeiculosDTO> getCalendarioDisponibilidadeVeiculos(ICommandRead command );
        public IEnumerable<CalendarioDisponibilidadeVeiculosTenantIDDTO> getCalendarioDisponibilidadeVeiculosReadFKTenantID(object command );
        public IEnumerable<CalendarioDisponibilidadeVeiculosUserIdDTO> getCalendarioDisponibilidadeVeiculosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCDV_ID(int value );
        public bool ExistsByCDV_DATA_DE(DateTime value );
        public bool ExistsByCDV_DATA_ATE(DateTime value );
        public bool ExistsByCDV_SEGUNDA(int value );
        public bool ExistsByCDV_TERCA(int value );
        public bool ExistsByCDV_QUARTA(int value );
        public bool ExistsByCDV_QUINTA(int value );
        public bool ExistsByCDV_SEXTA(int value );
        public bool ExistsByCDV_SABADO(int value );
        public bool ExistsByCDV_DOMINGO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstById(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_ID(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DATA_DE(DateTime value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DATA_ATE(DateTime value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SEGUNDA(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_TERCA(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_QUARTA(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_QUINTA(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SEXTA(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SABADO(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DOMINGO(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByTenantID(int value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByDeleted(bool value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByChanged(DateTime value );
        public CalendarioDisponibilidadeVeiculosDTO FirstByUserId(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllById(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_ID(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DATA_DE(DateTime value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DATA_ATE(DateTime value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SEGUNDA(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_TERCA(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_QUARTA(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_QUINTA(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SEXTA(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SABADO(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DOMINGO(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByTenantID(int value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByDeleted(bool value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration