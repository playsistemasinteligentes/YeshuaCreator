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
    public interface IPacienteReadRepository
    {
        public DataPagination<PacienteDTO> getPaciente(ICommandRead command );
        public IEnumerable<PacienteTenantIDDTO> getPacienteReadFKTenantID(object command );
        public IEnumerable<PacienteUserIdDTO> getPacienteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByNome(string value );
        public bool ExistsByTelefone(string value );
        public bool ExistsByDataNascimento(DateTime value );
        public bool ExistsByGenero(int value );
        public bool ExistsByEscolaridade(string value );
        public bool ExistsByProfissao(string value );
        public bool ExistsByEndereco(string value );
        public bool ExistsByNomeResponsavel(string value );
        public bool ExistsByTelefoneResponsavel(string value );
        public bool ExistsByObservacao(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PacienteDTO FirstById(int value );
        public PacienteDTO FirstByNome(string value );
        public PacienteDTO FirstByTelefone(string value );
        public PacienteDTO FirstByDataNascimento(DateTime value );
        public PacienteDTO FirstByGenero(int value );
        public PacienteDTO FirstByEscolaridade(string value );
        public PacienteDTO FirstByProfissao(string value );
        public PacienteDTO FirstByEndereco(string value );
        public PacienteDTO FirstByNomeResponsavel(string value );
        public PacienteDTO FirstByTelefoneResponsavel(string value );
        public PacienteDTO FirstByObservacao(string value );
        public PacienteDTO FirstByTenantID(int value );
        public PacienteDTO FirstByDeleted(bool value );
        public PacienteDTO FirstByChanged(DateTime value );
        public PacienteDTO FirstByUserId(int value );
        public IEnumerable<PacienteDTO> GetAllById(int value );
        public IEnumerable<PacienteDTO> GetAllByNome(string value );
        public IEnumerable<PacienteDTO> GetAllByTelefone(string value );
        public IEnumerable<PacienteDTO> GetAllByDataNascimento(DateTime value );
        public IEnumerable<PacienteDTO> GetAllByGenero(int value );
        public IEnumerable<PacienteDTO> GetAllByEscolaridade(string value );
        public IEnumerable<PacienteDTO> GetAllByProfissao(string value );
        public IEnumerable<PacienteDTO> GetAllByEndereco(string value );
        public IEnumerable<PacienteDTO> GetAllByNomeResponsavel(string value );
        public IEnumerable<PacienteDTO> GetAllByTelefoneResponsavel(string value );
        public IEnumerable<PacienteDTO> GetAllByObservacao(string value );
        public IEnumerable<PacienteDTO> GetAllByTenantID(int value );
        public IEnumerable<PacienteDTO> GetAllByDeleted(bool value );
        public IEnumerable<PacienteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PacienteDTO> GetAllByUserId(int value );
        public DataPagination<PacienteStandardDTO> GetPacienteMes(ICommandRead command );
        public DataPagination<PacienteStandardDTO> GetPacienteGeral(ICommandRead command );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration