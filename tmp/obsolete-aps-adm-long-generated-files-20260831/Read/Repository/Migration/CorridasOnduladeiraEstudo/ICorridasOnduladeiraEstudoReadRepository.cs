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
    public partial interface ICorridasOnduladeiraEstudoReadRepository
    {
        public DataPagination<CorridasOnduladeiraEstudoDTO> getCorridasOnduladeiraEstudo(ICommandRead command );
        public IEnumerable<CorridasOnduladeiraEstudoTenantIDDTO> getCorridasOnduladeiraEstudoReadFKTenantID(object command );
        public IEnumerable<CorridasOnduladeiraEstudoUserIdDTO> getCorridasOnduladeiraEstudoReadFKUserId(object command );
        public bool ExistsById(int value );
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
        public bool ExistsByCOR_M_LINEAR_REALIZADO(Decimal value );
        public bool ExistsByPRO_ID_PALETE(string value );
        public bool ExistsByCOR_STATUS_PALETE(string value );
        public bool ExistsByCOR_GRUPO_PRODUTIVO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CorridasOnduladeiraEstudoDTO FirstById(int value );
        public CorridasOnduladeiraEstudoDTO FirstByBOL_ID(string value );
        public CorridasOnduladeiraEstudoDTO FirstByBOL_ID_ORIGEM(string value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_LARGURA_PECA(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_LARGURA_PECA_PROGRAMADO(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_COMPRIMENTO_PECA(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_VINCOS_RECALCULADOS(string value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_SOLVER(string value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_TOLERANCIA_MENOS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_TOLERANCIA_MAIS(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_PILHAS_POR_PALETE(int value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_M_LINEAR_REALIZADO(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByPRO_ID_PALETE(string value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_STATUS_PALETE(string value );
        public CorridasOnduladeiraEstudoDTO FirstByCOR_GRUPO_PRODUTIVO(Decimal value );
        public CorridasOnduladeiraEstudoDTO FirstByTenantID(int value );
        public CorridasOnduladeiraEstudoDTO FirstByDeleted(bool value );
        public CorridasOnduladeiraEstudoDTO FirstByChanged(DateTime value );
        public CorridasOnduladeiraEstudoDTO FirstByUserId(int value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllById(int value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByBOL_ID(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByBOL_ID_ORIGEM(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_LARGURA_PECA(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_LARGURA_PECA_PROGRAMADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_COMPRIMENTO_PECA(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_COMPRIMENTO_PECA_PROGRAMADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_UTILIZOU_REFILE_OBRIGATORIO(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_VINCOS_RECALCULADOS(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_SOLVER(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_TOLERANCIA_MENOS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_TOLERANCIA_MAIS(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_PILHAS_POR_PALETE(int value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_M_LINEAR_REALIZADO(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByPRO_ID_PALETE(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_STATUS_PALETE(string value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByCOR_GRUPO_PRODUTIVO(Decimal value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByTenantID(int value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CorridasOnduladeiraEstudoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration