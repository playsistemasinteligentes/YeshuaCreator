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
    public partial interface ICTeComplementoIcmsFiscalWriteRepository
    {
        void Insert(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal);
        void Update(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal);
        void Delete(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal);
        void UpdateCTeSolicitacaoFiscalId(int id, int value);
        void UpdateValorPrestacaoComplementar(int id, Decimal value);
        void UpdateCST(int id, string value);
        void UpdateValorBaseCalculo(int id, Decimal value);
        void UpdateAliquotaICMS(int id, Decimal value);
        void UpdateValorICMS(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
        void UpdateOperationalEntityId(int id, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration