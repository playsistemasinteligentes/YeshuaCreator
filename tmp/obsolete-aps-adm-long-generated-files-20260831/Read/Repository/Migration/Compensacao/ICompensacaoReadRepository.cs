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
    public partial interface ICompensacaoReadRepository
    {
        public DataPagination<CompensacaoDTO> getCompensacao(ICommandRead command );
        public IEnumerable<CompensacaoGRP_IDDTO> getCompensacaoReadFKGRP_ID(object command );
        public IEnumerable<CompensacaoOND_IDDTO> getCompensacaoReadFKOND_ID(object command );
        public IEnumerable<CompensacaoTenantIDDTO> getCompensacaoReadFKTenantID(object command );
        public IEnumerable<CompensacaoUserIdDTO> getCompensacaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCOM_ID(int value );
        public bool ExistsByGRP_ID(string value );
        public bool ExistsByOND_ID(string value );
        public bool ExistsByCOM_VINCO1_OND(int value );
        public bool ExistsByCOM_VINCO2_OND(int value );
        public bool ExistsByCOM_VINCO3_OND(int value );
        public bool ExistsByCOM_VINCO4_OND(int value );
        public bool ExistsByCOM_VINCO5_OND(int value );
        public bool ExistsByCOM_VINCO6_OND(int value );
        public bool ExistsByCOM_VINCO7_OND(int value );
        public bool ExistsByCOM_VINCO8_OND(int value );
        public bool ExistsByCOM_VINCO9_OND(int value );
        public bool ExistsByCOM_VINCO10_OND(int value );
        public bool ExistsByCOM_VINCO1_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO2_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO3_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO4_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO5_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO6_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO7_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO8_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO9_CONVERSAO(int value );
        public bool ExistsByCOM_VINCO10_CONVERSAO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CompensacaoDTO FirstById(int value );
        public CompensacaoDTO FirstByCOM_ID(int value );
        public CompensacaoDTO FirstByGRP_ID(string value );
        public CompensacaoDTO FirstByOND_ID(string value );
        public CompensacaoDTO FirstByCOM_VINCO1_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO2_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO3_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO4_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO5_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO6_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO7_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO8_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO9_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO10_OND(int value );
        public CompensacaoDTO FirstByCOM_VINCO1_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO2_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO3_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO4_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO5_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO6_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO7_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO8_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO9_CONVERSAO(int value );
        public CompensacaoDTO FirstByCOM_VINCO10_CONVERSAO(int value );
        public CompensacaoDTO FirstByTenantID(int value );
        public CompensacaoDTO FirstByDeleted(bool value );
        public CompensacaoDTO FirstByChanged(DateTime value );
        public CompensacaoDTO FirstByUserId(int value );
        public IEnumerable<CompensacaoDTO> GetAllById(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_ID(int value );
        public IEnumerable<CompensacaoDTO> GetAllByGRP_ID(string value );
        public IEnumerable<CompensacaoDTO> GetAllByOND_ID(string value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO1_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO2_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO3_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO4_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO5_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO6_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO7_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO8_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO9_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO10_OND(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO1_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO2_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO3_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO4_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO5_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO6_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO7_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO8_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO9_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByCOM_VINCO10_CONVERSAO(int value );
        public IEnumerable<CompensacaoDTO> GetAllByTenantID(int value );
        public IEnumerable<CompensacaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CompensacaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CompensacaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration