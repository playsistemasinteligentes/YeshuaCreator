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
    public partial interface IPendenciasInterfaceWriteRepository
    {
        void Insert(IPendenciasInterfaceEntity pendenciasinterface);
        void Update(IPendenciasInterfaceEntity pendenciasinterface);
        void Delete(IPendenciasInterfaceEntity pendenciasinterface);
        void UpdatePEN_STATUS_OUT(int pen_id, string value);
        void UpdatePEN_PROTOCOLO_OUT(int pen_id, string value);
        void UpdatePEN_ID_PROTOCOLO_OUT(int pen_id, string value);
        void UpdatePEN_STATUS_IN(int pen_id, string value);
        void UpdatePEN_PROTOCOLO_IN(int pen_id, string value);
        void UpdatePEN_ID_PROTOCOLO_IN(int pen_id, string value);
        void UpdateDATA_ENTRADA(int pen_id, DateTime value);
        void UpdateTenantID(int pen_id, int value);
        void UpdateDeleted(int pen_id, bool value);
        void UpdateChanged(int pen_id, DateTime value);
        void UpdateUserId(int pen_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration