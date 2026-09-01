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
    public partial interface ICorConfiguracaoGraficoReadRepository
    {
        public DataPagination<CorConfiguracaoGraficoDTO> getCorConfiguracaoGrafico(ICommandRead command );
        public IEnumerable<CorConfiguracaoGraficoTenantIDDTO> getCorConfiguracaoGraficoReadFKTenantID(object command );
        public IEnumerable<CorConfiguracaoGraficoUserIdDTO> getCorConfiguracaoGraficoReadFKUserId(object command );
        public bool ExistsByCOR_ID(string value );
        public bool ExistsByCOR_PERCENTUAL_INI(Decimal value );
        public bool ExistsByCOR_PERCENTUAL_FIM(Decimal value );
        public bool ExistsByCOR_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CorConfiguracaoGraficoDTO FirstByCOR_ID(string value );
        public CorConfiguracaoGraficoDTO FirstByCOR_PERCENTUAL_INI(Decimal value );
        public CorConfiguracaoGraficoDTO FirstByCOR_PERCENTUAL_FIM(Decimal value );
        public CorConfiguracaoGraficoDTO FirstByCOR_DESCRICAO(string value );
        public CorConfiguracaoGraficoDTO FirstByTenantID(int value );
        public CorConfiguracaoGraficoDTO FirstByDeleted(bool value );
        public CorConfiguracaoGraficoDTO FirstByChanged(DateTime value );
        public CorConfiguracaoGraficoDTO FirstByUserId(int value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_ID(string value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_PERCENTUAL_INI(Decimal value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_PERCENTUAL_FIM(Decimal value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByCOR_DESCRICAO(string value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByTenantID(int value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CorConfiguracaoGraficoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration