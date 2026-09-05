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
    public partial interface IMDFeReadRepository
    {
        public DataPagination<MDFeDTO> getMDFe(ICommandRead command );
        public IEnumerable<MDFeTenantIDDTO> getMDFeReadFKTenantID(object command );
        public IEnumerable<MDFeUserIdDTO> getMDFeReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsBySerie(int value );
        public bool ExistsByNumero(int value );
        public bool ExistsByUfCarregamento(string value );
        public bool ExistsByUfDescarregamento(string value );
        public bool ExistsByPlacaVeiculo(string value );
        public bool ExistsByEmitidoEm(DateTime value );
        public bool ExistsByAutorizadoEm(DateTime value );
        public bool ExistsByIniciadoEm(DateTime value );
        public bool ExistsByEncerradoEm(DateTime value );
        public bool ExistsByCanceladoEm(DateTime value );
        public bool ExistsBySituacao(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeDTO FirstById(int value );
        public MDFeDTO FirstByChaveAcesso(string value );
        public MDFeDTO FirstBySerie(int value );
        public MDFeDTO FirstByNumero(int value );
        public MDFeDTO FirstByUfCarregamento(string value );
        public MDFeDTO FirstByUfDescarregamento(string value );
        public MDFeDTO FirstByPlacaVeiculo(string value );
        public MDFeDTO FirstByEmitidoEm(DateTime value );
        public MDFeDTO FirstByAutorizadoEm(DateTime value );
        public MDFeDTO FirstByIniciadoEm(DateTime value );
        public MDFeDTO FirstByEncerradoEm(DateTime value );
        public MDFeDTO FirstByCanceladoEm(DateTime value );
        public MDFeDTO FirstBySituacao(int value );
        public MDFeDTO FirstByTenantID(int value );
        public MDFeDTO FirstByDeleted(bool value );
        public MDFeDTO FirstByChanged(DateTime value );
        public MDFeDTO FirstByUserId(int value );
        public IEnumerable<MDFeDTO> GetAllById(int value );
        public IEnumerable<MDFeDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<MDFeDTO> GetAllBySerie(int value );
        public IEnumerable<MDFeDTO> GetAllByNumero(int value );
        public IEnumerable<MDFeDTO> GetAllByUfCarregamento(string value );
        public IEnumerable<MDFeDTO> GetAllByUfDescarregamento(string value );
        public IEnumerable<MDFeDTO> GetAllByPlacaVeiculo(string value );
        public IEnumerable<MDFeDTO> GetAllByEmitidoEm(DateTime value );
        public IEnumerable<MDFeDTO> GetAllByAutorizadoEm(DateTime value );
        public IEnumerable<MDFeDTO> GetAllByIniciadoEm(DateTime value );
        public IEnumerable<MDFeDTO> GetAllByEncerradoEm(DateTime value );
        public IEnumerable<MDFeDTO> GetAllByCanceladoEm(DateTime value );
        public IEnumerable<MDFeDTO> GetAllBySituacao(int value );
        public IEnumerable<MDFeDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration