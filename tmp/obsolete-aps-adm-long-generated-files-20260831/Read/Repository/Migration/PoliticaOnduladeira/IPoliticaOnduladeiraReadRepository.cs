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
    public partial interface IPoliticaOnduladeiraReadRepository
    {
        public DataPagination<PoliticaOnduladeiraDTO> getPoliticaOnduladeira(ICommandRead command );
        public IEnumerable<PoliticaOnduladeiraTenantIDDTO> getPoliticaOnduladeiraReadFKTenantID(object command );
        public IEnumerable<PoliticaOnduladeiraUserIdDTO> getPoliticaOnduladeiraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPOL_ID(int value );
        public bool ExistsByPOL_NIVEL(int value );
        public bool ExistsByPOL_PROMOCAO(int value );
        public bool ExistsByPOL_DIAS_ANTECIPACAO(int value );
        public bool ExistsByPOL_METROS_LINEARES(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PoliticaOnduladeiraDTO FirstById(int value );
        public PoliticaOnduladeiraDTO FirstByPOL_ID(int value );
        public PoliticaOnduladeiraDTO FirstByPOL_NIVEL(int value );
        public PoliticaOnduladeiraDTO FirstByPOL_PROMOCAO(int value );
        public PoliticaOnduladeiraDTO FirstByPOL_DIAS_ANTECIPACAO(int value );
        public PoliticaOnduladeiraDTO FirstByPOL_METROS_LINEARES(int value );
        public PoliticaOnduladeiraDTO FirstByTenantID(int value );
        public PoliticaOnduladeiraDTO FirstByDeleted(bool value );
        public PoliticaOnduladeiraDTO FirstByChanged(DateTime value );
        public PoliticaOnduladeiraDTO FirstByUserId(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllById(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_ID(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_NIVEL(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_PROMOCAO(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_DIAS_ANTECIPACAO(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByPOL_METROS_LINEARES(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PoliticaOnduladeiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration