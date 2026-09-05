// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class T_USER_GRUPOQueryWrite : QueryBase, IT_USER_GRUPOQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_USER_GRUPOQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            this.Query = $@" INSERT INTO [T_USER_GRUPO] ([GRU_ID], [ID_USUARIO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@GRU_ID, @ID_USUARIO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRU_ID = T_USER_GRUPO.GRU_ID,
                ID_USUARIO = T_USER_GRUPO.ID_USUARIO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [GRU_ID] = @GRU_ID, [ID_USUARIO] = @ID_USUARIO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRU_ID = T_USER_GRUPO.GRU_ID,
                ID_USUARIO = T_USER_GRUPO.ID_USUARIO,
                Changed = T_USER_GRUPO.Changed,
                UserId = _executionContext.UserId,
                Id = T_USER_GRUPO.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRU_ID(int id, int value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [GRU_ID] = @GRU_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateID_USUARIO(int id, int value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [ID_USUARIO] = @ID_USUARIO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ID_USUARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [T_USER_GRUPO] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO)
        {
            this.Query = $@" DELETE FROM [T_USER_GRUPO] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = T_USER_GRUPO.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration