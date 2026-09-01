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
    public partial interface ITipoInspecaoVisualWriteRepository
    {
        void Insert(ITipoInspecaoVisualEntity tipoinspecaovisual);
        void Update(ITipoInspecaoVisualEntity tipoinspecaovisual);
        void Delete(ITipoInspecaoVisualEntity tipoinspecaovisual);
        void UpdateTIV_ID(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
        void UpdateTIV_NOME(int id, string value);
        void UpdateTIV_DESCRICAO(int id, string value);
        void UpdateTIV_FECHAMENTO(int id, string value);
        void UpdateTIV_AMOSTRA_ALEATORIA(int id, string value);
        void UpdateTIV_N_AMOSTRAS(int id, int value);
        void UpdateTIV_MEDIDA(int id, string value);
        void UpdateTIV_ESPECIFICACAO(int id, Decimal value);
        void UpdateTIV_TOL_MAIS(int id, Decimal value);
        void UpdateTIV_TOL_MENOS(int id, Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration