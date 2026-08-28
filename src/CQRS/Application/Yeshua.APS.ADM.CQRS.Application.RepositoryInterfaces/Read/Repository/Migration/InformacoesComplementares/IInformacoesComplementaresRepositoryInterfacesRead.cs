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
    public partial interface IInformacoesComplementaresReadRepository
    {
        public DataPagination<InformacoesComplementaresDTO> getInformacoesComplementares(ICommandRead command );
        public IEnumerable<InformacoesComplementaresMET_IDDTO> getInformacoesComplementaresReadFKMET_ID(object command );
        public IEnumerable<InformacoesComplementaresTenantIDDTO> getInformacoesComplementaresReadFKTenantID(object command );
        public IEnumerable<InformacoesComplementaresUserIdDTO> getInformacoesComplementaresReadFKUserId(object command );
        public bool ExistsByINF_ID(int value );
        public bool ExistsByINF_DESCRICAO(string value );
        public bool ExistsByINF_VALOR(Decimal value );
        public bool ExistsByMET_ID(int value );
        public bool ExistsByINF_DATA(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public InformacoesComplementaresDTO FirstByINF_ID(int value );
        public InformacoesComplementaresDTO FirstByINF_DESCRICAO(string value );
        public InformacoesComplementaresDTO FirstByINF_VALOR(Decimal value );
        public InformacoesComplementaresDTO FirstByMET_ID(int value );
        public InformacoesComplementaresDTO FirstByINF_DATA(string value );
        public InformacoesComplementaresDTO FirstByTenantID(int value );
        public InformacoesComplementaresDTO FirstByDeleted(bool value );
        public InformacoesComplementaresDTO FirstByChanged(DateTime value );
        public InformacoesComplementaresDTO FirstByUserId(int value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_ID(int value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_DESCRICAO(string value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_VALOR(Decimal value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByMET_ID(int value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByINF_DATA(string value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByTenantID(int value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByDeleted(bool value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByChanged(DateTime value );
        public IEnumerable<InformacoesComplementaresDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration