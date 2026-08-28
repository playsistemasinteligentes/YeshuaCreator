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
    public partial interface IClpMedicoesWriteRepository
    {
        void Insert(IClpMedicoesEntity clpmedicoes);
        void Update(IClpMedicoesEntity clpmedicoes);
        void Delete(IClpMedicoesEntity clpmedicoes);
        void UpdateId2(int id, int value);
        void UpdateMaquinaId(int id, string value);
        void UpdateDataInicio(int id, DateTime value);
        void UpdateDataFim(int id, DateTime value);
        void UpdateEmissao(int id, DateTime value);
        void UpdateQuantidade(int id, Decimal value);
        void UpdateGrupo(int id, Decimal value);
        void UpdateStatus(int id, int value);
        void UpdateTurnoId(int id, string value);
        void UpdateTurmaId(int id, string value);
        void UpdateIdLoteClp(int id, int value);
        void UpdateOcorrenciaId(int id, string value);
        void UpdateFase(int id, int value);
        void UpdateClpOrigem(int id, string value);
        void UpdateCLP_LOTE(int id, int value);
        void UpdateCOMPACTA(int id, int value);
        void UpdateBOL_ID(int id, string value);
        void UpdateCOR_SEQUENCIA(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration