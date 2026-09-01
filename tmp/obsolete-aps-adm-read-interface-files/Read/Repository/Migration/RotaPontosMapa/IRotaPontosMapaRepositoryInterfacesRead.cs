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
    public partial interface IRotaPontosMapaReadRepository
    {
        public DataPagination<RotaPontosMapaDTO> getRotaPontosMapa(ICommandRead command );
        public IEnumerable<RotaPontosMapaPON_ID_DESTINODTO> getRotaPontosMapaReadFKPON_ID_DESTINO(object command );
        public IEnumerable<RotaPontosMapaTenantIDDTO> getRotaPontosMapaReadFKTenantID(object command );
        public IEnumerable<RotaPontosMapaUserIdDTO> getRotaPontosMapaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByROT_ID(string value );
        public bool ExistsByPON_ID_DESTINO(string value );
        public bool ExistsByPON_ID_ORIGEM(string value );
        public bool ExistsByROT_CUSTO_TOTAL(Decimal value );
        public bool ExistsByPON_ID_ROTEIRO(string value );
        public bool ExistsByROT_ORDEM_ROTEIRO(int value );
        public bool ExistsByROT_TIPO(string value );
        public bool ExistsByROT_DISTANCIA(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RotaPontosMapaDTO FirstById(int value );
        public RotaPontosMapaDTO FirstByROT_ID(string value );
        public RotaPontosMapaDTO FirstByPON_ID_DESTINO(string value );
        public RotaPontosMapaDTO FirstByPON_ID_ORIGEM(string value );
        public RotaPontosMapaDTO FirstByROT_CUSTO_TOTAL(Decimal value );
        public RotaPontosMapaDTO FirstByPON_ID_ROTEIRO(string value );
        public RotaPontosMapaDTO FirstByROT_ORDEM_ROTEIRO(int value );
        public RotaPontosMapaDTO FirstByROT_TIPO(string value );
        public RotaPontosMapaDTO FirstByROT_DISTANCIA(Decimal value );
        public RotaPontosMapaDTO FirstByTenantID(int value );
        public RotaPontosMapaDTO FirstByDeleted(bool value );
        public RotaPontosMapaDTO FirstByChanged(DateTime value );
        public RotaPontosMapaDTO FirstByUserId(int value );
        public IEnumerable<RotaPontosMapaDTO> GetAllById(int value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_ID(string value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_DESTINO(string value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_ORIGEM(string value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_CUSTO_TOTAL(Decimal value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByPON_ID_ROTEIRO(string value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_ORDEM_ROTEIRO(int value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_TIPO(string value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByROT_DISTANCIA(Decimal value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByTenantID(int value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByDeleted(bool value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RotaPontosMapaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration