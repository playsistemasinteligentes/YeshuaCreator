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
    public partial interface IItenCalendarioDisponibilidadeVeiculosReadRepository
    {
        public DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO> getItenCalendarioDisponibilidadeVeiculos(ICommandRead command );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO> getItenCalendarioDisponibilidadeVeiculosReadFKTenantID(object command );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosUserIdDTO> getItenCalendarioDisponibilidadeVeiculosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCDV_ID(int value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByIDV_QTD(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstById(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByCDV_ID(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByTIP_ID(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByIDV_QTD(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByTenantID(int value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByDeleted(bool value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByChanged(DateTime value );
        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByUserId(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllById(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_ID(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByTIP_ID(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByIDV_QTD(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByTenantID(int value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration