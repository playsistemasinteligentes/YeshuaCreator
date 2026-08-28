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
    public partial interface ICorridasOnduladeiraReadRepository
    {
        public DataPagination<CorridasOnduladeiraDTO> getCorridasOnduladeira(ICommandRead command );
        public IEnumerable<CorridasOnduladeiraTenantIDDTO> getCorridasOnduladeiraReadFKTenantID(object command );
        public IEnumerable<CorridasOnduladeiraUserIdDTO> getCorridasOnduladeiraReadFKUserId(object command );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByBOL_ID_ORIGEM(string value );
        public bool ExistsByPRO_LARGURA_PECA(Decimal value );
        public bool ExistsByPRO_LARGURA_PECA_PROGRAMADO(Decimal value );
        public bool ExistsByPRO_COMPRIMENTO_PECA(Decimal value );
        public bool ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value );
        public bool ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value );
        public bool ExistsByPRO_VINCOS_RECALCULADOS(string value );
        public bool ExistsByCOR_SOLVER(string value );
        public bool ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public bool ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public bool ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public bool ExistsByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public bool ExistsByCOR_TOLERANCIA_MENOS(Decimal value );
        public bool ExistsByCOR_TOLERANCIA_MAIS(Decimal value );
        public bool ExistsByCOR_PILHAS_POR_PALETE(int value );
        public bool ExistsByCOR_COR_FILA(string value );
        public bool ExistsByCOR_M_LINEAR_REALIZADO(Decimal value );
        public bool ExistsByPRO_ID_PALETE(string value );
        public bool ExistsByCOR_STATUS_PALETE(string value );
        public bool ExistsByCOR_GRUPO_PRODUTIVO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByCOR_ID(int value );
        public bool ExistsByCOR_STATUS(string value );
        public bool ExistsByCOR_STATUS_INTERFACE(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByCOR_ID_INTERFACE(int value );
        public bool ExistsByCOR_SEQUENCIA(int value );
        public bool ExistsByCOR_SEQUENCIA_ORIGEM(int value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByROT_SEQ_TRANFORMACAO(int value );
        public bool ExistsByCOR_FACAO(int value );
        public bool ExistsByCOR_FORMATO_BOBINA(int value );
        public bool ExistsByCOR_INICIO_PREVISTO(DateTime value );
        public bool ExistsByCOR_FIM_PREVISTO(DateTime value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByCOR_QTD_PLANEJADO(int value );
        public bool ExistsByPRO_QTD_PACAS(int value );
        public bool ExistsByCOR_PECAS_LARGURA(int value );
        public CorridasOnduladeiraDTO FirstByBOL_ID(string value );
        public CorridasOnduladeiraDTO FirstByBOL_ID_ORIGEM(string value );
        public CorridasOnduladeiraDTO FirstByPRO_LARGURA_PECA(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_LARGURA_PECA_PROGRAMADO(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_COMPRIMENTO_PECA(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_VINCOS_RECALCULADOS(string value );
        public CorridasOnduladeiraDTO FirstByCOR_SOLVER(string value );
        public CorridasOnduladeiraDTO FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_TOLERANCIA_MENOS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_TOLERANCIA_MAIS(Decimal value );
        public CorridasOnduladeiraDTO FirstByCOR_PILHAS_POR_PALETE(int value );
        public CorridasOnduladeiraDTO FirstByCOR_COR_FILA(string value );
        public CorridasOnduladeiraDTO FirstByCOR_M_LINEAR_REALIZADO(Decimal value );
        public CorridasOnduladeiraDTO FirstByPRO_ID_PALETE(string value );
        public CorridasOnduladeiraDTO FirstByCOR_STATUS_PALETE(string value );
        public CorridasOnduladeiraDTO FirstByCOR_GRUPO_PRODUTIVO(Decimal value );
        public CorridasOnduladeiraDTO FirstByTenantID(int value );
        public CorridasOnduladeiraDTO FirstByDeleted(bool value );
        public CorridasOnduladeiraDTO FirstByChanged(DateTime value );
        public CorridasOnduladeiraDTO FirstByUserId(int value );
        public CorridasOnduladeiraDTO FirstByCOR_ID(int value );
        public CorridasOnduladeiraDTO FirstByCOR_STATUS(string value );
        public CorridasOnduladeiraDTO FirstByCOR_STATUS_INTERFACE(string value );
        public CorridasOnduladeiraDTO FirstByMAQ_ID(string value );
        public CorridasOnduladeiraDTO FirstByCOR_ID_INTERFACE(int value );
        public CorridasOnduladeiraDTO FirstByCOR_SEQUENCIA(int value );
        public CorridasOnduladeiraDTO FirstByCOR_SEQUENCIA_ORIGEM(int value );
        public CorridasOnduladeiraDTO FirstByORD_ID(string value );
        public CorridasOnduladeiraDTO FirstByFPR_SEQ_REPETICAO(int value );
        public CorridasOnduladeiraDTO FirstByROT_SEQ_TRANFORMACAO(int value );
        public CorridasOnduladeiraDTO FirstByCOR_FACAO(int value );
        public CorridasOnduladeiraDTO FirstByCOR_FORMATO_BOBINA(int value );
        public CorridasOnduladeiraDTO FirstByCOR_INICIO_PREVISTO(DateTime value );
        public CorridasOnduladeiraDTO FirstByCOR_FIM_PREVISTO(DateTime value );
        public CorridasOnduladeiraDTO FirstByPRO_ID(string value );
        public CorridasOnduladeiraDTO FirstByCOR_QTD_PLANEJADO(int value );
        public CorridasOnduladeiraDTO FirstByPRO_QTD_PACAS(int value );
        public CorridasOnduladeiraDTO FirstByCOR_PECAS_LARGURA(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByBOL_ID(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByBOL_ID_ORIGEM(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_LARGURA_PECA(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_LARGURA_PECA_PROGRAMADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_COMPRIMENTO_PECA(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_VINCOS_RECALCULADOS(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SOLVER(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_TOLERANCIA_MENOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_TOLERANCIA_MAIS(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_PILHAS_POR_PALETE(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_COR_FILA(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_M_LINEAR_REALIZADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_ID_PALETE(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS_PALETE(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_GRUPO_PRODUTIVO(Decimal value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByUserId(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_ID(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_STATUS_INTERFACE(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_ID_INTERFACE(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SEQUENCIA(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_SEQUENCIA_ORIGEM(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByORD_ID(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByROT_SEQ_TRANFORMACAO(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FACAO(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FORMATO_BOBINA(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_INICIO_PREVISTO(DateTime value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_FIM_PREVISTO(DateTime value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_ID(string value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_QTD_PLANEJADO(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByPRO_QTD_PACAS(int value );
        public IEnumerable<CorridasOnduladeiraDTO> GetAllByCOR_PECAS_LARGURA(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration