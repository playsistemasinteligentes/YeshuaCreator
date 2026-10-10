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
    public partial interface IFotoReadRepository
    {
        public DataPagination<FotoDTO> getFoto(ICommandRead command );
        public IEnumerable<FotoTenantIDDTO> getFotoReadFKTenantID(object command );
        public IEnumerable<FotoUserIdDTO> getFotoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByStorageKey(string value );
        public bool ExistsByNomeOriginal(string value );
        public bool ExistsByContentType(string value );
        public bool ExistsByHashArquivo(string value );
        public bool ExistsByCapturadaEmUtc(DateTime value );
        public bool ExistsByLargura(int value );
        public bool ExistsByAltura(int value );
        public bool ExistsByStatus(int value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public FotoDTO FirstById(int value );
        public FotoDTO FirstByStorageKey(string value );
        public FotoDTO FirstByNomeOriginal(string value );
        public FotoDTO FirstByContentType(string value );
        public FotoDTO FirstByHashArquivo(string value );
        public FotoDTO FirstByCapturadaEmUtc(DateTime value );
        public FotoDTO FirstByLargura(int value );
        public FotoDTO FirstByAltura(int value );
        public FotoDTO FirstByStatus(int value );
        public FotoDTO FirstByOperationalEntityId(string value );
        public FotoDTO FirstByTenantID(int value );
        public FotoDTO FirstByDeleted(bool value );
        public FotoDTO FirstByChanged(DateTime value );
        public FotoDTO FirstByUserId(int value );
        public IEnumerable<FotoDTO> GetAllById(int value );
        public IEnumerable<FotoDTO> GetAllByStorageKey(string value );
        public IEnumerable<FotoDTO> GetAllByNomeOriginal(string value );
        public IEnumerable<FotoDTO> GetAllByContentType(string value );
        public IEnumerable<FotoDTO> GetAllByHashArquivo(string value );
        public IEnumerable<FotoDTO> GetAllByCapturadaEmUtc(DateTime value );
        public IEnumerable<FotoDTO> GetAllByLargura(int value );
        public IEnumerable<FotoDTO> GetAllByAltura(int value );
        public IEnumerable<FotoDTO> GetAllByStatus(int value );
        public IEnumerable<FotoDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<FotoDTO> GetAllByTenantID(int value );
        public IEnumerable<FotoDTO> GetAllByDeleted(bool value );
        public IEnumerable<FotoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<FotoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration