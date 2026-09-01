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
    public partial interface IT_MedicoesReadRepository
    {
        public DataPagination<T_MedicoesDTO> getT_Medicoes(ICommandRead command );
        public IEnumerable<T_MedicoesTenantIDDTO> getT_MedicoesReadFKTenantID(object command );
        public IEnumerable<T_MedicoesUserIdDTO> getT_MedicoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMED_ID(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByMET_ID(int value );
        public bool ExistsByUNI_ID(int value );
        public bool ExistsByMED_DATA(DateTime value );
        public bool ExistsByMED_VALOR(string value );
        public bool ExistsByMED_AC_ANO(string value );
        public bool ExistsByMED_DATAMEDICAO(string value );
        public bool ExistsByMED_PONDERACAO(Decimal value );
        public bool ExistsByDIM_ID(string value );
        public bool ExistsByDIM_DESCRICAO(string value );
        public bool ExistsByDIM_SUBDIMENSAO_ID(string value );
        public bool ExistsByDIM_SUB_DESCRICAO(string value );
        public bool ExistsByPER_ID(string value );
        public bool ExistsByPER_DESCRICAO(string value );
        public bool ExistsByFAT_ID(string value );
        public bool ExistsByFAT_DESCRICAO(string value );
        public bool ExistsByMED_SQL(string value );
        public bool ExistsByDOM_EMPRESA(string value );
        public bool ExistsByDOM_FILIAL(string value );
        public bool ExistsByMED_VALOR_DISPER(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_MedicoesDTO FirstById(int value );
        public T_MedicoesDTO FirstByMED_ID(int value );
        public T_MedicoesDTO FirstByIND_ID(int value );
        public T_MedicoesDTO FirstByMET_ID(int value );
        public T_MedicoesDTO FirstByUNI_ID(int value );
        public T_MedicoesDTO FirstByMED_DATA(DateTime value );
        public T_MedicoesDTO FirstByMED_VALOR(string value );
        public T_MedicoesDTO FirstByMED_AC_ANO(string value );
        public T_MedicoesDTO FirstByMED_DATAMEDICAO(string value );
        public T_MedicoesDTO FirstByMED_PONDERACAO(Decimal value );
        public T_MedicoesDTO FirstByDIM_ID(string value );
        public T_MedicoesDTO FirstByDIM_DESCRICAO(string value );
        public T_MedicoesDTO FirstByDIM_SUBDIMENSAO_ID(string value );
        public T_MedicoesDTO FirstByDIM_SUB_DESCRICAO(string value );
        public T_MedicoesDTO FirstByPER_ID(string value );
        public T_MedicoesDTO FirstByPER_DESCRICAO(string value );
        public T_MedicoesDTO FirstByFAT_ID(string value );
        public T_MedicoesDTO FirstByFAT_DESCRICAO(string value );
        public T_MedicoesDTO FirstByMED_SQL(string value );
        public T_MedicoesDTO FirstByDOM_EMPRESA(string value );
        public T_MedicoesDTO FirstByDOM_FILIAL(string value );
        public T_MedicoesDTO FirstByMED_VALOR_DISPER(string value );
        public T_MedicoesDTO FirstByTenantID(int value );
        public T_MedicoesDTO FirstByDeleted(bool value );
        public T_MedicoesDTO FirstByChanged(DateTime value );
        public T_MedicoesDTO FirstByUserId(int value );
        public IEnumerable<T_MedicoesDTO> GetAllById(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_ID(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByIND_ID(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByMET_ID(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByUNI_ID(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_DATA(DateTime value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_VALOR(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_AC_ANO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_DATAMEDICAO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_PONDERACAO(Decimal value );
        public IEnumerable<T_MedicoesDTO> GetAllByDIM_ID(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByDIM_DESCRICAO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByDIM_SUBDIMENSAO_ID(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByDIM_SUB_DESCRICAO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByPER_ID(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByPER_DESCRICAO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByFAT_ID(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByFAT_DESCRICAO(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_SQL(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByDOM_EMPRESA(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByDOM_FILIAL(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByMED_VALOR_DISPER(string value );
        public IEnumerable<T_MedicoesDTO> GetAllByTenantID(int value );
        public IEnumerable<T_MedicoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_MedicoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_MedicoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration