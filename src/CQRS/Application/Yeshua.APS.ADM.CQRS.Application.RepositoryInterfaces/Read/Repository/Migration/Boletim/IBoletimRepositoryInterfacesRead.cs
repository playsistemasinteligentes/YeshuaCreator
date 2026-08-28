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
    public partial interface IBoletimReadRepository
    {
        public DataPagination<BoletimDTO> getBoletim(ICommandRead command );
        public IEnumerable<BoletimGRP_ID_PROGRAMADODTO> getBoletimReadFKGRP_ID_PROGRAMADO(object command );
        public IEnumerable<BoletimTenantIDDTO> getBoletimReadFKTenantID(object command );
        public IEnumerable<BoletimUserIdDTO> getBoletimReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByBOL_ID_ORIGEM(string value );
        public bool ExistsByBOL_SOLVER(string value );
        public bool ExistsByBOL_INTEGRACAO(string value );
        public bool ExistsByBOL_SEQUENCIA(Decimal value );
        public bool ExistsByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value );
        public bool ExistsByGRP_ID_PROGRAMADO(string value );
        public bool ExistsByGRP_PAPEL1_PROGRAMADO(string value );
        public bool ExistsByGRP_PAPEL2_PROGRAMADO(string value );
        public bool ExistsByGRP_PAPEL3_PROGRAMADO(string value );
        public bool ExistsByGRP_PAPEL4_PROGRAMADO(string value );
        public bool ExistsByGRP_PAPEL5_PROGRAMADO(string value );
        public bool ExistsByBOL_STATUS_INTERFACE(string value );
        public bool ExistsByBOL_TIPO(string value );
        public bool ExistsByBOL_FORMATO(int value );
        public bool ExistsByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public bool ExistsByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value );
        public bool ExistsByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public bool ExistsByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value );
        public bool ExistsByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public bool ExistsByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public bool ExistsByBOL_REFILE_OBRIGATORIO(int value );
        public bool ExistsByBOL_OBS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public BoletimDTO FirstById(int value );
        public BoletimDTO FirstByBOL_ID(string value );
        public BoletimDTO FirstByBOL_ID_ORIGEM(string value );
        public BoletimDTO FirstByBOL_SOLVER(string value );
        public BoletimDTO FirstByBOL_INTEGRACAO(string value );
        public BoletimDTO FirstByBOL_SEQUENCIA(Decimal value );
        public BoletimDTO FirstByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value );
        public BoletimDTO FirstByGRP_ID_PROGRAMADO(string value );
        public BoletimDTO FirstByGRP_PAPEL1_PROGRAMADO(string value );
        public BoletimDTO FirstByGRP_PAPEL2_PROGRAMADO(string value );
        public BoletimDTO FirstByGRP_PAPEL3_PROGRAMADO(string value );
        public BoletimDTO FirstByGRP_PAPEL4_PROGRAMADO(string value );
        public BoletimDTO FirstByGRP_PAPEL5_PROGRAMADO(string value );
        public BoletimDTO FirstByBOL_STATUS_INTERFACE(string value );
        public BoletimDTO FirstByBOL_TIPO(string value );
        public BoletimDTO FirstByBOL_FORMATO(int value );
        public BoletimDTO FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public BoletimDTO FirstByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value );
        public BoletimDTO FirstByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public BoletimDTO FirstByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value );
        public BoletimDTO FirstByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public BoletimDTO FirstByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public BoletimDTO FirstByBOL_REFILE_OBRIGATORIO(int value );
        public BoletimDTO FirstByBOL_OBS(string value );
        public BoletimDTO FirstByTenantID(int value );
        public BoletimDTO FirstByDeleted(bool value );
        public BoletimDTO FirstByChanged(DateTime value );
        public BoletimDTO FirstByUserId(int value );
        public IEnumerable<BoletimDTO> GetAllById(int value );
        public IEnumerable<BoletimDTO> GetAllByBOL_ID(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_ID_ORIGEM(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_SOLVER(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_INTEGRACAO(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_SEQUENCIA(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByGRP_ID_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL1_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL2_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL3_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL4_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByGRP_PAPEL5_PROGRAMADO(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_STATUS_INTERFACE(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_TIPO(string value );
        public IEnumerable<BoletimDTO> GetAllByBOL_FORMATO(int value );
        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimDTO> GetAllByBOL_REFILE_OBRIGATORIO(int value );
        public IEnumerable<BoletimDTO> GetAllByBOL_OBS(string value );
        public IEnumerable<BoletimDTO> GetAllByTenantID(int value );
        public IEnumerable<BoletimDTO> GetAllByDeleted(bool value );
        public IEnumerable<BoletimDTO> GetAllByChanged(DateTime value );
        public IEnumerable<BoletimDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration