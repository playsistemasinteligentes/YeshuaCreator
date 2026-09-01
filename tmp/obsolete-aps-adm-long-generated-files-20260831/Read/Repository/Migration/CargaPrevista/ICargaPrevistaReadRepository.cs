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
    public partial interface ICargaPrevistaReadRepository
    {
        public DataPagination<CargaPrevistaDTO> getCargaPrevista(ICommandRead command );
        public IEnumerable<CargaPrevistaTenantIDDTO> getCargaPrevistaReadFKTenantID(object command );
        public IEnumerable<CargaPrevistaUserIdDTO> getCargaPrevistaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByITC_QTD_PLANEJADA(Decimal value );
        public bool ExistsByCAR_PREVISAO_MATERIA_PRIMA(DateTime value );
        public bool ExistsByCAR_DATA_INICIO_PREVISTO(DateTime value );
        public bool ExistsByCAR_DATA_INICIO_REALIZADO(DateTime value );
        public bool ExistsByCAR_DATA_FIM_PREVISTO(DateTime value );
        public bool ExistsByCAR_DATA_FIM_REALIZADO(DateTime value );
        public bool ExistsByCAR_INICIO_JANELA_EMBARQUE(DateTime value );
        public bool ExistsByCAR_FIM_JANELA_EMBARQUE(DateTime value );
        public bool ExistsByCAR_EMBARQUE_ALVO(DateTime value );
        public bool ExistsByCAR_STATUS(Decimal value );
        public bool ExistsByCAR_PESO_TEORICO(Decimal value );
        public bool ExistsByCAR_VOLUME_TEORICO(Decimal value );
        public bool ExistsByCAR_PESO_REAL(Decimal value );
        public bool ExistsByCAR_VOLUME_REAL(Decimal value );
        public bool ExistsByCAR_PESO_EMBALAGEM(Decimal value );
        public bool ExistsByCAR_PESO_ENTRADA(Decimal value );
        public bool ExistsByCAR_PESO_SAIDA(Decimal value );
        public bool ExistsByCAR_ID_DOCA(string value );
        public bool ExistsByVEI_PLACA(string value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByTRA_ID(string value );
        public bool ExistsByCAR_GRUPO_PRODUTIVO(Decimal value );
        public bool ExistsByROT_ID(string value );
        public bool ExistsByCAR_OBSERVACAO_DE_TRANSPORTE(string value );
        public bool ExistsByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value );
        public bool ExistsByOCO_ID(string value );
        public bool ExistsByCAR_ID_JUNTADA(string value );
        public bool ExistsByCAR_OBSERVACAO_OTIMIZADOR(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CargaPrevistaDTO FirstById(int value );
        public CargaPrevistaDTO FirstByCAR_ID(string value );
        public CargaPrevistaDTO FirstByORD_ID(string value );
        public CargaPrevistaDTO FirstByITC_QTD_PLANEJADA(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PREVISAO_MATERIA_PRIMA(DateTime value );
        public CargaPrevistaDTO FirstByCAR_DATA_INICIO_PREVISTO(DateTime value );
        public CargaPrevistaDTO FirstByCAR_DATA_INICIO_REALIZADO(DateTime value );
        public CargaPrevistaDTO FirstByCAR_DATA_FIM_PREVISTO(DateTime value );
        public CargaPrevistaDTO FirstByCAR_DATA_FIM_REALIZADO(DateTime value );
        public CargaPrevistaDTO FirstByCAR_INICIO_JANELA_EMBARQUE(DateTime value );
        public CargaPrevistaDTO FirstByCAR_FIM_JANELA_EMBARQUE(DateTime value );
        public CargaPrevistaDTO FirstByCAR_EMBARQUE_ALVO(DateTime value );
        public CargaPrevistaDTO FirstByCAR_STATUS(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PESO_TEORICO(Decimal value );
        public CargaPrevistaDTO FirstByCAR_VOLUME_TEORICO(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PESO_REAL(Decimal value );
        public CargaPrevistaDTO FirstByCAR_VOLUME_REAL(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PESO_EMBALAGEM(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PESO_ENTRADA(Decimal value );
        public CargaPrevistaDTO FirstByCAR_PESO_SAIDA(Decimal value );
        public CargaPrevistaDTO FirstByCAR_ID_DOCA(string value );
        public CargaPrevistaDTO FirstByVEI_PLACA(string value );
        public CargaPrevistaDTO FirstByTIP_ID(int value );
        public CargaPrevistaDTO FirstByTRA_ID(string value );
        public CargaPrevistaDTO FirstByCAR_GRUPO_PRODUTIVO(Decimal value );
        public CargaPrevistaDTO FirstByROT_ID(string value );
        public CargaPrevistaDTO FirstByCAR_OBSERVACAO_DE_TRANSPORTE(string value );
        public CargaPrevistaDTO FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value );
        public CargaPrevistaDTO FirstByOCO_ID(string value );
        public CargaPrevistaDTO FirstByCAR_ID_JUNTADA(string value );
        public CargaPrevistaDTO FirstByCAR_OBSERVACAO_OTIMIZADOR(string value );
        public CargaPrevistaDTO FirstByTenantID(int value );
        public CargaPrevistaDTO FirstByDeleted(bool value );
        public CargaPrevistaDTO FirstByChanged(DateTime value );
        public CargaPrevistaDTO FirstByUserId(int value );
        public IEnumerable<CargaPrevistaDTO> GetAllById(int value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByORD_ID(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByITC_QTD_PLANEJADA(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PREVISAO_MATERIA_PRIMA(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_INICIO_PREVISTO(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_INICIO_REALIZADO(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_FIM_PREVISTO(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_DATA_FIM_REALIZADO(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_INICIO_JANELA_EMBARQUE(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_FIM_JANELA_EMBARQUE(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_EMBARQUE_ALVO(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_STATUS(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_TEORICO(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_VOLUME_TEORICO(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_REAL(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_VOLUME_REAL(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_EMBALAGEM(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_ENTRADA(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_PESO_SAIDA(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID_DOCA(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByVEI_PLACA(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByTIP_ID(int value );
        public IEnumerable<CargaPrevistaDTO> GetAllByTRA_ID(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_GRUPO_PRODUTIVO(Decimal value );
        public IEnumerable<CargaPrevistaDTO> GetAllByROT_ID(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_OBSERVACAO_DE_TRANSPORTE(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByOCO_ID(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_ID_JUNTADA(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByCAR_OBSERVACAO_OTIMIZADOR(string value );
        public IEnumerable<CargaPrevistaDTO> GetAllByTenantID(int value );
        public IEnumerable<CargaPrevistaDTO> GetAllByDeleted(bool value );
        public IEnumerable<CargaPrevistaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CargaPrevistaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration