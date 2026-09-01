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
    public partial interface IPontosMapaReadRepository
    {
        public DataPagination<PontosMapaDTO> getPontosMapa(ICommandRead command );
        public IEnumerable<PontosMapaTenantIDDTO> getPontosMapaReadFKTenantID(object command );
        public IEnumerable<PontosMapaUserIdDTO> getPontosMapaReadFKUserId(object command );
        public bool ExistsByPON_ID(string value );
        public bool ExistsByPON_DESCRICAO(string value );
        public bool ExistsByPON_TIPO(string value );
        public bool ExistsByPON_LATITUDE(Decimal value );
        public bool ExistsByPON_LONGITUDE(Decimal value );
        public bool ExistsByPON_DISTANCIA_KM(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PontosMapaDTO FirstByPON_ID(string value );
        public PontosMapaDTO FirstByPON_DESCRICAO(string value );
        public PontosMapaDTO FirstByPON_TIPO(string value );
        public PontosMapaDTO FirstByPON_LATITUDE(Decimal value );
        public PontosMapaDTO FirstByPON_LONGITUDE(Decimal value );
        public PontosMapaDTO FirstByPON_DISTANCIA_KM(Decimal value );
        public PontosMapaDTO FirstByTenantID(int value );
        public PontosMapaDTO FirstByDeleted(bool value );
        public PontosMapaDTO FirstByChanged(DateTime value );
        public PontosMapaDTO FirstByUserId(int value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_ID(string value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_DESCRICAO(string value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_TIPO(string value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_LATITUDE(Decimal value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_LONGITUDE(Decimal value );
        public IEnumerable<PontosMapaDTO> GetAllByPON_DISTANCIA_KM(Decimal value );
        public IEnumerable<PontosMapaDTO> GetAllByTenantID(int value );
        public IEnumerable<PontosMapaDTO> GetAllByDeleted(bool value );
        public IEnumerable<PontosMapaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PontosMapaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration