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
    public partial interface IItensPackedReadRepository
    {
        public DataPagination<ItensPackedDTO> getItensPacked(ICommandRead command );
        public IEnumerable<ItensPackedORD_IDDTO> getItensPackedReadFKORD_ID(object command );
        public IEnumerable<ItensPackedTenantIDDTO> getItensPackedReadFKTenantID(object command );
        public IEnumerable<ItensPackedUserIdDTO> getItensPackedReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByIPA_ID(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByIPA_COORDC(Decimal value );
        public bool ExistsByIPA_COORDL(Decimal value );
        public bool ExistsByIPA_COORDA(Decimal value );
        public bool ExistsByIPA_DIMC(Decimal value );
        public bool ExistsByIPA_DIML(Decimal value );
        public bool ExistsByIPA_DIMA(Decimal value );
        public bool ExistsByIPA_QTD_POR_PALETE(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItensPackedDTO FirstById(int value );
        public ItensPackedDTO FirstByIPA_ID(int value );
        public ItensPackedDTO FirstByCAR_ID(string value );
        public ItensPackedDTO FirstByPRO_ID(string value );
        public ItensPackedDTO FirstByORD_ID(string value );
        public ItensPackedDTO FirstByIPA_COORDC(Decimal value );
        public ItensPackedDTO FirstByIPA_COORDL(Decimal value );
        public ItensPackedDTO FirstByIPA_COORDA(Decimal value );
        public ItensPackedDTO FirstByIPA_DIMC(Decimal value );
        public ItensPackedDTO FirstByIPA_DIML(Decimal value );
        public ItensPackedDTO FirstByIPA_DIMA(Decimal value );
        public ItensPackedDTO FirstByIPA_QTD_POR_PALETE(Decimal value );
        public ItensPackedDTO FirstByTenantID(int value );
        public ItensPackedDTO FirstByDeleted(bool value );
        public ItensPackedDTO FirstByChanged(DateTime value );
        public ItensPackedDTO FirstByUserId(int value );
        public IEnumerable<ItensPackedDTO> GetAllById(int value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_ID(int value );
        public IEnumerable<ItensPackedDTO> GetAllByCAR_ID(string value );
        public IEnumerable<ItensPackedDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ItensPackedDTO> GetAllByORD_ID(string value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDC(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDL(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_COORDA(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIMC(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIML(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_DIMA(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByIPA_QTD_POR_PALETE(Decimal value );
        public IEnumerable<ItensPackedDTO> GetAllByTenantID(int value );
        public IEnumerable<ItensPackedDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItensPackedDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItensPackedDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration