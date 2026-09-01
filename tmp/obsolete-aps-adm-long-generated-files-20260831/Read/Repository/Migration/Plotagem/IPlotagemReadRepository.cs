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
    public partial interface IPlotagemReadRepository
    {
        public DataPagination<PlotagemDTO> getPlotagem(ICommandRead command );
        public IEnumerable<PlotagemTenantIDDTO> getPlotagemReadFKTenantID(object command );
        public IEnumerable<PlotagemUserIdDTO> getPlotagemReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPLO_ID(int value );
        public bool ExistsByPLO_NOME(string value );
        public bool ExistsByPLO_DIMENSAO(string value );
        public bool ExistsByPLO_X(string value );
        public bool ExistsByPLO_Y(string value );
        public bool ExistsByPLO_Z(string value );
        public bool ExistsByPLO_GRAFICO(string value );
        public bool ExistsByCON_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PlotagemDTO FirstById(int value );
        public PlotagemDTO FirstByPLO_ID(int value );
        public PlotagemDTO FirstByPLO_NOME(string value );
        public PlotagemDTO FirstByPLO_DIMENSAO(string value );
        public PlotagemDTO FirstByPLO_X(string value );
        public PlotagemDTO FirstByPLO_Y(string value );
        public PlotagemDTO FirstByPLO_Z(string value );
        public PlotagemDTO FirstByPLO_GRAFICO(string value );
        public PlotagemDTO FirstByCON_ID(int value );
        public PlotagemDTO FirstByTenantID(int value );
        public PlotagemDTO FirstByDeleted(bool value );
        public PlotagemDTO FirstByChanged(DateTime value );
        public PlotagemDTO FirstByUserId(int value );
        public IEnumerable<PlotagemDTO> GetAllById(int value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_ID(int value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_NOME(string value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_DIMENSAO(string value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_X(string value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_Y(string value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_Z(string value );
        public IEnumerable<PlotagemDTO> GetAllByPLO_GRAFICO(string value );
        public IEnumerable<PlotagemDTO> GetAllByCON_ID(int value );
        public IEnumerable<PlotagemDTO> GetAllByTenantID(int value );
        public IEnumerable<PlotagemDTO> GetAllByDeleted(bool value );
        public IEnumerable<PlotagemDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PlotagemDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration