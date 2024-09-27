using Dominio.Entitys.Profissional;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Profissional
{
    public class ProfissionalWriteQuery : QueryBase
    {
        public QueryModel InserirProfissionalQuery(ProfissionalEntity Profissional)
        {
            this.Query = $@" INSERT INTO Profissional (Nome, EspecialidadeId, Telefone) VALUES(@Nome, @EspecialidadeId, @Telefone) ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
