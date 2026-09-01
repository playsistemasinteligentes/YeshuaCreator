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
    public partial interface IMedidasTesteReadRepository
    {
        public DataPagination<MedidasTesteDTO> getMedidasTeste(ICommandRead command );
        public IEnumerable<MedidasTesteTenantIDDTO> getMedidasTesteReadFKTenantID(object command );
        public IEnumerable<MedidasTesteUserIdDTO> getMedidasTesteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDT_ID(int value );
        public bool ExistsByMDT_DESC(string value );
        public bool ExistsByMDT_VALOR_ESPERADO(Decimal value );
        public bool ExistsByMDT_ENCONTRADO(Decimal value );
        public bool ExistsByUNI_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MedidasTesteDTO FirstById(int value );
        public MedidasTesteDTO FirstByMDT_ID(int value );
        public MedidasTesteDTO FirstByMDT_DESC(string value );
        public MedidasTesteDTO FirstByMDT_VALOR_ESPERADO(Decimal value );
        public MedidasTesteDTO FirstByMDT_ENCONTRADO(Decimal value );
        public MedidasTesteDTO FirstByUNI_ID(string value );
        public MedidasTesteDTO FirstByTenantID(int value );
        public MedidasTesteDTO FirstByDeleted(bool value );
        public MedidasTesteDTO FirstByChanged(DateTime value );
        public MedidasTesteDTO FirstByUserId(int value );
        public IEnumerable<MedidasTesteDTO> GetAllById(int value );
        public IEnumerable<MedidasTesteDTO> GetAllByMDT_ID(int value );
        public IEnumerable<MedidasTesteDTO> GetAllByMDT_DESC(string value );
        public IEnumerable<MedidasTesteDTO> GetAllByMDT_VALOR_ESPERADO(Decimal value );
        public IEnumerable<MedidasTesteDTO> GetAllByMDT_ENCONTRADO(Decimal value );
        public IEnumerable<MedidasTesteDTO> GetAllByUNI_ID(string value );
        public IEnumerable<MedidasTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<MedidasTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<MedidasTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MedidasTesteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration