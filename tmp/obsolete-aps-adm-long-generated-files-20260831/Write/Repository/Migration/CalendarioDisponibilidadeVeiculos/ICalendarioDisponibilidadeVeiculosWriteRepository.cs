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
    public partial interface ICalendarioDisponibilidadeVeiculosWriteRepository
    {
        void Insert(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos);
        void Update(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos);
        void Delete(ICalendarioDisponibilidadeVeiculosEntity calendariodisponibilidadeveiculos);
        void UpdateCDV_ID(int id, int value);
        void UpdateCDV_DATA_DE(int id, DateTime value);
        void UpdateCDV_DATA_ATE(int id, DateTime value);
        void UpdateCDV_SEGUNDA(int id, int value);
        void UpdateCDV_TERCA(int id, int value);
        void UpdateCDV_QUARTA(int id, int value);
        void UpdateCDV_QUINTA(int id, int value);
        void UpdateCDV_SEXTA(int id, int value);
        void UpdateCDV_SABADO(int id, int value);
        void UpdateCDV_DOMINGO(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration