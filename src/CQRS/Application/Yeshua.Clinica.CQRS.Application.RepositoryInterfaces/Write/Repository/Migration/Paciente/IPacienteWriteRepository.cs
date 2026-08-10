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
        void UpdateNome(int id, string value);
        void UpdateTelefone(int id, string value);
        void UpdateDataNascimento(int id, DateTime value);
        void UpdateGenero(int id, int value);
        void UpdateEscolaridade(int id, string value);
        void UpdateProfissao(int id, string value);
        void UpdateEndereco(int id, string value);
        void UpdateNomeResponsavel(int id, string value);
        void UpdateTelefoneResponsavel(int id, string value);
        void UpdateObservacao(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration