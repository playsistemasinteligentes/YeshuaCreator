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
            this.Query = $@" INSERT INTO T_CLINICA (NomeFantasia,RazaoSocial) VALUES(@NomeFantasia,@NomeFantasia)";
            this.Parameters = new
            {
                NomeFantasia = Clinica.NomeFantasia.Value,
                RazaoSocial = Clinica.RazaoSocial.Value
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}