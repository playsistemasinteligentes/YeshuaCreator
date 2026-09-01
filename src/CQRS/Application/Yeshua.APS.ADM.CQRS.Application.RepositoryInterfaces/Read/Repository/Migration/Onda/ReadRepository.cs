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
    public partial interface IOndaReadRepository
    {
        public DataPagination<OndaDTO> getOnda(ICommandRead command );
        public IEnumerable<OndaVIN_IDDTO> getOndaReadFKVIN_ID(object command );
        public IEnumerable<OndaTenantIDDTO> getOndaReadFKTenantID(object command );
        public IEnumerable<OndaUserIdDTO> getOndaReadFKUserId(object command );
        public bool ExistsByOND_ID(string value );
        public bool ExistsByOND_ESPESSURA(Decimal value );
        public bool ExistsByOND_PESO_COLA(Decimal value );
        public bool ExistsByOND_RENDIMENTO_ONDA_1(Decimal value );
        public bool ExistsByOND_RENDIMENTO_ONDA_2(Decimal value );
        public bool ExistsByOND_PROFUNDIDADE_VINCO(int value );
        public bool ExistsByOND_ID_INTEGRACAO(string value );
        public bool ExistsByVIN_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OndaDTO FirstByOND_ID(string value );
        public OndaDTO FirstByOND_ESPESSURA(Decimal value );
        public OndaDTO FirstByOND_PESO_COLA(Decimal value );
        public OndaDTO FirstByOND_RENDIMENTO_ONDA_1(Decimal value );
        public OndaDTO FirstByOND_RENDIMENTO_ONDA_2(Decimal value );
        public OndaDTO FirstByOND_PROFUNDIDADE_VINCO(int value );
        public OndaDTO FirstByOND_ID_INTEGRACAO(string value );
        public OndaDTO FirstByVIN_ID(int value );
        public OndaDTO FirstByTenantID(int value );
        public OndaDTO FirstByDeleted(bool value );
        public OndaDTO FirstByChanged(DateTime value );
        public OndaDTO FirstByUserId(int value );
        public IEnumerable<OndaDTO> GetAllByOND_ID(string value );
        public IEnumerable<OndaDTO> GetAllByOND_ESPESSURA(Decimal value );
        public IEnumerable<OndaDTO> GetAllByOND_PESO_COLA(Decimal value );
        public IEnumerable<OndaDTO> GetAllByOND_RENDIMENTO_ONDA_1(Decimal value );
        public IEnumerable<OndaDTO> GetAllByOND_RENDIMENTO_ONDA_2(Decimal value );
        public IEnumerable<OndaDTO> GetAllByOND_PROFUNDIDADE_VINCO(int value );
        public IEnumerable<OndaDTO> GetAllByOND_ID_INTEGRACAO(string value );
        public IEnumerable<OndaDTO> GetAllByVIN_ID(int value );
        public IEnumerable<OndaDTO> GetAllByTenantID(int value );
        public IEnumerable<OndaDTO> GetAllByDeleted(bool value );
        public IEnumerable<OndaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OndaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration