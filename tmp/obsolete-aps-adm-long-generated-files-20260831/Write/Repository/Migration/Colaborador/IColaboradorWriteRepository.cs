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
    public partial interface IColaboradorWriteRepository
    {
        void Insert(IColaboradorEntity colaborador);
        void Update(IColaboradorEntity colaborador);
        void Delete(IColaboradorEntity colaborador);
        void UpdateCOL_NOME(string col_cpf, string value);
        void UpdateCOL_NASCIMENTO(string col_cpf, DateTime value);
        void UpdateCOL_EMAIL(string col_cpf, string value);
        void UpdateCOL_MATRICULA(string col_cpf, string value);
        void UpdateTURM_id(string col_cpf, string value);
        void UpdateTenantID(string col_cpf, int value);
        void UpdateDeleted(string col_cpf, bool value);
        void UpdateChanged(string col_cpf, DateTime value);
        void UpdateUserId(string col_cpf, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration