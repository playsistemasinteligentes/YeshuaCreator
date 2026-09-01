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
    public partial interface IEstradasReadRepository
    {
        public DataPagination<EstradasDTO> getEstradas(ICommandRead command );
        public IEnumerable<EstradasTenantIDDTO> getEstradasReadFKTenantID(object command );
        public IEnumerable<EstradasUserIdDTO> getEstradasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEST_ID(int value );
        public bool ExistsByEST_DESCRICAO(string value );
        public bool ExistsByEST_ID_LIGACAO_PONTO_A(int value );
        public bool ExistsByEST_ID_LIGACAO_PONTO_B(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EstradasDTO FirstById(int value );
        public EstradasDTO FirstByEST_ID(int value );
        public EstradasDTO FirstByEST_DESCRICAO(string value );
        public EstradasDTO FirstByEST_ID_LIGACAO_PONTO_A(int value );
        public EstradasDTO FirstByEST_ID_LIGACAO_PONTO_B(int value );
        public EstradasDTO FirstByTenantID(int value );
        public EstradasDTO FirstByDeleted(bool value );
        public EstradasDTO FirstByChanged(DateTime value );
        public EstradasDTO FirstByUserId(int value );
        public IEnumerable<EstradasDTO> GetAllById(int value );
        public IEnumerable<EstradasDTO> GetAllByEST_ID(int value );
        public IEnumerable<EstradasDTO> GetAllByEST_DESCRICAO(string value );
        public IEnumerable<EstradasDTO> GetAllByEST_ID_LIGACAO_PONTO_A(int value );
        public IEnumerable<EstradasDTO> GetAllByEST_ID_LIGACAO_PONTO_B(int value );
        public IEnumerable<EstradasDTO> GetAllByTenantID(int value );
        public IEnumerable<EstradasDTO> GetAllByDeleted(bool value );
        public IEnumerable<EstradasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EstradasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration