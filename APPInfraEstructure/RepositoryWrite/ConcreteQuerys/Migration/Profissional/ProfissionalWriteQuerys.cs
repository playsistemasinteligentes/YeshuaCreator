using Dominio.Entitys;
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
            this.Query = $@" INSERT INTO Profissional (Nome, EspecialidadeId, Telefone) OUTPUT INSERTED.Id VALUES(@Nome, @EspecialidadeId, @Telefone) ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissionalQuery(ProfissionalEntity Profissional)
        {
            this.Query = $@" UPDATE Profissional SET Nome = @Nome, EspecialidadeId = @EspecialidadeId, Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
                Id = Profissional.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteProfissionalQuery(ProfissionalEntity Profissional)
        {
            this.Query = $@" DELETE FROM Profissional WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Profissional.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration