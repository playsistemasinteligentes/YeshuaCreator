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
    public partial interface ICorridasOnduladeiraEstudoWriteRepository
    {
        void Insert(ICorridasOnduladeiraEstudoEntity corridasonduladeiraestudo);
        void Update(ICorridasOnduladeiraEstudoEntity corridasonduladeiraestudo);
        void Delete(ICorridasOnduladeiraEstudoEntity corridasonduladeiraestudo);
        void UpdateBOL_ID(int id, string value);
        void UpdateBOL_ID_ORIGEM(int id, string value);
        void UpdatePRO_LARGURA_PECA(int id, Decimal value);
        void UpdatePRO_LARGURA_PECA_PROGRAMADO(int id, Decimal value);
        void UpdatePRO_COMPRIMENTO_PECA(int id, Decimal value);
        void UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int id, Decimal value);
        void UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int id, Decimal value);
        void UpdatePRO_VINCOS_RECALCULADOS(int id, string value);
        void UpdateCOR_SOLVER(int id, string value);
        void UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value);
        void UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value);
        void UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value);
        void UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value);
        void UpdateCOR_TOLERANCIA_MENOS(int id, Decimal value);
        void UpdateCOR_TOLERANCIA_MAIS(int id, Decimal value);
        void UpdateCOR_PILHAS_POR_PALETE(int id, int value);
        void UpdateCOR_M_LINEAR_REALIZADO(int id, Decimal value);
        void UpdatePRO_ID_PALETE(int id, string value);
        void UpdateCOR_STATUS_PALETE(int id, string value);
        void UpdateCOR_GRUPO_PRODUTIVO(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration