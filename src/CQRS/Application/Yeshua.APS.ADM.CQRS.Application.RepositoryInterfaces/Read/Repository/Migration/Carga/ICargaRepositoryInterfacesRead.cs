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
    public partial interface ICargaReadRepository
    {
        public DataPagination<CargaDTO> getCarga(ICommandRead command );
        public IEnumerable<CargaOCO_IDDTO> getCargaReadFKOCO_ID(object command );
        public IEnumerable<CargaTenantIDDTO> getCargaReadFKTenantID(object command );
        public IEnumerable<CargaUserIdDTO> getCargaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCAR_ID(string value );
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
        public bool ExistsByCAR_ID_INTEGRACAO_BALANCA(string value );
        public bool ExistsByCAR_PESAGEM_LIBERADA(string value );
        public bool ExistsByCAR_OBS_LIERACAO(string value );
        public bool ExistsByOCO_ID_LIERACAO(string value );
        public bool ExistsByCAR_DATA_ENTRADA_VEICULO(DateTime value );
        public bool ExistsByCAR_DATA_SAIDA_VEICULO(DateTime value );
        public bool ExistsByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value );
        public bool ExistsByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value );
        public bool ExistsByCAR_DIFERENCA_PESAGEM(Decimal value );
        public bool ExistsByCAR_DATA_AGENCIAMENTO(DateTime value );
        public bool ExistsByTURN_ID(string value );
        public bool ExistsByTURM_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CargaDTO FirstById(int value );
        public CargaDTO FirstByCAR_ID(string value );
        public CargaDTO FirstByCAR_PREVISAO_MATERIA_PRIMA(DateTime value );
        public CargaDTO FirstByCAR_DATA_INICIO_PREVISTO(DateTime value );
        public CargaDTO FirstByCAR_DATA_INICIO_REALIZADO(DateTime value );
        public CargaDTO FirstByCAR_DATA_FIM_PREVISTO(DateTime value );
        public CargaDTO FirstByCAR_DATA_FIM_REALIZADO(DateTime value );
        public CargaDTO FirstByCAR_INICIO_JANELA_EMBARQUE(DateTime value );
        public CargaDTO FirstByCAR_FIM_JANELA_EMBARQUE(DateTime value );
        public CargaDTO FirstByCAR_EMBARQUE_ALVO(DateTime value );
        public CargaDTO FirstByCAR_STATUS(Decimal value );
        public CargaDTO FirstByCAR_PESO_TEORICO(Decimal value );
        public CargaDTO FirstByCAR_VOLUME_TEORICO(Decimal value );
        public CargaDTO FirstByCAR_PESO_REAL(Decimal value );
        public CargaDTO FirstByCAR_VOLUME_REAL(Decimal value );
        public CargaDTO FirstByCAR_PESO_EMBALAGEM(Decimal value );
        public CargaDTO FirstByCAR_PESO_ENTRADA(Decimal value );
        public CargaDTO FirstByCAR_PESO_SAIDA(Decimal value );
        public CargaDTO FirstByCAR_ID_DOCA(string value );
        public CargaDTO FirstByVEI_PLACA(string value );
        public CargaDTO FirstByTIP_ID(int value );
        public CargaDTO FirstByTRA_ID(string value );
        public CargaDTO FirstByCAR_GRUPO_PRODUTIVO(Decimal value );
        public CargaDTO FirstByROT_ID(string value );
        public CargaDTO FirstByCAR_OBSERVACAO_DE_TRANSPORTE(string value );
        public CargaDTO FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value );
        public CargaDTO FirstByOCO_ID(string value );
        public CargaDTO FirstByCAR_ID_JUNTADA(string value );
        public CargaDTO FirstByCAR_OBSERVACAO_OTIMIZADOR(string value );
        public CargaDTO FirstByCAR_ID_INTEGRACAO_BALANCA(string value );
        public CargaDTO FirstByCAR_PESAGEM_LIBERADA(string value );
        public CargaDTO FirstByCAR_OBS_LIERACAO(string value );
        public CargaDTO FirstByOCO_ID_LIERACAO(string value );
        public CargaDTO FirstByCAR_DATA_ENTRADA_VEICULO(DateTime value );
        public CargaDTO FirstByCAR_DATA_SAIDA_VEICULO(DateTime value );
        public CargaDTO FirstByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value );
        public CargaDTO FirstByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value );
        public CargaDTO FirstByCAR_DIFERENCA_PESAGEM(Decimal value );
        public CargaDTO FirstByCAR_DATA_AGENCIAMENTO(DateTime value );
        public CargaDTO FirstByTURN_ID(string value );
        public CargaDTO FirstByTURM_ID(string value );
        public CargaDTO FirstByTenantID(int value );
        public CargaDTO FirstByDeleted(bool value );
        public CargaDTO FirstByChanged(DateTime value );
        public CargaDTO FirstByUserId(int value );
        public IEnumerable<CargaDTO> GetAllById(int value );
        public IEnumerable<CargaDTO> GetAllByCAR_ID(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_PREVISAO_MATERIA_PRIMA(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_INICIO_PREVISTO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_INICIO_REALIZADO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_FIM_PREVISTO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_FIM_REALIZADO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_INICIO_JANELA_EMBARQUE(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_FIM_JANELA_EMBARQUE(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_EMBARQUE_ALVO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_STATUS(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESO_TEORICO(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_VOLUME_TEORICO(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESO_REAL(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_VOLUME_REAL(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESO_EMBALAGEM(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESO_ENTRADA(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESO_SAIDA(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_ID_DOCA(string value );
        public IEnumerable<CargaDTO> GetAllByVEI_PLACA(string value );
        public IEnumerable<CargaDTO> GetAllByTIP_ID(int value );
        public IEnumerable<CargaDTO> GetAllByTRA_ID(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_GRUPO_PRODUTIVO(Decimal value );
        public IEnumerable<CargaDTO> GetAllByROT_ID(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_OBSERVACAO_DE_TRANSPORTE(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_JUSTIFICATIVA_DE_CARREGAMENTO(string value );
        public IEnumerable<CargaDTO> GetAllByOCO_ID(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_ID_JUNTADA(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_OBSERVACAO_OTIMIZADOR(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_ID_INTEGRACAO_BALANCA(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_PESAGEM_LIBERADA(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_OBS_LIERACAO(string value );
        public IEnumerable<CargaDTO> GetAllByOCO_ID_LIERACAO(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_ENTRADA_VEICULO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_SAIDA_VEICULO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_ROMANEIO_CONSOLIDADO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(string value );
        public IEnumerable<CargaDTO> GetAllByCAR_DIFERENCA_PESAGEM(Decimal value );
        public IEnumerable<CargaDTO> GetAllByCAR_DATA_AGENCIAMENTO(DateTime value );
        public IEnumerable<CargaDTO> GetAllByTURN_ID(string value );
        public IEnumerable<CargaDTO> GetAllByTURM_ID(string value );
        public IEnumerable<CargaDTO> GetAllByTenantID(int value );
        public IEnumerable<CargaDTO> GetAllByDeleted(bool value );
        public IEnumerable<CargaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CargaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration