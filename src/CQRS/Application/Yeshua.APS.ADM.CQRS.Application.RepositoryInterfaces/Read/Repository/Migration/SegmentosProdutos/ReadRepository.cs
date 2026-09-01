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
    public partial interface ISegmentosProdutosReadRepository
    {
        public DataPagination<SegmentosProdutosDTO> getSegmentosProdutos(ICommandRead command );
        public IEnumerable<SegmentosProdutosTenantIDDTO> getSegmentosProdutosReadFKTenantID(object command );
        public IEnumerable<SegmentosProdutosUserIdDTO> getSegmentosProdutosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByGRS_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsBySEG_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public SegmentosProdutosDTO FirstById(int value );
        public SegmentosProdutosDTO FirstByGRS_ID(string value );
        public SegmentosProdutosDTO FirstByPRO_ID(string value );
        public SegmentosProdutosDTO FirstBySEG_ID(string value );
        public SegmentosProdutosDTO FirstByTenantID(int value );
        public SegmentosProdutosDTO FirstByDeleted(bool value );
        public SegmentosProdutosDTO FirstByChanged(DateTime value );
        public SegmentosProdutosDTO FirstByUserId(int value );
        public IEnumerable<SegmentosProdutosDTO> GetAllById(int value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByGRS_ID(string value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByPRO_ID(string value );
        public IEnumerable<SegmentosProdutosDTO> GetAllBySEG_ID(string value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByTenantID(int value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByDeleted(bool value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<SegmentosProdutosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration