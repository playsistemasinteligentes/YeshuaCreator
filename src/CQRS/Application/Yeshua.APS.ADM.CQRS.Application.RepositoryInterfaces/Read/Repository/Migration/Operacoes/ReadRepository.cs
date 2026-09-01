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
    public partial interface IOperacoesReadRepository
    {
        public DataPagination<OperacoesDTO> getOperacoes(ICommandRead command );
        public IEnumerable<OperacoesTenantIDDTO> getOperacoesReadFKTenantID(object command );
        public IEnumerable<OperacoesUserIdDTO> getOperacoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByOPE_TIPO_REGISTRO(string value );
        public bool ExistsByOPE_ID(string value );
        public bool ExistsByGMA_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByOPE_EXCECAO(string value );
        public bool ExistsByROT_SEQ_TRANFORMACAO(int value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OperacoesDTO FirstById(int value );
        public OperacoesDTO FirstByOPE_TIPO_REGISTRO(string value );
        public OperacoesDTO FirstByOPE_ID(string value );
        public OperacoesDTO FirstByGMA_ID(string value );
        public OperacoesDTO FirstByMAQ_ID(string value );
        public OperacoesDTO FirstByPRO_ID(string value );
        public OperacoesDTO FirstByOPE_EXCECAO(string value );
        public OperacoesDTO FirstByROT_SEQ_TRANFORMACAO(int value );
        public OperacoesDTO FirstByORD_ID(string value );
        public OperacoesDTO FirstByFPR_SEQ_REPETICAO(int value );
        public OperacoesDTO FirstByTenantID(int value );
        public OperacoesDTO FirstByDeleted(bool value );
        public OperacoesDTO FirstByChanged(DateTime value );
        public OperacoesDTO FirstByUserId(int value );
        public IEnumerable<OperacoesDTO> GetAllById(int value );
        public IEnumerable<OperacoesDTO> GetAllByOPE_TIPO_REGISTRO(string value );
        public IEnumerable<OperacoesDTO> GetAllByOPE_ID(string value );
        public IEnumerable<OperacoesDTO> GetAllByGMA_ID(string value );
        public IEnumerable<OperacoesDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<OperacoesDTO> GetAllByPRO_ID(string value );
        public IEnumerable<OperacoesDTO> GetAllByOPE_EXCECAO(string value );
        public IEnumerable<OperacoesDTO> GetAllByROT_SEQ_TRANFORMACAO(int value );
        public IEnumerable<OperacoesDTO> GetAllByORD_ID(string value );
        public IEnumerable<OperacoesDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<OperacoesDTO> GetAllByTenantID(int value );
        public IEnumerable<OperacoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<OperacoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OperacoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration