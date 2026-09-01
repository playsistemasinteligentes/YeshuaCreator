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
    public partial interface IVincoReadRepository
    {
        public DataPagination<VincoDTO> getVinco(ICommandRead command );
        public IEnumerable<VincoTenantIDDTO> getVincoReadFKTenantID(object command );
        public IEnumerable<VincoUserIdDTO> getVincoReadFKUserId(object command );
        public bool ExistsByVIN_ID(int value );
        public bool ExistsByVIN_DESCRICAO(string value );
        public bool ExistsByVIN_ID_DESLOCAMENTO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VincoDTO FirstByVIN_ID(int value );
        public VincoDTO FirstByVIN_DESCRICAO(string value );
        public VincoDTO FirstByVIN_ID_DESLOCAMENTO(string value );
        public VincoDTO FirstByTenantID(int value );
        public VincoDTO FirstByDeleted(bool value );
        public VincoDTO FirstByChanged(DateTime value );
        public VincoDTO FirstByUserId(int value );
        public IEnumerable<VincoDTO> GetAllByVIN_ID(int value );
        public IEnumerable<VincoDTO> GetAllByVIN_DESCRICAO(string value );
        public IEnumerable<VincoDTO> GetAllByVIN_ID_DESLOCAMENTO(string value );
        public IEnumerable<VincoDTO> GetAllByTenantID(int value );
        public IEnumerable<VincoDTO> GetAllByDeleted(bool value );
        public IEnumerable<VincoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VincoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration