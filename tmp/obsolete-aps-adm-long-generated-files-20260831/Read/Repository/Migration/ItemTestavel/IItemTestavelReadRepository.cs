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
    public partial interface IItemTestavelReadRepository
    {
        public DataPagination<ItemTestavelDTO> getItemTestavel(ICommandRead command );
        public IEnumerable<ItemTestavelTenantIDDTO> getItemTestavelReadFKTenantID(object command );
        public IEnumerable<ItemTestavelUserIdDTO> getItemTestavelReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByITE_ID(int value );
        public bool ExistsByITE_DESCRICAO(string value );
        public bool ExistsByITE_OBS(string value );
        public bool ExistsByITE_NUMERO_DE_TESTES(int value );
        public bool ExistsByITE_CONDICIONAL_DE_AVALIACAO(string value );
        public bool ExistsByITE_VALOR_DA_CONDICIONAL(Decimal value );
        public bool ExistsByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value );
        public bool ExistsByITE_TIPO_AVALIACAO_FINAL(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItemTestavelDTO FirstById(int value );
        public ItemTestavelDTO FirstByITE_ID(int value );
        public ItemTestavelDTO FirstByITE_DESCRICAO(string value );
        public ItemTestavelDTO FirstByITE_OBS(string value );
        public ItemTestavelDTO FirstByITE_NUMERO_DE_TESTES(int value );
        public ItemTestavelDTO FirstByITE_CONDICIONAL_DE_AVALIACAO(string value );
        public ItemTestavelDTO FirstByITE_VALOR_DA_CONDICIONAL(Decimal value );
        public ItemTestavelDTO FirstByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value );
        public ItemTestavelDTO FirstByITE_TIPO_AVALIACAO_FINAL(string value );
        public ItemTestavelDTO FirstByTenantID(int value );
        public ItemTestavelDTO FirstByDeleted(bool value );
        public ItemTestavelDTO FirstByChanged(DateTime value );
        public ItemTestavelDTO FirstByUserId(int value );
        public IEnumerable<ItemTestavelDTO> GetAllById(int value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_ID(int value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_DESCRICAO(string value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_OBS(string value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_NUMERO_DE_TESTES(int value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_CONDICIONAL_DE_AVALIACAO(string value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_VALOR_DA_CONDICIONAL(Decimal value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_VALOR_CALCULADO_DA_CONDICIONAL(string value );
        public IEnumerable<ItemTestavelDTO> GetAllByITE_TIPO_AVALIACAO_FINAL(string value );
        public IEnumerable<ItemTestavelDTO> GetAllByTenantID(int value );
        public IEnumerable<ItemTestavelDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItemTestavelDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItemTestavelDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration