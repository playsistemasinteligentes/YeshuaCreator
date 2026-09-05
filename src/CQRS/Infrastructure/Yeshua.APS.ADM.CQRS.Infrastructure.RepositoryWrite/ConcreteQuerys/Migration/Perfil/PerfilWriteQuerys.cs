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
    public class PerfilQueryWrite : QueryBase, IPerfilQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PerfilQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPerfilQuery(IPerfilEntity Perfil)
        {
            this.Query = $@" INSERT INTO [Perfil] ([PER_NOME], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[PER_ID] VALUES(@PER_NOME, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PER_NOME = Perfil.PER_NOME,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerfilQuery(IPerfilEntity Perfil)
        {
            this.Query = $@" UPDATE [Perfil] SET [PER_NOME] = @PER_NOME, [Changed] = @Changed, [UserId] = @UserId WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                PER_NOME = Perfil.PER_NOME,
                Changed = Perfil.Changed,
                UserId = _executionContext.UserId,
                PER_ID = Perfil.PER_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePER_NOME(int per_id, string value)
        {
            this.Query = $@" UPDATE [Perfil] SET [PER_NOME] = @PER_NOME WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                PER_NOME = value,
                PER_ID = per_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int per_id, int value)
        {
            this.Query = $@" UPDATE [Perfil] SET [TenantID] = @TenantID WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PER_ID = per_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int per_id, bool value)
        {
            this.Query = $@" UPDATE [Perfil] SET [Deleted] = @Deleted WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PER_ID = per_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int per_id, DateTime value)
        {
            this.Query = $@" UPDATE [Perfil] SET [Changed] = @Changed WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                Changed = value,
                PER_ID = per_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int per_id, int value)
        {
            this.Query = $@" UPDATE [Perfil] SET [UserId] = @UserId WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                UserId = value,
                PER_ID = per_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePerfilQuery(IPerfilEntity Perfil)
        {
            this.Query = $@" DELETE FROM [Perfil] WHERE [PER_ID] = @PER_ID ";
            this.Parameters = new
            {
                PER_ID = Perfil.PER_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration