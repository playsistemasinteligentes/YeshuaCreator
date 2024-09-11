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
            this.Query = $@" INSERT INTO Paciente (RazaoSocial, NomeReduzido) VALUES(@RazaoSocial, @NomeReduzido) ";
            this.Parameters = new
            {
                RazaoSocial = Paciente.RazaoSocial,
                NomeReduzido = Paciente.NomeReduzido,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
