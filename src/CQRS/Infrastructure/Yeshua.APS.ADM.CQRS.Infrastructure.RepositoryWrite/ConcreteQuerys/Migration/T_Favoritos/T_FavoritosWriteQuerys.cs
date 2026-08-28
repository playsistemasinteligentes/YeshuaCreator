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
    public class T_FavoritosQueryWrite : QueryBase, IT_FavoritosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_FavoritosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_FavoritosQuery(IT_FavoritosEntity T_Favoritos)
        {
            this.Query = $@" INSERT INTO T_Favoritos (USE_ID, ID_INDICADOR, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.IDFAVORITO VALUES(@USE_ID, @ID_INDICADOR, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                USE_ID = T_Favoritos.USE_ID,
                ID_INDICADOR = T_Favoritos.ID_INDICADOR,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_FavoritosQuery(IT_FavoritosEntity T_Favoritos)
        {
            this.Query = $@" UPDATE T_Favoritos SET USE_ID = @USE_ID, ID_INDICADOR = @ID_INDICADOR, Changed = @Changed, UserId = @UserId WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                USE_ID = T_Favoritos.USE_ID,
                ID_INDICADOR = T_Favoritos.ID_INDICADOR,
                Changed = T_Favoritos.Changed,
                UserId = _executionContext.UserId,
                IDFAVORITO = T_Favoritos.IDFAVORITO,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int idfavorito, int value)
        {
            this.Query = $@" UPDATE T_Favoritos SET USE_ID = @USE_ID WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                USE_ID = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateID_INDICADOR(int idfavorito, int value)
        {
            this.Query = $@" UPDATE T_Favoritos SET ID_INDICADOR = @ID_INDICADOR WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                ID_INDICADOR = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int idfavorito, int value)
        {
            this.Query = $@" UPDATE T_Favoritos SET TenantID = @TenantID WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                TenantID = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int idfavorito, bool value)
        {
            this.Query = $@" UPDATE T_Favoritos SET Deleted = @Deleted WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                Deleted = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int idfavorito, DateTime value)
        {
            this.Query = $@" UPDATE T_Favoritos SET Changed = @Changed WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                Changed = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int idfavorito, int value)
        {
            this.Query = $@" UPDATE T_Favoritos SET UserId = @UserId WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                UserId = value,
                IDFAVORITO = idfavorito,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_FavoritosQuery(IT_FavoritosEntity T_Favoritos)
        {
            this.Query = $@" DELETE FROM T_Favoritos WHERE IDFAVORITO = @IDFAVORITO ";
            this.Parameters = new
            {
                IDFAVORITO = T_Favoritos.IDFAVORITO,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration