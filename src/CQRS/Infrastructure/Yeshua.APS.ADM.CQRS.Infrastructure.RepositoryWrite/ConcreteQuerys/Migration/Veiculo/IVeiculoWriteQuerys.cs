// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IVeiculoQueryWrite 
     {
        public QueryModel InserirVeiculoQuery(IVeiculoEntity Veiculo);
        public QueryModel UpdateVeiculoQuery(IVeiculoEntity Veiculo);
        QueryModel UpdateVEI_PLACA(int id, string value);
        QueryModel UpdateVEI_UF(int id, string value);
        QueryModel UpdateTIP_ID(int id, int value);
        QueryModel UpdateVEI_CAPACIDADE_M3(int id, Decimal value);
        QueryModel UpdateVEI_CAPACIDADE_LARGURA(int id, Decimal value);
        QueryModel UpdateVEI_CAPACIDADE_COMPRIMENTO(int id, Decimal value);
        QueryModel UpdateVEI_CAPACIDADE_ALTURA(int id, Decimal value);
        QueryModel UpdateVEI_MODELO(int id, string value);
        QueryModel UpdateVEI_NOME_MOTORISTA(int id, string value);
        QueryModel UpdateVEI_DADOS_CONTATO(int id, string value);
        QueryModel UpdateVEI_CPF_MOTORISTA(int id, string value);
        QueryModel UpdateTCA_ID(int id, string value);
        QueryModel UpdateVEI_EMISSAO(int id, DateTime value);
        QueryModel UpdateVEI_VENCIMENTO(int id, DateTime value);
        QueryModel UpdateVEI_STATUS(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteVeiculoQuery(IVeiculoEntity Veiculo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration