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
    public partial interface IBoletimEstudoReadRepository
    {
        public DataPagination<BoletimEstudoDTO> getBoletimEstudo(ICommandRead command );
        public IEnumerable<BoletimEstudoTenantIDDTO> getBoletimEstudoReadFKTenantID(object command );
        public IEnumerable<BoletimEstudoUserIdDTO> getBoletimEstudoReadFKUserId(object command );
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
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public BoletimEstudoDTO FirstById(int value );
        public BoletimEstudoDTO FirstByBOL_ID(string value );
        public BoletimEstudoDTO FirstByBOL_ID_ORIGEM(string value );
        public BoletimEstudoDTO FirstByBOL_SOLVER(string value );
        public BoletimEstudoDTO FirstByBOL_INTEGRACAO(string value );
        public BoletimEstudoDTO FirstByBOL_SEQUENCIA(Decimal value );
        public BoletimEstudoDTO FirstByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value );
        public BoletimEstudoDTO FirstByGRP_ID_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByGRP_PAPEL1_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByGRP_PAPEL2_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByGRP_PAPEL3_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByGRP_PAPEL4_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByGRP_PAPEL5_PROGRAMADO(string value );
        public BoletimEstudoDTO FirstByBOL_STATUS_INTERFACE(string value );
        public BoletimEstudoDTO FirstByBOL_TIPO(string value );
        public BoletimEstudoDTO FirstByBOL_FORMATO(int value );
        public BoletimEstudoDTO FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public BoletimEstudoDTO FirstByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value );
        public BoletimEstudoDTO FirstByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public BoletimEstudoDTO FirstByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value );
        public BoletimEstudoDTO FirstByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public BoletimEstudoDTO FirstByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public BoletimEstudoDTO FirstByBOL_REFILE_OBRIGATORIO(int value );
        public BoletimEstudoDTO FirstByTenantID(int value );
        public BoletimEstudoDTO FirstByDeleted(bool value );
        public BoletimEstudoDTO FirstByChanged(DateTime value );
        public BoletimEstudoDTO FirstByUserId(int value );
        public IEnumerable<BoletimEstudoDTO> GetAllById(int value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_ID(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_ID_ORIGEM(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_SOLVER(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_INTEGRACAO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_SEQUENCIA(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAP_GRAMATURA_PROGRAMADO(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_ID_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL1_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL2_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL3_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL4_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByGRP_PAPEL5_PROGRAMADO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_STATUS_INTERFACE(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_TIPO(string value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_FORMATO(int value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_PAPEIS_REALIZADO(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_PAPEIS_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_PAPEIS_REALIZADO(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_GRAMATURA_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_CUSTO_RESINA_PROGRAMADOS(Decimal value );
        public IEnumerable<BoletimEstudoDTO> GetAllByBOL_REFILE_OBRIGATORIO(int value );
        public IEnumerable<BoletimEstudoDTO> GetAllByTenantID(int value );
        public IEnumerable<BoletimEstudoDTO> GetAllByDeleted(bool value );
        public IEnumerable<BoletimEstudoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<BoletimEstudoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration