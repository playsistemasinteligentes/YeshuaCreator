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
    public partial interface ICotasReadRepository
    {
        public DataPagination<CotasDTO> getCotas(ICommandRead command );
        public IEnumerable<CotasTenantIDDTO> getCotasReadFKTenantID(object command );
        public IEnumerable<CotasUserIdDTO> getCotasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCOT_ID(int value );
        public bool ExistsByCOT_DATA_DE(DateTime value );
        public bool ExistsByCOT_DATA_ATE(DateTime value );
        public bool ExistsByCOT_VALOR(Decimal value );
        public bool ExistsByCOT_OCUPADO(Decimal value );
        public bool ExistsByREP_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CotasDTO FirstById(int value );
        public CotasDTO FirstByCOT_ID(int value );
        public CotasDTO FirstByCOT_DATA_DE(DateTime value );
        public CotasDTO FirstByCOT_DATA_ATE(DateTime value );
        public CotasDTO FirstByCOT_VALOR(Decimal value );
        public CotasDTO FirstByCOT_OCUPADO(Decimal value );
        public CotasDTO FirstByREP_ID(int value );
        public CotasDTO FirstByTenantID(int value );
        public CotasDTO FirstByDeleted(bool value );
        public CotasDTO FirstByChanged(DateTime value );
        public CotasDTO FirstByUserId(int value );
        public IEnumerable<CotasDTO> GetAllById(int value );
        public IEnumerable<CotasDTO> GetAllByCOT_ID(int value );
        public IEnumerable<CotasDTO> GetAllByCOT_DATA_DE(DateTime value );
        public IEnumerable<CotasDTO> GetAllByCOT_DATA_ATE(DateTime value );
        public IEnumerable<CotasDTO> GetAllByCOT_VALOR(Decimal value );
        public IEnumerable<CotasDTO> GetAllByCOT_OCUPADO(Decimal value );
        public IEnumerable<CotasDTO> GetAllByREP_ID(int value );
        public IEnumerable<CotasDTO> GetAllByTenantID(int value );
        public IEnumerable<CotasDTO> GetAllByDeleted(bool value );
        public IEnumerable<CotasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CotasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration