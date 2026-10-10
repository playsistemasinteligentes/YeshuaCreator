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
    public class AlbumQueryWrite : QueryBase, IAlbumQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public AlbumQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirAlbumQuery(IAlbumEntity Album)
        {
            this.Query = $@" INSERT INTO [Album] ([Titulo], [Descricao], [Privacidade], [SegundosPorFoto], [Status], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@Titulo, @Descricao, @Privacidade, @SegundosPorFoto, @Status, @OperationalEntityId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Titulo = Album.Titulo,
                Descricao = Album.Descricao,
                Privacidade = Album.Privacidade,
                SegundosPorFoto = Album.SegundosPorFoto,
                Status = Album.Status,
                OperationalEntityId = Album.OperationalEntityId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlbumQuery(IAlbumEntity Album)
        {
            this.Query = $@" UPDATE [Album] SET [Titulo] = @Titulo, [Descricao] = @Descricao, [Privacidade] = @Privacidade, [SegundosPorFoto] = @SegundosPorFoto, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Titulo = Album.Titulo,
                Descricao = Album.Descricao,
                Privacidade = Album.Privacidade,
                SegundosPorFoto = Album.SegundosPorFoto,
                Status = Album.Status,
                Changed = Album.Changed,
                UserId = _executionContext.UserId,
                Id = Album.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTitulo(int id, string value)
        {
            this.Query = $@" UPDATE [Album] SET [Titulo] = @Titulo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Titulo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(int id, string value)
        {
            this.Query = $@" UPDATE [Album] SET [Descricao] = @Descricao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePrivacidade(int id, int value)
        {
            this.Query = $@" UPDATE [Album] SET [Privacidade] = @Privacidade WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Privacidade = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSegundosPorFoto(int id, int value)
        {
            this.Query = $@" UPDATE [Album] SET [SegundosPorFoto] = @SegundosPorFoto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SegundosPorFoto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [Album] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperationalEntityId(int id, string value)
        {
            this.Query = $@" UPDATE [Album] SET [OperationalEntityId] = @OperationalEntityId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OperationalEntityId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [Album] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [Album] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [Album] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [Album] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteAlbumQuery(IAlbumEntity Album)
        {
            this.Query = $@" DELETE FROM [Album] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = Album.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration