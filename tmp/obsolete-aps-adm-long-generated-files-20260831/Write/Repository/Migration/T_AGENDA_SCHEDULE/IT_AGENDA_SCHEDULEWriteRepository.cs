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
    public partial interface IT_AGENDA_SCHEDULEWriteRepository
    {
        void Insert(IT_AGENDA_SCHEDULEEntity t_agenda_schedule);
        void Update(IT_AGENDA_SCHEDULEEntity t_agenda_schedule);
        void Delete(IT_AGENDA_SCHEDULEEntity t_agenda_schedule);
        void UpdateAGE_ID(int id, int value);
        void UpdateAGE_DATA_ESPECIFICA(int id, DateTime value);
        void UpdateAGE_HORARIO_INICIO(int id, string value);
        void UpdateAGE_HORARIO_FIM(int id, string value);
        void UpdateAGE_SEGUNDA(int id, string value);
        void UpdateAGE_TERCA(int id, string value);
        void UpdateAGE_QUARTA(int id, string value);
        void UpdateAGE_QUINTA(int id, string value);
        void UpdateAGE_SEXTA(int id, string value);
        void UpdateAGE_SABADO(int id, string value);
        void UpdateAGE_DOMINGO(int id, string value);
        void UpdateAGE_INTERVALO(int id, Decimal value);
        void UpdateAGE_ORDEM_EXECUCAO(int id, string value);
        void UpdateAGE_PARAMETROS(int id, string value);
        void UpdateAGE_EXCECAO(int id, string value);
        void UpdateAGE_DESCRICAO(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration