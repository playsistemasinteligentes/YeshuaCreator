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
    public partial interface IBoletimWriteRepository
    {
        void Insert(IBoletimEntity boletim);
        void Update(IBoletimEntity boletim);
        void Delete(IBoletimEntity boletim);
        void UpdateBOL_ID(int id, string value);
        void UpdateBOL_ID_ORIGEM(int id, string value);
        void UpdateBOL_SOLVER(int id, string value);
        void UpdateBOL_INTEGRACAO(int id, string value);
        void UpdateBOL_SEQUENCIA(int id, Decimal value);
        void UpdateGRP_PAP_GRAMATURA_PROGRAMADO(int id, Decimal value);
        void UpdateGRP_ID_PROGRAMADO(int id, string value);
        void UpdateGRP_PAPEL1_PROGRAMADO(int id, string value);
        void UpdateGRP_PAPEL2_PROGRAMADO(int id, string value);
        void UpdateGRP_PAPEL3_PROGRAMADO(int id, string value);
        void UpdateGRP_PAPEL4_PROGRAMADO(int id, string value);
        void UpdateGRP_PAPEL5_PROGRAMADO(int id, string value);
        void UpdateBOL_STATUS_INTERFACE(int id, string value);
        void UpdateBOL_TIPO(int id, string value);
        void UpdateBOL_FORMATO(int id, int value);
        void UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value);
        void UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(int id, Decimal value);
        void UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value);
        void UpdateBOL_CUSTO_PAPEIS_REALIZADO(int id, Decimal value);
        void UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value);
        void UpdateBOL_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value);
        void UpdateBOL_REFILE_OBRIGATORIO(int id, int value);
        void UpdateBOL_OBS(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration