using Dominio.Entitys.Especialidade;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Especialidade
{
    public class EspecialidadeWriteQuery : QueryBase
    {
        public QueryModel InserirEspecialidadeQuery(EspecialidadeEntity Especialidade)
        {
            this.Query = $@" INSERT INTO Especialidade (Descricao) VALUES(@Descricao) ";
            this.Parameters = new
            {
                Descricao = Especialidade.Descricao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
