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
    public partial interface ITipoInspecaoVisualReadRepository
    {
        public DataPagination<TipoInspecaoVisualDTO> getTipoInspecaoVisual(ICommandRead command );
        public IEnumerable<TipoInspecaoVisualTenantIDDTO> getTipoInspecaoVisualReadFKTenantID(object command );
        public IEnumerable<TipoInspecaoVisualUserIdDTO> getTipoInspecaoVisualReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTIV_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByTIV_NOME(string value );
        public bool ExistsByTIV_DESCRICAO(string value );
        public bool ExistsByTIV_FECHAMENTO(string value );
        public bool ExistsByTIV_AMOSTRA_ALEATORIA(string value );
        public bool ExistsByTIV_N_AMOSTRAS(int value );
        public bool ExistsByTIV_MEDIDA(string value );
        public bool ExistsByTIV_ESPECIFICACAO(Decimal value );
        public bool ExistsByTIV_TOL_MAIS(Decimal value );
        public bool ExistsByTIV_TOL_MENOS(Decimal value );
        public TipoInspecaoVisualDTO FirstById(int value );
        public TipoInspecaoVisualDTO FirstByTIV_ID(int value );
        public TipoInspecaoVisualDTO FirstByTenantID(int value );
        public TipoInspecaoVisualDTO FirstByDeleted(bool value );
        public TipoInspecaoVisualDTO FirstByChanged(DateTime value );
        public TipoInspecaoVisualDTO FirstByUserId(int value );
        public TipoInspecaoVisualDTO FirstByTIV_NOME(string value );
        public TipoInspecaoVisualDTO FirstByTIV_DESCRICAO(string value );
        public TipoInspecaoVisualDTO FirstByTIV_FECHAMENTO(string value );
        public TipoInspecaoVisualDTO FirstByTIV_AMOSTRA_ALEATORIA(string value );
        public TipoInspecaoVisualDTO FirstByTIV_N_AMOSTRAS(int value );
        public TipoInspecaoVisualDTO FirstByTIV_MEDIDA(string value );
        public TipoInspecaoVisualDTO FirstByTIV_ESPECIFICACAO(Decimal value );
        public TipoInspecaoVisualDTO FirstByTIV_TOL_MAIS(Decimal value );
        public TipoInspecaoVisualDTO FirstByTIV_TOL_MENOS(Decimal value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllById(int value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_ID(int value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByUserId(int value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_NOME(string value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_DESCRICAO(string value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_FECHAMENTO(string value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_AMOSTRA_ALEATORIA(string value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_N_AMOSTRAS(int value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_MEDIDA(string value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_ESPECIFICACAO(Decimal value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_TOL_MAIS(Decimal value );
        public IEnumerable<TipoInspecaoVisualDTO> GetAllByTIV_TOL_MENOS(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration