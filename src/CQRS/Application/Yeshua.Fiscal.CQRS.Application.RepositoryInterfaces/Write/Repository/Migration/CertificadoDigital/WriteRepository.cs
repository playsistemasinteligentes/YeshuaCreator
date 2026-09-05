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
    public partial interface ICertificadoDigitalWriteRepository
    {
        void Insert(ICertificadoDigitalEntity certificadodigital);
        void Update(ICertificadoDigitalEntity certificadodigital);
        void Delete(ICertificadoDigitalEntity certificadodigital);
        void UpdateApelido(int id, string value);
        void UpdateDocumentoTitular(int id, string value);
        void UpdateStorageKey(int id, string value);
        void UpdateThumbprint(int id, string value);
        void UpdateValidoDe(int id, DateTime value);
        void UpdateValidoAte(int id, DateTime value);
        void UpdateAtivo(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration