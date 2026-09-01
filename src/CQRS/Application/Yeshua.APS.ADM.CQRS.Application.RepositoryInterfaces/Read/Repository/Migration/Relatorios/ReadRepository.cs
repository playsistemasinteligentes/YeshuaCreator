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
    public partial interface IRelatoriosReadRepository
    {
        public DataPagination<RelatoriosDTO> getRelatorios(ICommandRead command );
        public IEnumerable<RelatoriosTenantIDDTO> getRelatoriosReadFKTenantID(object command );
        public IEnumerable<RelatoriosUserIdDTO> getRelatoriosReadFKUserId(object command );
        public bool ExistsByREL_ID(int value );
        public bool ExistsByREL_NOME_RELATORIO(string value );
        public bool ExistsByREL_NOME_CAMPO(string value );
        public bool ExistsByREL_TIPO_CAMPO(string value );
        public bool ExistsByREL_POS_X(int value );
        public bool ExistsByREL_POS_Y(int value );
        public bool ExistsByREL_TAMANHO_FONTE(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RelatoriosDTO FirstByREL_ID(int value );
        public RelatoriosDTO FirstByREL_NOME_RELATORIO(string value );
        public RelatoriosDTO FirstByREL_NOME_CAMPO(string value );
        public RelatoriosDTO FirstByREL_TIPO_CAMPO(string value );
        public RelatoriosDTO FirstByREL_POS_X(int value );
        public RelatoriosDTO FirstByREL_POS_Y(int value );
        public RelatoriosDTO FirstByREL_TAMANHO_FONTE(int value );
        public RelatoriosDTO FirstByTenantID(int value );
        public RelatoriosDTO FirstByDeleted(bool value );
        public RelatoriosDTO FirstByChanged(DateTime value );
        public RelatoriosDTO FirstByUserId(int value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_ID(int value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_NOME_RELATORIO(string value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_NOME_CAMPO(string value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_TIPO_CAMPO(string value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_POS_X(int value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_POS_Y(int value );
        public IEnumerable<RelatoriosDTO> GetAllByREL_TAMANHO_FONTE(int value );
        public IEnumerable<RelatoriosDTO> GetAllByTenantID(int value );
        public IEnumerable<RelatoriosDTO> GetAllByDeleted(bool value );
        public IEnumerable<RelatoriosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RelatoriosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration