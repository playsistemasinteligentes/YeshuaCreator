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
            this.Query = $@" INSERT INTO Clinica (RazaoSocial, NomeReduzido, Endereco) VALUES(@RazaoSocial, @NomeReduzido, @Endereco) ";
            this.Parameters = new
            {
                RazaoSocial = Clinica.RazaoSocial,
                NomeReduzido = Clinica.NomeReduzido,
                Endereco = Clinica.Endereco,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
