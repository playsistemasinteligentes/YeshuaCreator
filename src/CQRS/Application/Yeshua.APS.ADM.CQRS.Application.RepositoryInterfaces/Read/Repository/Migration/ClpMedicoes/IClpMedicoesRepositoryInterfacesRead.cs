// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IClpMedicoesReadRepository
    {
        public DataPagination<ClpMedicoesDTO> getClpMedicoes(ICommandRead command );
        public IEnumerable<ClpMedicoesTenantIDDTO> getClpMedicoesReadFKTenantID(object command );
        public IEnumerable<ClpMedicoesUserIdDTO> getClpMedicoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsById2(int value );
        public bool ExistsByMaquinaId(string value );
        public bool ExistsByDataInicio(DateTime value );
        public bool ExistsByDataFim(DateTime value );
        public bool ExistsByEmissao(DateTime value );
        public bool ExistsByQuantidade(Decimal value );
        public bool ExistsByGrupo(Decimal value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTurnoId(string value );
        public bool ExistsByTurmaId(string value );
        public bool ExistsByIdLoteClp(int value );
        public bool ExistsByOcorrenciaId(string value );
        public bool ExistsByFase(int value );
        public bool ExistsByClpOrigem(string value );
        public bool ExistsByCLP_LOTE(int value );
        public bool ExistsByCOMPACTA(int value );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByCOR_SEQUENCIA(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ClpMedicoesDTO FirstById(int value );
        public ClpMedicoesDTO FirstById2(int value );
        public ClpMedicoesDTO FirstByMaquinaId(string value );
        public ClpMedicoesDTO FirstByDataInicio(DateTime value );
        public ClpMedicoesDTO FirstByDataFim(DateTime value );
        public ClpMedicoesDTO FirstByEmissao(DateTime value );
        public ClpMedicoesDTO FirstByQuantidade(Decimal value );
        public ClpMedicoesDTO FirstByGrupo(Decimal value );
        public ClpMedicoesDTO FirstByStatus(int value );
        public ClpMedicoesDTO FirstByTurnoId(string value );
        public ClpMedicoesDTO FirstByTurmaId(string value );
        public ClpMedicoesDTO FirstByIdLoteClp(int value );
        public ClpMedicoesDTO FirstByOcorrenciaId(string value );
        public ClpMedicoesDTO FirstByFase(int value );
        public ClpMedicoesDTO FirstByClpOrigem(string value );
        public ClpMedicoesDTO FirstByCLP_LOTE(int value );
        public ClpMedicoesDTO FirstByCOMPACTA(int value );
        public ClpMedicoesDTO FirstByBOL_ID(string value );
        public ClpMedicoesDTO FirstByCOR_SEQUENCIA(int value );
        public ClpMedicoesDTO FirstByTenantID(int value );
        public ClpMedicoesDTO FirstByDeleted(bool value );
        public ClpMedicoesDTO FirstByChanged(DateTime value );
        public ClpMedicoesDTO FirstByUserId(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllById(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllById2(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByMaquinaId(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByDataInicio(DateTime value );
        public IEnumerable<ClpMedicoesDTO> GetAllByDataFim(DateTime value );
        public IEnumerable<ClpMedicoesDTO> GetAllByEmissao(DateTime value );
        public IEnumerable<ClpMedicoesDTO> GetAllByQuantidade(Decimal value );
        public IEnumerable<ClpMedicoesDTO> GetAllByGrupo(Decimal value );
        public IEnumerable<ClpMedicoesDTO> GetAllByStatus(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByTurnoId(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByTurmaId(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByIdLoteClp(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByOcorrenciaId(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByFase(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByClpOrigem(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByCLP_LOTE(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByCOMPACTA(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByBOL_ID(string value );
        public IEnumerable<ClpMedicoesDTO> GetAllByCOR_SEQUENCIA(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByTenantID(int value );
        public IEnumerable<ClpMedicoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<ClpMedicoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ClpMedicoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration