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
    public partial interface ILaudoTesteFisicoReadRepository
    {
        public DataPagination<LaudoTesteFisicoDTO> getLaudoTesteFisico(ICommandRead command );
        public IEnumerable<LaudoTesteFisicoTenantIDDTO> getLaudoTesteFisicoReadFKTenantID(object command );
        public IEnumerable<LaudoTesteFisicoUserIdDTO> getLaudoTesteFisicoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByLTF_ID(int value );
        public bool ExistsByLTF_EMISSAO(DateTime value );
        public bool ExistsByLTF_VALOR(Decimal value );
        public bool ExistsByLTF_OBS(string value );
        public bool ExistsByLTF_STATUS(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByROT_PRO_ID(string value );
        public bool ExistsByFPR_SEQ_REPETICAO(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public LaudoTesteFisicoDTO FirstById(int value );
        public LaudoTesteFisicoDTO FirstByLTF_ID(int value );
        public LaudoTesteFisicoDTO FirstByLTF_EMISSAO(DateTime value );
        public LaudoTesteFisicoDTO FirstByLTF_VALOR(Decimal value );
        public LaudoTesteFisicoDTO FirstByLTF_OBS(string value );
        public LaudoTesteFisicoDTO FirstByLTF_STATUS(string value );
        public LaudoTesteFisicoDTO FirstByORD_ID(string value );
        public LaudoTesteFisicoDTO FirstByROT_PRO_ID(string value );
        public LaudoTesteFisicoDTO FirstByFPR_SEQ_REPETICAO(int value );
        public LaudoTesteFisicoDTO FirstByUSE_ID(int value );
        public LaudoTesteFisicoDTO FirstByTenantID(int value );
        public LaudoTesteFisicoDTO FirstByDeleted(bool value );
        public LaudoTesteFisicoDTO FirstByChanged(DateTime value );
        public LaudoTesteFisicoDTO FirstByUserId(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllById(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_ID(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_EMISSAO(DateTime value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_VALOR(Decimal value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_OBS(string value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByLTF_STATUS(string value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByORD_ID(string value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByROT_PRO_ID(string value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByFPR_SEQ_REPETICAO(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByUSE_ID(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByTenantID(int value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByDeleted(bool value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<LaudoTesteFisicoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration