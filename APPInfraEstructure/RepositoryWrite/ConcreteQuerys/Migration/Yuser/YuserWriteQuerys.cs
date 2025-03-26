using Dominio.Entitys.Yuser;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Yuser
{
    public class YuserWriteQuery : QueryBase
    {
        public QueryModel InserirYuserQuery(YuserEntity Yuser)
        {
            this.Query = $@" INSERT INTO Yuser (Nome, Senha, Login) VALUES(@Nome, @Senha, @Login) ";
            this.Parameters = new
            {
                Nome = Yuser.Nome,
                Senha = Yuser.Senha,
                Login = Yuser.Login,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYuserQuery(YuserEntity Yuser)
        {
            this.Query = $@" UPDATE Yuser SET Nome = @Nome, Senha = @Senha, Login = @Login WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Yuser.Nome,
                Senha = Yuser.Senha,
                Login = Yuser.Login,
                Id = Yuser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYuserQuery(YuserEntity Yuser)
        {
            this.Query = $@" DELETE FROM Yuser WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Yuser.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration