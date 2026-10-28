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
    public partial interface IRevisaoRegistroSessaoReadRepository
    {
        public DataPagination<RevisaoRegistroSessaoDTO> getRevisaoRegistroSessao(ICommandRead command );
        public IEnumerable<RevisaoRegistroSessaoSessaoIdDTO> getRevisaoRegistroSessaoReadFKSessaoId(object command );
        public IEnumerable<RevisaoRegistroSessaoAutorUserIdDTO> getRevisaoRegistroSessaoReadFKAutorUserId(object command );
        public IEnumerable<RevisaoRegistroSessaoTenantIDDTO> getRevisaoRegistroSessaoReadFKTenantID(object command );
        public IEnumerable<RevisaoRegistroSessaoUserIdDTO> getRevisaoRegistroSessaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsBySessaoId(int value );
        public bool ExistsByVersao(int value );
        public bool ExistsByAutorUserId(int value );
        public bool ExistsByRevisadoEm(DateTime value );
        public bool ExistsByMotivo(string value );
        public bool ExistsByRegistro(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByOperationalEntityId(string value );
        public RevisaoRegistroSessaoDTO FirstById(int value );
        public RevisaoRegistroSessaoDTO FirstBySessaoId(int value );
        public RevisaoRegistroSessaoDTO FirstByVersao(int value );
        public RevisaoRegistroSessaoDTO FirstByAutorUserId(int value );
        public RevisaoRegistroSessaoDTO FirstByRevisadoEm(DateTime value );
        public RevisaoRegistroSessaoDTO FirstByMotivo(string value );
        public RevisaoRegistroSessaoDTO FirstByRegistro(string value );
        public RevisaoRegistroSessaoDTO FirstByTenantID(int value );
        public RevisaoRegistroSessaoDTO FirstByDeleted(bool value );
        public RevisaoRegistroSessaoDTO FirstByChanged(DateTime value );
        public RevisaoRegistroSessaoDTO FirstByUserId(int value );
        public RevisaoRegistroSessaoDTO FirstByOperationalEntityId(string value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllById(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllBySessaoId(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByVersao(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByAutorUserId(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByRevisadoEm(DateTime value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByMotivo(string value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByRegistro(string value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByTenantID(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByUserId(int value );
        public IEnumerable<RevisaoRegistroSessaoDTO> GetAllByOperationalEntityId(string value );
        public DataPagination<RevisaoRegistroSessaoStandardDTO> GetRevisaoRegistroSessaoGeral(ICommandRead command );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration