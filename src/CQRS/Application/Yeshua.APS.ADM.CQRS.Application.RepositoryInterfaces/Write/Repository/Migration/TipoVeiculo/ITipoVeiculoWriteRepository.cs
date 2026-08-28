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
    public partial interface ITipoVeiculoWriteRepository
    {
        void Insert(ITipoVeiculoEntity tipoveiculo);
        void Update(ITipoVeiculoEntity tipoveiculo);
        void Delete(ITipoVeiculoEntity tipoveiculo);
        void UpdateTIP_ID(int id, int value);
        void UpdateTIP_DESCRICAO(int id, string value);
        void UpdateTIP_QTD_DISPONIVEL(int id, int value);
        void UpdateTIP_VALOR_KM(int id, Decimal value);
        void UpdateTIP_VALOR_DIARIA(int id, Decimal value);
        void UpdateTIP_VALOR_AJUDANTE(int id, Decimal value);
        void UpdateTIP_QTD_EIXOS(int id, Decimal value);
        void UpdateTIP_VELOCIDADE_MEDIA(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_ALTURA(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_COMPRIMENTO(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_LARGURA(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_E(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_E(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_ALTURA_PESCOCO_D(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_LARGURA_PESCOCO_D(int id, Decimal value);
        void UpdateTIP_CAPACIDADE_M3(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration