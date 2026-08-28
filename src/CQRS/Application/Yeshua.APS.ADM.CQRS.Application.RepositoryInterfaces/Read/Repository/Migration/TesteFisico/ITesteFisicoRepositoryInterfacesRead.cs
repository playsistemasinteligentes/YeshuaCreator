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
    public partial interface ITesteFisicoReadRepository
    {
        public DataPagination<TesteFisicoDTO> getTesteFisico(ICommandRead command );
        public IEnumerable<TesteFisicoUSR_IDDTO> getTesteFisicoReadFKUSR_ID(object command );
        public IEnumerable<TesteFisicoORD_IDDTO> getTesteFisicoReadFKORD_ID(object command );
        public IEnumerable<TesteFisicoTenantIDDTO> getTesteFisicoReadFKTenantID(object command );
        public IEnumerable<TesteFisicoUserIdDTO> getTesteFisicoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTES_ID(int value );
        public bool ExistsByITE_ID(int value );
        public bool ExistsByUSR_ID(int value );
        public bool ExistsByTES_NOME_TECNICO(string value );
        public bool ExistsByTES_AMOSTRA(int value );
        public bool ExistsByTES_OP(string value );
        public bool ExistsByTES_VALOR_NUMERICO(Decimal value );
        public bool ExistsByTES_VALOR_DATA(DateTime value );
        public bool ExistsByTES_VALOR_TEXTO(string value );
        public bool ExistsByTES_EMISSAO(DateTime value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByFPR_SEQ_TRANFORMACAO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TesteFisicoDTO FirstById(int value );
        public TesteFisicoDTO FirstByTES_ID(int value );
        public TesteFisicoDTO FirstByITE_ID(int value );
        public TesteFisicoDTO FirstByUSR_ID(int value );
        public TesteFisicoDTO FirstByTES_NOME_TECNICO(string value );
        public TesteFisicoDTO FirstByTES_AMOSTRA(int value );
        public TesteFisicoDTO FirstByTES_OP(string value );
        public TesteFisicoDTO FirstByTES_VALOR_NUMERICO(Decimal value );
        public TesteFisicoDTO FirstByTES_VALOR_DATA(DateTime value );
        public TesteFisicoDTO FirstByTES_VALOR_TEXTO(string value );
        public TesteFisicoDTO FirstByTES_EMISSAO(DateTime value );
        public TesteFisicoDTO FirstByORD_ID(string value );
        public TesteFisicoDTO FirstByPRO_ID(string value );
        public TesteFisicoDTO FirstByMAQ_ID(string value );
        public TesteFisicoDTO FirstByFPR_SEQ_REPETICAO(int value );
        public TesteFisicoDTO FirstByFPR_SEQ_TRANFORMACAO(int value );
        public TesteFisicoDTO FirstByTenantID(int value );
        public TesteFisicoDTO FirstByDeleted(bool value );
        public TesteFisicoDTO FirstByChanged(DateTime value );
        public TesteFisicoDTO FirstByUserId(int value );
        public IEnumerable<TesteFisicoDTO> GetAllById(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_ID(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByITE_ID(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByUSR_ID(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_NOME_TECNICO(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_AMOSTRA(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_OP(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_NUMERICO(Decimal value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_DATA(DateTime value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_VALOR_TEXTO(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByTES_EMISSAO(DateTime value );
        public IEnumerable<TesteFisicoDTO> GetAllByORD_ID(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByPRO_ID(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<TesteFisicoDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByFPR_SEQ_TRANFORMACAO(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByTenantID(int value );
        public IEnumerable<TesteFisicoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TesteFisicoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TesteFisicoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration