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
    public partial interface IMensagemReadRepository
    {
        public DataPagination<MensagemDTO> getMensagem(ICommandRead command );
        public IEnumerable<MensagemTenantIDDTO> getMensagemReadFKTenantID(object command );
        public IEnumerable<MensagemUserIdDTO> getMensagemReadFKUserId(object command );
        public bool ExistsByMEN_ID(string value );
        public bool ExistsByMEN_SEND(string value );
        public bool ExistsByMEN_EMISSION(DateTime value );
        public bool ExistsByMEN_STATUS(string value );
        public bool ExistsByMEN_RECEIVE(string value );
        public bool ExistsByMEN_TYPE(string value );
        public bool ExistsByMEN_QTD_TRY_SEND(Decimal value );
        public bool ExistsByMEN_DATE_TRY_SEND(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MensagemDTO FirstByMEN_ID(string value );
        public MensagemDTO FirstByMEN_SEND(string value );
        public MensagemDTO FirstByMEN_EMISSION(DateTime value );
        public MensagemDTO FirstByMEN_STATUS(string value );
        public MensagemDTO FirstByMEN_RECEIVE(string value );
        public MensagemDTO FirstByMEN_TYPE(string value );
        public MensagemDTO FirstByMEN_QTD_TRY_SEND(Decimal value );
        public MensagemDTO FirstByMEN_DATE_TRY_SEND(DateTime value );
        public MensagemDTO FirstByTenantID(int value );
        public MensagemDTO FirstByDeleted(bool value );
        public MensagemDTO FirstByChanged(DateTime value );
        public MensagemDTO FirstByUserId(int value );
        public IEnumerable<MensagemDTO> GetAllByMEN_ID(string value );
        public IEnumerable<MensagemDTO> GetAllByMEN_SEND(string value );
        public IEnumerable<MensagemDTO> GetAllByMEN_EMISSION(DateTime value );
        public IEnumerable<MensagemDTO> GetAllByMEN_STATUS(string value );
        public IEnumerable<MensagemDTO> GetAllByMEN_RECEIVE(string value );
        public IEnumerable<MensagemDTO> GetAllByMEN_TYPE(string value );
        public IEnumerable<MensagemDTO> GetAllByMEN_QTD_TRY_SEND(Decimal value );
        public IEnumerable<MensagemDTO> GetAllByMEN_DATE_TRY_SEND(DateTime value );
        public IEnumerable<MensagemDTO> GetAllByTenantID(int value );
        public IEnumerable<MensagemDTO> GetAllByDeleted(bool value );
        public IEnumerable<MensagemDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MensagemDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration