using Dominio.Entitys;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Y_User
{
    public class Y_UserWriteQuery : QueryBase
    {
        public QueryModel InserirY_UserQuery(IY_UserEntity Y_User)
        {
            this.Query = $@" INSERT INTO Y_User (Nome, Email, Senha, TenantID) OUTPUT INSERTED.Id VALUES(@Nome, @Email, @Senha, @TenantID) ";
            this.Parameters = new
            {
                Nome = Y_User.Nome,
                Email = Y_User.Email,
                Senha = Y_User.Senha,
                TenantID = Y_User.TenantID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateY_UserQuery(IY_UserEntity Y_User)
        {
            this.Query = $@" UPDATE Y_User SET Nome = @Nome, Email = @Email, Senha = @Senha, TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Y_User.Nome,
                Email = Y_User.Email,
                Senha = Y_User.Senha,
                TenantID = Y_User.TenantID,
                Id = Y_User.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteY_UserQuery(IY_UserEntity Y_User)
        {
            this.Query = $@" DELETE FROM Y_User WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Y_User.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration