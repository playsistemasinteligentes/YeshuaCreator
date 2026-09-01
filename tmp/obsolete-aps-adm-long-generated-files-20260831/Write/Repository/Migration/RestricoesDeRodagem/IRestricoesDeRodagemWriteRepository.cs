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
    public partial interface IRestricoesDeRodagemWriteRepository
    {
        void Insert(IRestricoesDeRodagemEntity restricoesderodagem);
        void Update(IRestricoesDeRodagemEntity restricoesderodagem);
        void Delete(IRestricoesDeRodagemEntity restricoesderodagem);
        void UpdateRES_ID(int id, int value);
        void UpdateRES_TIPO(int id, string value);
        void UpdateRES_HORA_INI(int id, string value);
        void UpdateRES_HORA_FIM(int id, string value);
        void UpdateRES_VELOCIDADE_HORA_RUSH(int id, Decimal value);
        void UpdateTVE_ID(int id, int value);
        void UpdateMAP_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration