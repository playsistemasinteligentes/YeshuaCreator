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
    public partial interface IRoteiroReadRepository
    {
        public DataPagination<RoteiroDTO> getRoteiro(ICommandRead command );
        public IEnumerable<RoteiroMAQ_IDDTO> getRoteiroReadFKMAQ_ID(object command );
        public IEnumerable<RoteiroPRO_IDDTO> getRoteiroReadFKPRO_ID(object command );
        public IEnumerable<RoteiroGMA_IDDTO> getRoteiroReadFKGMA_ID(object command );
        public IEnumerable<RoteiroTEM_IDDTO> getRoteiroReadFKTEM_ID(object command );
        public IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(object command );
        public IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(object command );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByROT_SEQ_TRANFORMACAO(int value );
        public bool ExistsByGMA_ID(string value );
        public bool ExistsByROT_PECAS_POR_PULSO(Decimal value );
        public bool ExistsByROT_PRIORIDADE_INFORMADA(Decimal value );
        public bool ExistsByROT_ACAO(string value );
        public bool ExistsByROT_PERFORMANCE(Decimal value );
        public bool ExistsByROT_TEMPO_SETUP(Decimal value );
        public bool ExistsByROT_TEMPO_SETUP_AJUSTE(Decimal value );
        public bool ExistsByROT_VA_PARA_SEQ_TRANSFORMACAO(int value );
        public bool ExistsByROT_STATUS(string value );
        public bool ExistsByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public bool ExistsByROT_AVALIA_CUSTO(int value );
        public bool ExistsByROT_OPERACOES(string value );
        public bool ExistsByROT_EXCECAO_OPERACOES(string value );
        public bool ExistsByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value );
        public bool ExistsByROT_LINHA_DIRETA(string value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RoteiroDTO FirstByMAQ_ID(string value );
        public RoteiroDTO FirstByPRO_ID(string value );
        public RoteiroDTO FirstByROT_SEQ_TRANFORMACAO(int value );
        public RoteiroDTO FirstByGMA_ID(string value );
        public RoteiroDTO FirstByROT_PECAS_POR_PULSO(Decimal value );
        public RoteiroDTO FirstByROT_PRIORIDADE_INFORMADA(Decimal value );
        public RoteiroDTO FirstByROT_ACAO(string value );
        public RoteiroDTO FirstByROT_PERFORMANCE(Decimal value );
        public RoteiroDTO FirstByROT_TEMPO_SETUP(Decimal value );
        public RoteiroDTO FirstByROT_TEMPO_SETUP_AJUSTE(Decimal value );
        public RoteiroDTO FirstByROT_VA_PARA_SEQ_TRANSFORMACAO(int value );
        public RoteiroDTO FirstByROT_STATUS(string value );
        public RoteiroDTO FirstByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public RoteiroDTO FirstByROT_AVALIA_CUSTO(int value );
        public RoteiroDTO FirstByROT_OPERACOES(string value );
        public RoteiroDTO FirstByROT_EXCECAO_OPERACOES(string value );
        public RoteiroDTO FirstByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value );
        public RoteiroDTO FirstByROT_LINHA_DIRETA(string value );
        public RoteiroDTO FirstByTEM_ID(int value );
        public RoteiroDTO FirstByTenantID(int value );
        public RoteiroDTO FirstByDeleted(bool value );
        public RoteiroDTO FirstByChanged(DateTime value );
        public RoteiroDTO FirstByUserId(int value );
        public IEnumerable<RoteiroDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<RoteiroDTO> GetAllByPRO_ID(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_SEQ_TRANFORMACAO(int value );
        public IEnumerable<RoteiroDTO> GetAllByGMA_ID(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_PECAS_POR_PULSO(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_PRIORIDADE_INFORMADA(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_ACAO(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_PERFORMANCE(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_TEMPO_SETUP(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_TEMPO_SETUP_AJUSTE(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_VA_PARA_SEQ_TRANSFORMACAO(int value );
        public IEnumerable<RoteiroDTO> GetAllByROT_STATUS(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_AVALIA_CUSTO(int value );
        public IEnumerable<RoteiroDTO> GetAllByROT_OPERACOES(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_EXCECAO_OPERACOES(string value );
        public IEnumerable<RoteiroDTO> GetAllByROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByROT_LINHA_DIRETA(string value );
        public IEnumerable<RoteiroDTO> GetAllByTEM_ID(int value );
        public IEnumerable<RoteiroDTO> GetAllByTenantID(int value );
        public IEnumerable<RoteiroDTO> GetAllByDeleted(bool value );
        public IEnumerable<RoteiroDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RoteiroDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration