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
    public partial interface IMemoriaDeCalculoReadRepository
    {
        public DataPagination<MemoriaDeCalculoDTO> getMemoriaDeCalculo(ICommandRead command );
        public IEnumerable<MemoriaDeCalculoTenantIDDTO> getMemoriaDeCalculoReadFKTenantID(object command );
        public IEnumerable<MemoriaDeCalculoUserIdDTO> getMemoriaDeCalculoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMEM_ID(int value );
        public bool ExistsByORC_ID(int value );
        public bool ExistsByMEM_VALOR(Decimal value );
        public bool ExistsByMEM_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MemoriaDeCalculoDTO FirstById(int value );
        public MemoriaDeCalculoDTO FirstByMEM_ID(int value );
        public MemoriaDeCalculoDTO FirstByORC_ID(int value );
        public MemoriaDeCalculoDTO FirstByMEM_VALOR(Decimal value );
        public MemoriaDeCalculoDTO FirstByMEM_DESCRICAO(string value );
        public MemoriaDeCalculoDTO FirstByTenantID(int value );
        public MemoriaDeCalculoDTO FirstByDeleted(bool value );
        public MemoriaDeCalculoDTO FirstByChanged(DateTime value );
        public MemoriaDeCalculoDTO FirstByUserId(int value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllById(int value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_ID(int value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByORC_ID(int value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_VALOR(Decimal value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByMEM_DESCRICAO(string value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByTenantID(int value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByDeleted(bool value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MemoriaDeCalculoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration