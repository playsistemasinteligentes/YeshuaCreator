using Dominio.Entitys.Clinica;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Clinica
{
    public class ClinicaReadQuery : QueryBase
    {
        public QueryModel SelectAllClinicaQuery()
        {
            this.Query = $@" select Id, RazaoSocial, NomeReduzido from Clinica ";
            return new QueryModel(this.Query, null);
        }
    }
}
