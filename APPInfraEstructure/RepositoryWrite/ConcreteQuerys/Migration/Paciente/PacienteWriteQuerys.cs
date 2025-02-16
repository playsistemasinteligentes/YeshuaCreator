using Dominio.Entitys.Paciente;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Paciente
{
    public class PacienteWriteQuery : QueryBase
    {
        public QueryModel InserirPacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" INSERT INTO Paciente (Nome, Telefone) VALUES(@Nome, @Telefone) ";
            this.Parameters = new
            {
                Nome = Paciente.Nome,
                Telefone = Paciente.Telefone,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" UPDATE Paciente SET Nome = @Nome, Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Paciente.Nome,
                Telefone = Paciente.Telefone,
                Id = Paciente.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" DELETE FROM Paciente WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Paciente.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
