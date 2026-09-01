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
    public partial interface ITipoTesteReadRepository
    {
        public DataPagination<TipoTesteDTO> getTipoTeste(ICommandRead command );
        public IEnumerable<TipoTesteTenantIDDTO> getTipoTesteReadFKTenantID(object command );
        public IEnumerable<TipoTesteUserIdDTO> getTipoTesteReadFKUserId(object command );
        public IEnumerable<TipoTesteTA_IDDTO> getTipoTesteReadFKTA_ID(object command );
        public bool ExistsByTT_ESPECIFICACAO(Decimal value );
        public bool ExistsByTT_ORIGEM_ESPECIFICACAO(string value );
        public bool ExistsByTT_IMPRIME_NO_LAUDO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByTT_ID(int value );
        public bool ExistsByTT_NOME(string value );
        public bool ExistsByTT_DESC(string value );
        public bool ExistsByTT_TOL_MAIS(Decimal value );
        public bool ExistsByTT_TOL_MENOS(Decimal value );
        public bool ExistsByTT_NORMA(string value );
        public bool ExistsByTT_INICIO_PROCESSO(string value );
        public bool ExistsByTA_ID(int value );
        public bool ExistsByUNI_ID(string value );
        public bool ExistsByTT_N_AMOSTRAS_P_TESTE(int value );
        public bool ExistsByTT_MAX_DEF_CRITICO(int value );
        public bool ExistsByTT_MAX_DEF_GRAVE(int value );
        public TipoTesteDTO FirstByTT_ESPECIFICACAO(Decimal value );
        public TipoTesteDTO FirstByTT_ORIGEM_ESPECIFICACAO(string value );
        public TipoTesteDTO FirstByTT_IMPRIME_NO_LAUDO(string value );
        public TipoTesteDTO FirstByTenantID(int value );
        public TipoTesteDTO FirstByDeleted(bool value );
        public TipoTesteDTO FirstByChanged(DateTime value );
        public TipoTesteDTO FirstByUserId(int value );
        public TipoTesteDTO FirstByTT_ID(int value );
        public TipoTesteDTO FirstByTT_NOME(string value );
        public TipoTesteDTO FirstByTT_DESC(string value );
        public TipoTesteDTO FirstByTT_TOL_MAIS(Decimal value );
        public TipoTesteDTO FirstByTT_TOL_MENOS(Decimal value );
        public TipoTesteDTO FirstByTT_NORMA(string value );
        public TipoTesteDTO FirstByTT_INICIO_PROCESSO(string value );
        public TipoTesteDTO FirstByTA_ID(int value );
        public TipoTesteDTO FirstByUNI_ID(string value );
        public TipoTesteDTO FirstByTT_N_AMOSTRAS_P_TESTE(int value );
        public TipoTesteDTO FirstByTT_MAX_DEF_CRITICO(int value );
        public TipoTesteDTO FirstByTT_MAX_DEF_GRAVE(int value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_ESPECIFICACAO(Decimal value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_ORIGEM_ESPECIFICACAO(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_IMPRIME_NO_LAUDO(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoTesteDTO> GetAllByUserId(int value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_ID(int value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_NOME(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_DESC(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_TOL_MAIS(Decimal value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_TOL_MENOS(Decimal value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_NORMA(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_INICIO_PROCESSO(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTA_ID(int value );
        public IEnumerable<TipoTesteDTO> GetAllByUNI_ID(string value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_N_AMOSTRAS_P_TESTE(int value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_MAX_DEF_CRITICO(int value );
        public IEnumerable<TipoTesteDTO> GetAllByTT_MAX_DEF_GRAVE(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration