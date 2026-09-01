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
    public partial interface IMovimentosReadRepository
    {
        public DataPagination<MovimentosDTO> getMovimentos(ICommandRead command );
        public IEnumerable<MovimentosMOV_PLAIDDTO> getMovimentosReadFKMOV_PLAID(object command );
        public IEnumerable<MovimentosTr_Unidade_UNI_IDDTO> getMovimentosReadFKTr_Unidade_UNI_ID(object command );
        public IEnumerable<MovimentosTenantIDDTO> getMovimentosReadFKTenantID(object command );
        public IEnumerable<MovimentosUserIdDTO> getMovimentosReadFKUserId(object command );
        public bool ExistsByMOV_ID(int value );
        public bool ExistsByMOV_DATA(string value );
        public bool ExistsByMOV_VALOR(Decimal value );
        public bool ExistsByMOV_PLAID(int value );
        public bool ExistsByMOV_UNID(int value );
        public bool ExistsByTr_Unidade_UNI_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MovimentosDTO FirstByMOV_ID(int value );
        public MovimentosDTO FirstByMOV_DATA(string value );
        public MovimentosDTO FirstByMOV_VALOR(Decimal value );
        public MovimentosDTO FirstByMOV_PLAID(int value );
        public MovimentosDTO FirstByMOV_UNID(int value );
        public MovimentosDTO FirstByTr_Unidade_UNI_ID(int value );
        public MovimentosDTO FirstByTenantID(int value );
        public MovimentosDTO FirstByDeleted(bool value );
        public MovimentosDTO FirstByChanged(DateTime value );
        public MovimentosDTO FirstByUserId(int value );
        public IEnumerable<MovimentosDTO> GetAllByMOV_ID(int value );
        public IEnumerable<MovimentosDTO> GetAllByMOV_DATA(string value );
        public IEnumerable<MovimentosDTO> GetAllByMOV_VALOR(Decimal value );
        public IEnumerable<MovimentosDTO> GetAllByMOV_PLAID(int value );
        public IEnumerable<MovimentosDTO> GetAllByMOV_UNID(int value );
        public IEnumerable<MovimentosDTO> GetAllByTr_Unidade_UNI_ID(int value );
        public IEnumerable<MovimentosDTO> GetAllByTenantID(int value );
        public IEnumerable<MovimentosDTO> GetAllByDeleted(bool value );
        public IEnumerable<MovimentosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MovimentosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration