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
    public partial interface IMDFeVeiculoWriteRepository
    {
        void Insert(IMDFeVeiculoEntity mdfeveiculo);
        void Update(IMDFeVeiculoEntity mdfeveiculo);
        void Delete(IMDFeVeiculoEntity mdfeveiculo);
        void UpdateMDFeSolicitacaoFiscalId(int id, int value);
        void UpdatePlaca(int id, string value);
        void UpdateRenavam(int id, string value);
        void UpdateTara(int id, Decimal value);
        void UpdateCapacidadeKg(int id, Decimal value);
        void UpdateCapacidadeM3(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration