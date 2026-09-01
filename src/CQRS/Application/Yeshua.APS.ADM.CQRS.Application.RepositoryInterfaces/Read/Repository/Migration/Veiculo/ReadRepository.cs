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
    public partial interface IVeiculoReadRepository
    {
        public DataPagination<VeiculoDTO> getVeiculo(ICommandRead command );
        public IEnumerable<VeiculoTenantIDDTO> getVeiculoReadFKTenantID(object command );
        public IEnumerable<VeiculoUserIdDTO> getVeiculoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByVEI_PLACA(string value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByVEI_CAPACIDADE_M3(Decimal value );
        public bool ExistsByVEI_CAPACIDADE_LARGURA(Decimal value );
        public bool ExistsByVEI_CAPACIDADE_COMPRIMENTO(Decimal value );
        public bool ExistsByVEI_CAPACIDADE_ALTURA(Decimal value );
        public bool ExistsByVEI_MODELO(string value );
        public bool ExistsByVEI_NOME_MOTORISTA(string value );
        public bool ExistsByVEI_DADOS_CONTATO(string value );
        public bool ExistsByVEI_CPF_MOTORISTA(string value );
        public bool ExistsByTCA_ID(string value );
        public bool ExistsByVEI_EMISSAO(DateTime value );
        public bool ExistsByVEI_VENCIMENTO(DateTime value );
        public bool ExistsByVEI_STATUS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VeiculoDTO FirstById(int value );
        public VeiculoDTO FirstByVEI_PLACA(string value );
        public VeiculoDTO FirstByTIP_ID(int value );
        public VeiculoDTO FirstByVEI_CAPACIDADE_M3(Decimal value );
        public VeiculoDTO FirstByVEI_CAPACIDADE_LARGURA(Decimal value );
        public VeiculoDTO FirstByVEI_CAPACIDADE_COMPRIMENTO(Decimal value );
        public VeiculoDTO FirstByVEI_CAPACIDADE_ALTURA(Decimal value );
        public VeiculoDTO FirstByVEI_MODELO(string value );
        public VeiculoDTO FirstByVEI_NOME_MOTORISTA(string value );
        public VeiculoDTO FirstByVEI_DADOS_CONTATO(string value );
        public VeiculoDTO FirstByVEI_CPF_MOTORISTA(string value );
        public VeiculoDTO FirstByTCA_ID(string value );
        public VeiculoDTO FirstByVEI_EMISSAO(DateTime value );
        public VeiculoDTO FirstByVEI_VENCIMENTO(DateTime value );
        public VeiculoDTO FirstByVEI_STATUS(string value );
        public VeiculoDTO FirstByTenantID(int value );
        public VeiculoDTO FirstByDeleted(bool value );
        public VeiculoDTO FirstByChanged(DateTime value );
        public VeiculoDTO FirstByUserId(int value );
        public IEnumerable<VeiculoDTO> GetAllById(int value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_PLACA(string value );
        public IEnumerable<VeiculoDTO> GetAllByTIP_ID(int value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_M3(Decimal value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_LARGURA(Decimal value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_COMPRIMENTO(Decimal value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_CAPACIDADE_ALTURA(Decimal value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_MODELO(string value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_NOME_MOTORISTA(string value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_DADOS_CONTATO(string value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_CPF_MOTORISTA(string value );
        public IEnumerable<VeiculoDTO> GetAllByTCA_ID(string value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_EMISSAO(DateTime value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_VENCIMENTO(DateTime value );
        public IEnumerable<VeiculoDTO> GetAllByVEI_STATUS(string value );
        public IEnumerable<VeiculoDTO> GetAllByTenantID(int value );
        public IEnumerable<VeiculoDTO> GetAllByDeleted(bool value );
        public IEnumerable<VeiculoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VeiculoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration