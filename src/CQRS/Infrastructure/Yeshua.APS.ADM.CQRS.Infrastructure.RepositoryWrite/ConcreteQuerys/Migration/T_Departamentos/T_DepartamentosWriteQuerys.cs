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
    public class T_DepartamentosQueryWrite : QueryBase, IT_DepartamentosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_DepartamentosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos)
        {
            this.Query = $@" INSERT INTO [T_Departamentos] ([DEP_NOME], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[DEP_ID] VALUES(@DEP_NOME, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DEP_NOME = T_Departamentos.DEP_NOME,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [DEP_NOME] = @DEP_NOME, [Changed] = @Changed, [UserId] = @UserId WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                DEP_NOME = T_Departamentos.DEP_NOME,
                Changed = T_Departamentos.Changed,
                UserId = _executionContext.UserId,
                DEP_ID = T_Departamentos.DEP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDEP_NOME(int dep_id, string value)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [DEP_NOME] = @DEP_NOME WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                DEP_NOME = value,
                DEP_ID = dep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int dep_id, int value)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [TenantID] = @TenantID WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                DEP_ID = dep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int dep_id, bool value)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [Deleted] = @Deleted WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                DEP_ID = dep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int dep_id, DateTime value)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [Changed] = @Changed WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                Changed = value,
                DEP_ID = dep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int dep_id, int value)
        {
            this.Query = $@" UPDATE [T_Departamentos] SET [UserId] = @UserId WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                UserId = value,
                DEP_ID = dep_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_DepartamentosQuery(IT_DepartamentosEntity T_Departamentos)
        {
            this.Query = $@" DELETE FROM [T_Departamentos] WHERE [DEP_ID] = @DEP_ID ";
            this.Parameters = new
            {
                DEP_ID = T_Departamentos.DEP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration