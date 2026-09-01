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
    public partial interface IItenCargaReadRepository
    {
        public DataPagination<ItenCargaDTO> getItenCarga(ICommandRead command );
        public IEnumerable<ItenCargaORD_IDDTO> getItenCargaReadFKORD_ID(object command );
        public IEnumerable<ItenCargaTenantIDDTO> getItenCargaReadFKTenantID(object command );
        public IEnumerable<ItenCargaUserIdDTO> getItenCargaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByITC_ENTREGA_PLANEJADA(DateTime value );
        public bool ExistsByITC_ENTREGA_REALIZADA(DateTime value );
        public bool ExistsByITC_ORDEM_ENTREGA(int value );
        public bool ExistsByITC_QTD_PLANEJADA(Decimal value );
        public bool ExistsByITC_QTD_REALIZADA(Decimal value );
        public bool ExistsByORD_HASH_KEY(string value );
        public bool ExistsByNOT_ID(string value );
        public bool ExistsByNOT_EMISSAO(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItenCargaDTO FirstById(int value );
        public ItenCargaDTO FirstByCAR_ID(string value );
        public ItenCargaDTO FirstByORD_ID(string value );
        public ItenCargaDTO FirstByITC_ENTREGA_PLANEJADA(DateTime value );
        public ItenCargaDTO FirstByITC_ENTREGA_REALIZADA(DateTime value );
        public ItenCargaDTO FirstByITC_ORDEM_ENTREGA(int value );
        public ItenCargaDTO FirstByITC_QTD_PLANEJADA(Decimal value );
        public ItenCargaDTO FirstByITC_QTD_REALIZADA(Decimal value );
        public ItenCargaDTO FirstByORD_HASH_KEY(string value );
        public ItenCargaDTO FirstByNOT_ID(string value );
        public ItenCargaDTO FirstByNOT_EMISSAO(DateTime value );
        public ItenCargaDTO FirstByTenantID(int value );
        public ItenCargaDTO FirstByDeleted(bool value );
        public ItenCargaDTO FirstByChanged(DateTime value );
        public ItenCargaDTO FirstByUserId(int value );
        public IEnumerable<ItenCargaDTO> GetAllById(int value );
        public IEnumerable<ItenCargaDTO> GetAllByCAR_ID(string value );
        public IEnumerable<ItenCargaDTO> GetAllByORD_ID(string value );
        public IEnumerable<ItenCargaDTO> GetAllByITC_ENTREGA_PLANEJADA(DateTime value );
        public IEnumerable<ItenCargaDTO> GetAllByITC_ENTREGA_REALIZADA(DateTime value );
        public IEnumerable<ItenCargaDTO> GetAllByITC_ORDEM_ENTREGA(int value );
        public IEnumerable<ItenCargaDTO> GetAllByITC_QTD_PLANEJADA(Decimal value );
        public IEnumerable<ItenCargaDTO> GetAllByITC_QTD_REALIZADA(Decimal value );
        public IEnumerable<ItenCargaDTO> GetAllByORD_HASH_KEY(string value );
        public IEnumerable<ItenCargaDTO> GetAllByNOT_ID(string value );
        public IEnumerable<ItenCargaDTO> GetAllByNOT_EMISSAO(DateTime value );
        public IEnumerable<ItenCargaDTO> GetAllByTenantID(int value );
        public IEnumerable<ItenCargaDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItenCargaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItenCargaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration