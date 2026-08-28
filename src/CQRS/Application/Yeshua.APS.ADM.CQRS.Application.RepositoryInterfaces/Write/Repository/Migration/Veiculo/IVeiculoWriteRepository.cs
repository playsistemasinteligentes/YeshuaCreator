// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IVeiculoWriteRepository
    {
        void Insert(IVeiculoEntity veiculo);
        void Update(IVeiculoEntity veiculo);
        void Delete(IVeiculoEntity veiculo);
        void UpdateVEI_PLACA(int id, string value);
        void UpdateTIP_ID(int id, int value);
        void UpdateVEI_CAPACIDADE_M3(int id, Decimal value);
        void UpdateVEI_CAPACIDADE_LARGURA(int id, Decimal value);
        void UpdateVEI_CAPACIDADE_COMPRIMENTO(int id, Decimal value);
        void UpdateVEI_CAPACIDADE_ALTURA(int id, Decimal value);
        void UpdateVEI_MODELO(int id, string value);
        void UpdateVEI_NOME_MOTORISTA(int id, string value);
        void UpdateVEI_DADOS_CONTATO(int id, string value);
        void UpdateVEI_CPF_MOTORISTA(int id, string value);
        void UpdateTCA_ID(int id, string value);
        void UpdateVEI_EMISSAO(int id, DateTime value);
        void UpdateVEI_VENCIMENTO(int id, DateTime value);
        void UpdateVEI_STATUS(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration