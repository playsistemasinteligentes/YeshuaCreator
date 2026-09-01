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
    public partial interface ILotesReadRepository
    {
        public DataPagination<LotesDTO> getLotes(ICommandRead command );
        public IEnumerable<LotesTenantIDDTO> getLotesReadFKTenantID(object command );
        public IEnumerable<LotesUserIdDTO> getLotesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMOV_LOTE(string value );
        public bool ExistsByMOV_SUB_LOTE(string value );
        public bool ExistsByLOT_LARGURA(Decimal value );
        public bool ExistsByLOT_COMPRIMENTO(Decimal value );
        public bool ExistsByLOT_DIAMETRO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LotesDTO FirstById(int value );
        public LotesDTO FirstByMOV_LOTE(string value );
        public LotesDTO FirstByMOV_SUB_LOTE(string value );
        public LotesDTO FirstByLOT_LARGURA(Decimal value );
        public LotesDTO FirstByLOT_COMPRIMENTO(Decimal value );
        public LotesDTO FirstByLOT_DIAMETRO(Decimal value );
        public LotesDTO FirstByTenantID(int value );
        public LotesDTO FirstByDeleted(bool value );
        public LotesDTO FirstByChanged(DateTime value );
        public LotesDTO FirstByUserId(int value );
        public IEnumerable<LotesDTO> GetAllById(int value );
        public IEnumerable<LotesDTO> GetAllByMOV_LOTE(string value );
        public IEnumerable<LotesDTO> GetAllByMOV_SUB_LOTE(string value );
        public IEnumerable<LotesDTO> GetAllByLOT_LARGURA(Decimal value );
        public IEnumerable<LotesDTO> GetAllByLOT_COMPRIMENTO(Decimal value );
        public IEnumerable<LotesDTO> GetAllByLOT_DIAMETRO(Decimal value );
        public IEnumerable<LotesDTO> GetAllByTenantID(int value );
        public IEnumerable<LotesDTO> GetAllByDeleted(bool value );
        public IEnumerable<LotesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LotesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration