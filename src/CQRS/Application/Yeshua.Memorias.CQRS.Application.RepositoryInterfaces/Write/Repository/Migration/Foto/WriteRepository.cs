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
    public partial interface IFotoWriteRepository
    {
        void Insert(IFotoEntity foto);
        void Update(IFotoEntity foto);
        void Delete(IFotoEntity foto);
        void UpdateStorageKey(int id, string value);
        void UpdateNomeOriginal(int id, string value);
        void UpdateContentType(int id, string value);
        void UpdateHashArquivo(int id, string value);
        void UpdateCapturadaEmUtc(int id, DateTime value);
        void UpdateLargura(int id, int value);
        void UpdateAltura(int id, int value);
        void UpdateStatus(int id, int value);
        void UpdateOperationalEntityId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration