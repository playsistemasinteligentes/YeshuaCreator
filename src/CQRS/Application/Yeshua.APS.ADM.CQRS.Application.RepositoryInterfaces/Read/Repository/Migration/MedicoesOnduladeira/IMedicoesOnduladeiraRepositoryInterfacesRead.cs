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
    public partial interface IMedicoesOnduladeiraReadRepository
    {
        public DataPagination<MedicoesOnduladeiraDTO> getMedicoesOnduladeira(ICommandRead command );
        public IEnumerable<MedicoesOnduladeiraTenantIDDTO> getMedicoesOnduladeiraReadFKTenantID(object command );
        public IEnumerable<MedicoesOnduladeiraUserIdDTO> getMedicoesOnduladeiraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MedicoesOnduladeiraDTO FirstById(int value );
        public MedicoesOnduladeiraDTO FirstByTenantID(int value );
        public MedicoesOnduladeiraDTO FirstByDeleted(bool value );
        public MedicoesOnduladeiraDTO FirstByChanged(DateTime value );
        public MedicoesOnduladeiraDTO FirstByUserId(int value );
        public IEnumerable<MedicoesOnduladeiraDTO> GetAllById(int value );
        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MedicoesOnduladeiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration