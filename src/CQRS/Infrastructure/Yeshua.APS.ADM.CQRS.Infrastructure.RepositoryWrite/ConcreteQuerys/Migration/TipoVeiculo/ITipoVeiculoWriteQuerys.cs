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

    public interface ITipoVeiculoQueryWrite 
     {
        public QueryModel InserirTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo);
        public QueryModel UpdateTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo);
        QueryModel UpdateTIP_ID(int id, int value);
        QueryModel UpdateTIP_DESCRICAO(int id, string value);
        QueryModel UpdateTIP_QTD_DISPONIVEL(int id, int value);
        QueryModel UpdateTIP_VALOR_KM(int id, Decimal value);
        QueryModel UpdateTIP_VALOR_DIARIA(int id, Decimal value);
        QueryModel UpdateTIP_VALOR_AJUDANTE(int id, Decimal value);
        QueryModel UpdateTIP_QTD_EIXOS(int id, Decimal value);
        QueryModel UpdateTIP_VELOCIDADE_MEDIA(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_ALTURA(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_LARGURA(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_E(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_E(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_D(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_D(int id, Decimal value);
        QueryModel UpdateTIP_CAPACIDADE_M3(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTipoVeiculoQuery(ITipoVeiculoEntity TipoVeiculo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration