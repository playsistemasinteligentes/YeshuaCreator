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
    public partial interface IMunicipioWriteRepository
    {
        void Insert(IMunicipioEntity municipio);
        void Update(IMunicipioEntity municipio);
        void Delete(IMunicipioEntity municipio);
        void UpdateMUN_NOME(string mun_id, string value);
        void UpdateUF_COD(string mun_id, string value);
        void UpdateMUN_CODIGO_IBGE(string mun_id, string value);
        void UpdateMUN_LATITUDE(string mun_id, Decimal value);
        void UpdateMUN_LONGITUDE(string mun_id, Decimal value);
        void UpdateMUN_ID_INTEGRACAO_ERP(string mun_id, string value);
        void UpdateMUN_CODIGO_SIAFI(string mun_id, string value);
        void UpdateMUN_CODIGO_CNPJ(string mun_id, string value);
        void UpdateMUN_DISTANCIA_KM(string mun_id, Decimal value);
        void UpdateTenantID(string mun_id, int value);
        void UpdateDeleted(string mun_id, bool value);
        void UpdateChanged(string mun_id, DateTime value);
        void UpdateUserId(string mun_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration