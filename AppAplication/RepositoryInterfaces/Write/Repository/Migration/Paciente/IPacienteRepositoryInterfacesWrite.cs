using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IPacienteWriteRepository
    {
        void Insert(IPacienteEntity paciente);
        void Update(IPacienteEntity paciente);
        void Delete(IPacienteEntity paciente);
        public void UpdateNome(IPacienteEntity entity);
        public void UpdateTelefone(IPacienteEntity entity);
        public void UpdateDataNascimento(IPacienteEntity entity);
        public void UpdateGenero(IPacienteEntity entity);
        public void UpdateEscolaridade(IPacienteEntity entity);
        public void UpdateProfissao(IPacienteEntity entity);
        public void UpdateEndereco(IPacienteEntity entity);
        public void UpdateNomeResponsavel(IPacienteEntity entity);
        public void UpdateTelefoneResponsavel(IPacienteEntity entity);
        public void UpdatePrincipaisQueixas(IPacienteEntity entity);
        public void UpdateObservacaoAdicional(IPacienteEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration