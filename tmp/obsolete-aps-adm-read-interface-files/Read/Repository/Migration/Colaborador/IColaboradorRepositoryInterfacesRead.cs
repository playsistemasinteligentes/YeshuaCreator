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
    public partial interface IColaboradorReadRepository
    {
        public DataPagination<ColaboradorDTO> getColaborador(ICommandRead command );
        public IEnumerable<ColaboradorTURM_idDTO> getColaboradorReadFKTURM_id(object command );
        public IEnumerable<ColaboradorTenantIDDTO> getColaboradorReadFKTenantID(object command );
        public IEnumerable<ColaboradorUserIdDTO> getColaboradorReadFKUserId(object command );
        public bool ExistsByCOL_CPF(string value );
        public bool ExistsByCOL_NOME(string value );
        public bool ExistsByCOL_NASCIMENTO(DateTime value );
        public bool ExistsByCOL_EMAIL(string value );
        public bool ExistsByCOL_MATRICULA(string value );
        public bool ExistsByTURM_id(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ColaboradorDTO FirstByCOL_CPF(string value );
        public ColaboradorDTO FirstByCOL_NOME(string value );
        public ColaboradorDTO FirstByCOL_NASCIMENTO(DateTime value );
        public ColaboradorDTO FirstByCOL_EMAIL(string value );
        public ColaboradorDTO FirstByCOL_MATRICULA(string value );
        public ColaboradorDTO FirstByTURM_id(string value );
        public ColaboradorDTO FirstByTenantID(int value );
        public ColaboradorDTO FirstByDeleted(bool value );
        public ColaboradorDTO FirstByChanged(DateTime value );
        public ColaboradorDTO FirstByUserId(int value );
        public IEnumerable<ColaboradorDTO> GetAllByCOL_CPF(string value );
        public IEnumerable<ColaboradorDTO> GetAllByCOL_NOME(string value );
        public IEnumerable<ColaboradorDTO> GetAllByCOL_NASCIMENTO(DateTime value );
        public IEnumerable<ColaboradorDTO> GetAllByCOL_EMAIL(string value );
        public IEnumerable<ColaboradorDTO> GetAllByCOL_MATRICULA(string value );
        public IEnumerable<ColaboradorDTO> GetAllByTURM_id(string value );
        public IEnumerable<ColaboradorDTO> GetAllByTenantID(int value );
        public IEnumerable<ColaboradorDTO> GetAllByDeleted(bool value );
        public IEnumerable<ColaboradorDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ColaboradorDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration