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
        public DataPagination<PacienteDTO> getPaciente(ICommandRead command);
        public PacienteDTO getById();
        public bool ExistsById(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByTelefone(string value);
        public bool ExistsByDataNascimento(DateTime value);
        public bool ExistsByGenero(int value);
        public bool ExistsByEscolaridade(string value);
        public bool ExistsByProfissao(string value);
        public bool ExistsByEndereco(string value);
        public bool ExistsByNomeResponsavel(string value);
        public bool ExistsByTelefoneResponsavel(string value);
        public bool ExistsByPrincipaisQueixas(string value);
        public bool ExistsByObservacaoAdicional(string value);
        public PacienteDTO FirstById(int value);
        public PacienteDTO FirstByNome(string value);
        public PacienteDTO FirstByTelefone(string value);
        public PacienteDTO FirstByDataNascimento(DateTime value);
        public PacienteDTO FirstByGenero(int value);
        public PacienteDTO FirstByEscolaridade(string value);
        public PacienteDTO FirstByProfissao(string value);
        public PacienteDTO FirstByEndereco(string value);
        public PacienteDTO FirstByNomeResponsavel(string value);
        public PacienteDTO FirstByTelefoneResponsavel(string value);
        public PacienteDTO FirstByPrincipaisQueixas(string value);
        public PacienteDTO FirstByObservacaoAdicional(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration