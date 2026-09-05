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
    public partial interface ISefazEndpointWriteRepository
    {
        void Insert(ISefazEndpointEntity sefazendpoint);
        void Update(ISefazEndpointEntity sefazendpoint);
        void Delete(ISefazEndpointEntity sefazendpoint);
        void UpdateProdutoFiscal(int id, int value);
        void UpdateUF(int id, string value);
        void UpdateAmbiente(int id, int value);
        void UpdateServico(int id, string value);
        void UpdateVersao(int id, string value);
        void UpdateUrl(int id, string value);
        void UpdateAtivo(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration