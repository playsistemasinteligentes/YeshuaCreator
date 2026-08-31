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
    public partial interface ICTeSaidaMDFeReadRepository
    {
        public DataPagination<CTeSaidaMDFeDTO> getCTeSaidaMDFe(ICommandRead command );
        public IEnumerable<CTeSaidaMDFeCTeTentativaEmissaoIdDTO> getCTeSaidaMDFeReadFKCTeTentativaEmissaoId(object command );
        public IEnumerable<CTeSaidaMDFeTenantIDDTO> getCTeSaidaMDFeReadFKTenantID(object command );
        public IEnumerable<CTeSaidaMDFeUserIdDTO> getCTeSaidaMDFeReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCTeTentativaEmissaoId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByChaveAcessoCTe(string value );
        public bool ExistsBySnapshotHash(string value );
        public bool ExistsByOutboxMessageId(string value );
        public bool ExistsByPublicadoEmUtc(DateTime value );
        public bool ExistsByUltimoErro(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeSaidaMDFeDTO FirstById(int value );
        public CTeSaidaMDFeDTO FirstByCTeTentativaEmissaoId(int value );
        public CTeSaidaMDFeDTO FirstByCorrelationId(string value );
        public CTeSaidaMDFeDTO FirstByChaveAcessoCTe(string value );
        public CTeSaidaMDFeDTO FirstBySnapshotHash(string value );
        public CTeSaidaMDFeDTO FirstByOutboxMessageId(string value );
        public CTeSaidaMDFeDTO FirstByPublicadoEmUtc(DateTime value );
        public CTeSaidaMDFeDTO FirstByUltimoErro(string value );
        public CTeSaidaMDFeDTO FirstByStatus(int value );
        public CTeSaidaMDFeDTO FirstByTenantID(int value );
        public CTeSaidaMDFeDTO FirstByDeleted(bool value );
        public CTeSaidaMDFeDTO FirstByChanged(DateTime value );
        public CTeSaidaMDFeDTO FirstByUserId(int value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllById(int value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByCTeTentativaEmissaoId(int value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByCorrelationId(string value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByChaveAcessoCTe(string value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllBySnapshotHash(string value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByOutboxMessageId(string value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByPublicadoEmUtc(DateTime value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByUltimoErro(string value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByStatus(int value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeSaidaMDFeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration