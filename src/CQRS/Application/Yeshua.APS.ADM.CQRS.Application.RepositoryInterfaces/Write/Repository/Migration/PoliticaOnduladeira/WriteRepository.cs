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
    public partial interface IPoliticaOnduladeiraWriteRepository
    {
        void Insert(IPoliticaOnduladeiraEntity politicaonduladeira);
        void Update(IPoliticaOnduladeiraEntity politicaonduladeira);
        void Delete(IPoliticaOnduladeiraEntity politicaonduladeira);
        void UpdatePOL_ID(int id, int value);
        void UpdatePOL_NIVEL(int id, int value);
        void UpdatePOL_PROMOCAO(int id, int value);
        void UpdatePOL_DIAS_ANTECIPACAO(int id, int value);
        void UpdatePOL_METROS_LINEARES(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration