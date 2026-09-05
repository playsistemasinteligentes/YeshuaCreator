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
    public partial interface IMDFeVeiculoReadRepository
    {
        public DataPagination<MDFeVeiculoDTO> getMDFeVeiculo(ICommandRead command );
        public IEnumerable<MDFeVeiculoMDFeSolicitacaoFiscalIdDTO> getMDFeVeiculoReadFKMDFeSolicitacaoFiscalId(object command );
        public IEnumerable<MDFeVeiculoTenantIDDTO> getMDFeVeiculoReadFKTenantID(object command );
        public IEnumerable<MDFeVeiculoUserIdDTO> getMDFeVeiculoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeSolicitacaoFiscalId(int value );
        public bool ExistsByPlaca(string value );
        public bool ExistsByRenavam(string value );
        public bool ExistsByTara(Decimal value );
        public bool ExistsByCapacidadeKg(Decimal value );
        public bool ExistsByCapacidadeM3(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeVeiculoDTO FirstById(int value );
        public MDFeVeiculoDTO FirstByMDFeSolicitacaoFiscalId(int value );
        public MDFeVeiculoDTO FirstByPlaca(string value );
        public MDFeVeiculoDTO FirstByRenavam(string value );
        public MDFeVeiculoDTO FirstByTara(Decimal value );
        public MDFeVeiculoDTO FirstByCapacidadeKg(Decimal value );
        public MDFeVeiculoDTO FirstByCapacidadeM3(Decimal value );
        public MDFeVeiculoDTO FirstByTenantID(int value );
        public MDFeVeiculoDTO FirstByDeleted(bool value );
        public MDFeVeiculoDTO FirstByChanged(DateTime value );
        public MDFeVeiculoDTO FirstByUserId(int value );
        public IEnumerable<MDFeVeiculoDTO> GetAllById(int value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByMDFeSolicitacaoFiscalId(int value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByPlaca(string value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByRenavam(string value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByTara(Decimal value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByCapacidadeKg(Decimal value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByCapacidadeM3(Decimal value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeVeiculoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration