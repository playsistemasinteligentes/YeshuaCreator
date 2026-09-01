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
    public partial interface IMapaReadRepository
    {
        public DataPagination<MapaDTO> getMapa(ICommandRead command );
        public IEnumerable<MapaPON_IDDTO> getMapaReadFKPON_ID(object command );
        public IEnumerable<MapaTenantIDDTO> getMapaReadFKTenantID(object command );
        public IEnumerable<MapaUserIdDTO> getMapaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMAP_ID(int value );
        public bool ExistsByPON_ID(string value );
        public bool ExistsByPON_ID_VIZINHO(string value );
        public bool ExistsByMAP_DISTANCIA(Decimal value );
        public bool ExistsByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value );
        public bool ExistsByROD_ID(int value );
        public bool ExistsByMAP_ALTURA_ROD(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MapaDTO FirstById(int value );
        public MapaDTO FirstByMAP_ID(int value );
        public MapaDTO FirstByPON_ID(string value );
        public MapaDTO FirstByPON_ID_VIZINHO(string value );
        public MapaDTO FirstByMAP_DISTANCIA(Decimal value );
        public MapaDTO FirstByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value );
        public MapaDTO FirstByROD_ID(int value );
        public MapaDTO FirstByMAP_ALTURA_ROD(Decimal value );
        public MapaDTO FirstByTenantID(int value );
        public MapaDTO FirstByDeleted(bool value );
        public MapaDTO FirstByChanged(DateTime value );
        public MapaDTO FirstByUserId(int value );
        public IEnumerable<MapaDTO> GetAllById(int value );
        public IEnumerable<MapaDTO> GetAllByMAP_ID(int value );
        public IEnumerable<MapaDTO> GetAllByPON_ID(string value );
        public IEnumerable<MapaDTO> GetAllByPON_ID_VIZINHO(string value );
        public IEnumerable<MapaDTO> GetAllByMAP_DISTANCIA(Decimal value );
        public IEnumerable<MapaDTO> GetAllByMAP_CUSTO_PEDAGIO_POR_EIXO(Decimal value );
        public IEnumerable<MapaDTO> GetAllByROD_ID(int value );
        public IEnumerable<MapaDTO> GetAllByMAP_ALTURA_ROD(Decimal value );
        public IEnumerable<MapaDTO> GetAllByTenantID(int value );
        public IEnumerable<MapaDTO> GetAllByDeleted(bool value );
        public IEnumerable<MapaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MapaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration