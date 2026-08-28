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
    public partial interface ISegmentoReadRepository
    {
        public DataPagination<SegmentoDTO> getSegmento(ICommandRead command );
        public IEnumerable<SegmentoTenantIDDTO> getSegmentoReadFKTenantID(object command );
        public IEnumerable<SegmentoUserIdDTO> getSegmentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsBySEG_ID(string value );
        public bool ExistsBySEG_DESCRICAO(string value );
        public bool ExistsBySEG_ID_SEGUIMENTO_PAI(string value );
        public bool ExistsByGRS_ID(string value );
        public bool ExistsBySEG_INTEGRACAO_ERP(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public SegmentoDTO FirstById(int value );
        public SegmentoDTO FirstBySEG_ID(string value );
        public SegmentoDTO FirstBySEG_DESCRICAO(string value );
        public SegmentoDTO FirstBySEG_ID_SEGUIMENTO_PAI(string value );
        public SegmentoDTO FirstByGRS_ID(string value );
        public SegmentoDTO FirstBySEG_INTEGRACAO_ERP(string value );
        public SegmentoDTO FirstByTenantID(int value );
        public SegmentoDTO FirstByDeleted(bool value );
        public SegmentoDTO FirstByChanged(DateTime value );
        public SegmentoDTO FirstByUserId(int value );
        public IEnumerable<SegmentoDTO> GetAllById(int value );
        public IEnumerable<SegmentoDTO> GetAllBySEG_ID(string value );
        public IEnumerable<SegmentoDTO> GetAllBySEG_DESCRICAO(string value );
        public IEnumerable<SegmentoDTO> GetAllBySEG_ID_SEGUIMENTO_PAI(string value );
        public IEnumerable<SegmentoDTO> GetAllByGRS_ID(string value );
        public IEnumerable<SegmentoDTO> GetAllBySEG_INTEGRACAO_ERP(string value );
        public IEnumerable<SegmentoDTO> GetAllByTenantID(int value );
        public IEnumerable<SegmentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<SegmentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<SegmentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration