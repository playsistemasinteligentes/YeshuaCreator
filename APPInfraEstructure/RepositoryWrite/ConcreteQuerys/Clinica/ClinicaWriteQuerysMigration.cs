using Dominio.Entitys.Clinica;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Clinica
{
    public class ClinicaWriteQuery : QueryBase
    {
        public QueryModel InserirClinicaQuery(ClinicaEntity Clinica)
        {
            this.Query = $@" INSERT INTO Clinica (Nome, Endereco, Telefone) VALUES(@Nome, @Endereco, @Telefone) ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
