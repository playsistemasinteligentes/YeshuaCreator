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
    public partial interface ITransportadoraWriteRepository
    {
        void Insert(ITransportadoraEntity transportadora);
        void Update(ITransportadoraEntity transportadora);
        void Delete(ITransportadoraEntity transportadora);
        void UpdateTRA_ID(int id, string value);
        void UpdateTRA_NOME(int id, string value);
        void UpdateTRA_EMAIL(int id, string value);
        void UpdateTRA_RESPONSAVEL(int id, string value);
        void UpdateTRA_FONE(int id, string value);
        void UpdateTRA_ID_INTEGRACAO(int id, string value);
        void UpdateTRA_ID_INTEGRACAO_ERP(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration