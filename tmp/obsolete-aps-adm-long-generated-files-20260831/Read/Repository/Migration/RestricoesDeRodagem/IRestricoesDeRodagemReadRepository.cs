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
    public partial interface IRestricoesDeRodagemReadRepository
    {
        public DataPagination<RestricoesDeRodagemDTO> getRestricoesDeRodagem(ICommandRead command );
        public IEnumerable<RestricoesDeRodagemTenantIDDTO> getRestricoesDeRodagemReadFKTenantID(object command );
        public IEnumerable<RestricoesDeRodagemUserIdDTO> getRestricoesDeRodagemReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByRES_ID(int value );
        public bool ExistsByRES_TIPO(string value );
        public bool ExistsByRES_HORA_INI(string value );
        public bool ExistsByRES_HORA_FIM(string value );
        public bool ExistsByRES_VELOCIDADE_HORA_RUSH(Decimal value );
        public bool ExistsByTVE_ID(int value );
        public bool ExistsByMAP_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RestricoesDeRodagemDTO FirstById(int value );
        public RestricoesDeRodagemDTO FirstByRES_ID(int value );
        public RestricoesDeRodagemDTO FirstByRES_TIPO(string value );
        public RestricoesDeRodagemDTO FirstByRES_HORA_INI(string value );
        public RestricoesDeRodagemDTO FirstByRES_HORA_FIM(string value );
        public RestricoesDeRodagemDTO FirstByRES_VELOCIDADE_HORA_RUSH(Decimal value );
        public RestricoesDeRodagemDTO FirstByTVE_ID(int value );
        public RestricoesDeRodagemDTO FirstByMAP_ID(int value );
        public RestricoesDeRodagemDTO FirstByTenantID(int value );
        public RestricoesDeRodagemDTO FirstByDeleted(bool value );
        public RestricoesDeRodagemDTO FirstByChanged(DateTime value );
        public RestricoesDeRodagemDTO FirstByUserId(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllById(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_ID(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_TIPO(string value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_HORA_INI(string value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_HORA_FIM(string value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByRES_VELOCIDADE_HORA_RUSH(Decimal value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByTVE_ID(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByMAP_ID(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByTenantID(int value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByDeleted(bool value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RestricoesDeRodagemDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration