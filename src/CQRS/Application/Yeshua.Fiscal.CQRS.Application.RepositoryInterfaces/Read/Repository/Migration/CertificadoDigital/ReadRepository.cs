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
    public partial interface ICertificadoDigitalReadRepository
    {
        public DataPagination<CertificadoDigitalDTO> getCertificadoDigital(ICommandRead command );
        public IEnumerable<CertificadoDigitalTenantIDDTO> getCertificadoDigitalReadFKTenantID(object command );
        public IEnumerable<CertificadoDigitalUserIdDTO> getCertificadoDigitalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByApelido(string value );
        public bool ExistsByDocumentoTitular(string value );
        public bool ExistsByStorageKey(string value );
        public bool ExistsByThumbprint(string value );
        public bool ExistsByValidoDe(DateTime value );
        public bool ExistsByValidoAte(DateTime value );
        public bool ExistsByAtivo(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CertificadoDigitalDTO FirstById(int value );
        public CertificadoDigitalDTO FirstByApelido(string value );
        public CertificadoDigitalDTO FirstByDocumentoTitular(string value );
        public CertificadoDigitalDTO FirstByStorageKey(string value );
        public CertificadoDigitalDTO FirstByThumbprint(string value );
        public CertificadoDigitalDTO FirstByValidoDe(DateTime value );
        public CertificadoDigitalDTO FirstByValidoAte(DateTime value );
        public CertificadoDigitalDTO FirstByAtivo(int value );
        public CertificadoDigitalDTO FirstByTenantID(int value );
        public CertificadoDigitalDTO FirstByDeleted(bool value );
        public CertificadoDigitalDTO FirstByChanged(DateTime value );
        public CertificadoDigitalDTO FirstByUserId(int value );
        public IEnumerable<CertificadoDigitalDTO> GetAllById(int value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByApelido(string value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByDocumentoTitular(string value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByStorageKey(string value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByThumbprint(string value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByValidoDe(DateTime value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByValidoAte(DateTime value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByAtivo(int value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByTenantID(int value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByDeleted(bool value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CertificadoDigitalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration