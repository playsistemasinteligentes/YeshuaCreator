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
    public partial interface ITipoVeiculoReadRepository
    {
        public DataPagination<TipoVeiculoDTO> getTipoVeiculo(ICommandRead command );
        public IEnumerable<TipoVeiculoTenantIDDTO> getTipoVeiculoReadFKTenantID(object command );
        public IEnumerable<TipoVeiculoUserIdDTO> getTipoVeiculoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByTIP_DESCRICAO(string value );
        public bool ExistsByTIP_QTD_DISPONIVEL(int value );
        public bool ExistsByTIP_VALOR_KM(Decimal value );
        public bool ExistsByTIP_VALOR_DIARIA(Decimal value );
        public bool ExistsByTIP_VALOR_AJUDANTE(Decimal value );
        public bool ExistsByTIP_QTD_EIXOS(Decimal value );
        public bool ExistsByTIP_VELOCIDADE_MEDIA(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_ALTURA(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_LARGURA(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value );
        public bool ExistsByTIP_CAPACIDADE_M3(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoVeiculoDTO FirstById(int value );
        public TipoVeiculoDTO FirstByTIP_ID(int value );
        public TipoVeiculoDTO FirstByTIP_DESCRICAO(string value );
        public TipoVeiculoDTO FirstByTIP_QTD_DISPONIVEL(int value );
        public TipoVeiculoDTO FirstByTIP_VALOR_KM(Decimal value );
        public TipoVeiculoDTO FirstByTIP_VALOR_DIARIA(Decimal value );
        public TipoVeiculoDTO FirstByTIP_VALOR_AJUDANTE(Decimal value );
        public TipoVeiculoDTO FirstByTIP_QTD_EIXOS(Decimal value );
        public TipoVeiculoDTO FirstByTIP_VELOCIDADE_MEDIA(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value );
        public TipoVeiculoDTO FirstByTIP_CAPACIDADE_M3(Decimal value );
        public TipoVeiculoDTO FirstByTenantID(int value );
        public TipoVeiculoDTO FirstByDeleted(bool value );
        public TipoVeiculoDTO FirstByChanged(DateTime value );
        public TipoVeiculoDTO FirstByUserId(int value );
        public IEnumerable<TipoVeiculoDTO> GetAllById(int value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_ID(int value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_DESCRICAO(string value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_QTD_DISPONIVEL(int value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_KM(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_DIARIA(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VALOR_AJUDANTE(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_QTD_EIXOS(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_VELOCIDADE_MEDIA(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA_PESCOCO_E(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA_PESCOCO_E(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_ALTURA_PESCOCO_D(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_LARGURA_PESCOCO_D(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTIP_CAPACIDADE_M3(Decimal value );
        public IEnumerable<TipoVeiculoDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoVeiculoDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoVeiculoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoVeiculoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration