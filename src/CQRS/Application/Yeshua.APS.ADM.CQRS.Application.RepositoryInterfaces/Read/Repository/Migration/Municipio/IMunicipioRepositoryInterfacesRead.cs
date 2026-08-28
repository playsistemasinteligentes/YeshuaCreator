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
    public partial interface IMunicipioReadRepository
    {
        public DataPagination<MunicipioDTO> getMunicipio(ICommandRead command );
        public IEnumerable<MunicipioTenantIDDTO> getMunicipioReadFKTenantID(object command );
        public IEnumerable<MunicipioUserIdDTO> getMunicipioReadFKUserId(object command );
        public bool ExistsByMUN_ID(string value );
        public bool ExistsByMUN_NOME(string value );
        public bool ExistsByUF_COD(string value );
        public bool ExistsByMUN_CODIGO_IBGE(string value );
        public bool ExistsByMUN_LATITUDE(Decimal value );
        public bool ExistsByMUN_LONGITUDE(Decimal value );
        public bool ExistsByMUN_ID_INTEGRACAO_ERP(string value );
        public bool ExistsByMUN_CODIGO_SIAFI(string value );
        public bool ExistsByMUN_CODIGO_CNPJ(string value );
        public bool ExistsByMUN_DISTANCIA_KM(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MunicipioDTO FirstByMUN_ID(string value );
        public MunicipioDTO FirstByMUN_NOME(string value );
        public MunicipioDTO FirstByUF_COD(string value );
        public MunicipioDTO FirstByMUN_CODIGO_IBGE(string value );
        public MunicipioDTO FirstByMUN_LATITUDE(Decimal value );
        public MunicipioDTO FirstByMUN_LONGITUDE(Decimal value );
        public MunicipioDTO FirstByMUN_ID_INTEGRACAO_ERP(string value );
        public MunicipioDTO FirstByMUN_CODIGO_SIAFI(string value );
        public MunicipioDTO FirstByMUN_CODIGO_CNPJ(string value );
        public MunicipioDTO FirstByMUN_DISTANCIA_KM(Decimal value );
        public MunicipioDTO FirstByTenantID(int value );
        public MunicipioDTO FirstByDeleted(bool value );
        public MunicipioDTO FirstByChanged(DateTime value );
        public MunicipioDTO FirstByUserId(int value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_ID(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_NOME(string value );
        public IEnumerable<MunicipioDTO> GetAllByUF_COD(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_IBGE(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_LATITUDE(Decimal value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_LONGITUDE(Decimal value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_ID_INTEGRACAO_ERP(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_SIAFI(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_CODIGO_CNPJ(string value );
        public IEnumerable<MunicipioDTO> GetAllByMUN_DISTANCIA_KM(Decimal value );
        public IEnumerable<MunicipioDTO> GetAllByTenantID(int value );
        public IEnumerable<MunicipioDTO> GetAllByDeleted(bool value );
        public IEnumerable<MunicipioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MunicipioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration