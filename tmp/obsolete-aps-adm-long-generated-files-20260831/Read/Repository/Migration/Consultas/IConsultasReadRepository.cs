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
    public partial interface IConsultasReadRepository
    {
        public DataPagination<ConsultasDTO> getConsultas(ICommandRead command );
        public IEnumerable<ConsultasTenantIDDTO> getConsultasReadFKTenantID(object command );
        public IEnumerable<ConsultasUserIdDTO> getConsultasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCON_CASAS_DECIMAIS(string value );
        public bool ExistsByCON_CONEXAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ConsultasDTO FirstById(int value );
        public ConsultasDTO FirstByCON_CASAS_DECIMAIS(string value );
        public ConsultasDTO FirstByCON_CONEXAO(string value );
        public ConsultasDTO FirstByTenantID(int value );
        public ConsultasDTO FirstByDeleted(bool value );
        public ConsultasDTO FirstByChanged(DateTime value );
        public ConsultasDTO FirstByUserId(int value );
        public IEnumerable<ConsultasDTO> GetAllById(int value );
        public IEnumerable<ConsultasDTO> GetAllByCON_CASAS_DECIMAIS(string value );
        public IEnumerable<ConsultasDTO> GetAllByCON_CONEXAO(string value );
        public IEnumerable<ConsultasDTO> GetAllByTenantID(int value );
        public IEnumerable<ConsultasDTO> GetAllByDeleted(bool value );
        public IEnumerable<ConsultasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ConsultasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration