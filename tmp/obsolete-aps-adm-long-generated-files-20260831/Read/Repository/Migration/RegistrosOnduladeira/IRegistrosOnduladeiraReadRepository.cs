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
    public partial interface IRegistrosOnduladeiraReadRepository
    {
        public DataPagination<RegistrosOnduladeiraDTO> getRegistrosOnduladeira(ICommandRead command );
        public IEnumerable<RegistrosOnduladeiraTenantIDDTO> getRegistrosOnduladeiraReadFKTenantID(object command );
        public IEnumerable<RegistrosOnduladeiraUserIdDTO> getRegistrosOnduladeiraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByREG_ID(int value );
        public bool ExistsByREG_RESPOSTA(string value );
        public bool ExistsByREG_STATUS(string value );
        public bool ExistsByREG_DATA_INICIO(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RegistrosOnduladeiraDTO FirstById(int value );
        public RegistrosOnduladeiraDTO FirstByREG_ID(int value );
        public RegistrosOnduladeiraDTO FirstByREG_RESPOSTA(string value );
        public RegistrosOnduladeiraDTO FirstByREG_STATUS(string value );
        public RegistrosOnduladeiraDTO FirstByREG_DATA_INICIO(DateTime value );
        public RegistrosOnduladeiraDTO FirstByTenantID(int value );
        public RegistrosOnduladeiraDTO FirstByDeleted(bool value );
        public RegistrosOnduladeiraDTO FirstByChanged(DateTime value );
        public RegistrosOnduladeiraDTO FirstByUserId(int value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllById(int value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_ID(int value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_RESPOSTA(string value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_STATUS(string value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByREG_DATA_INICIO(DateTime value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RegistrosOnduladeiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration