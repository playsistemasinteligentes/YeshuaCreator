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
    public partial interface IRelatoriosWriteRepository
    {
        void Insert(IRelatoriosEntity relatorios);
        void Update(IRelatoriosEntity relatorios);
        void Delete(IRelatoriosEntity relatorios);
        void UpdateREL_NOME_RELATORIO(int rel_id, string value);
        void UpdateREL_NOME_CAMPO(int rel_id, string value);
        void UpdateREL_TIPO_CAMPO(int rel_id, string value);
        void UpdateREL_POS_X(int rel_id, int value);
        void UpdateREL_POS_Y(int rel_id, int value);
        void UpdateREL_TAMANHO_FONTE(int rel_id, int value);
        void UpdateTenantID(int rel_id, int value);
        void UpdateDeleted(int rel_id, bool value);
        void UpdateChanged(int rel_id, DateTime value);
        void UpdateUserId(int rel_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration