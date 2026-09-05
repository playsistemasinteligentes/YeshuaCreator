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
    public class PontosMapaQueryWrite : QueryBase, IPontosMapaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PontosMapaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPontosMapaQuery(IPontosMapaEntity PontosMapa)
        {
            this.Query = $@" INSERT INTO [PontosMapa] ([PON_ID], [PON_DESCRICAO], [PON_TIPO], [PON_LATITUDE], [PON_LONGITUDE], [PON_DISTANCIA_KM], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@PON_ID, @PON_DESCRICAO, @PON_TIPO, @PON_LATITUDE, @PON_LONGITUDE, @PON_DISTANCIA_KM, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PON_ID = PontosMapa.PON_ID,
                PON_DESCRICAO = PontosMapa.PON_DESCRICAO,
                PON_TIPO = PontosMapa.PON_TIPO,
                PON_LATITUDE = PontosMapa.PON_LATITUDE,
                PON_LONGITUDE = PontosMapa.PON_LONGITUDE,
                PON_DISTANCIA_KM = PontosMapa.PON_DISTANCIA_KM,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePontosMapaQuery(IPontosMapaEntity PontosMapa)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_DESCRICAO] = @PON_DESCRICAO, [PON_TIPO] = @PON_TIPO, [PON_LATITUDE] = @PON_LATITUDE, [PON_LONGITUDE] = @PON_LONGITUDE, [PON_DISTANCIA_KM] = @PON_DISTANCIA_KM, [Changed] = @Changed, [UserId] = @UserId WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_DESCRICAO = PontosMapa.PON_DESCRICAO,
                PON_TIPO = PontosMapa.PON_TIPO,
                PON_LATITUDE = PontosMapa.PON_LATITUDE,
                PON_LONGITUDE = PontosMapa.PON_LONGITUDE,
                PON_DISTANCIA_KM = PontosMapa.PON_DISTANCIA_KM,
                Changed = PontosMapa.Changed,
                UserId = _executionContext.UserId,
                PON_ID = PontosMapa.PON_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_DESCRICAO(string pon_id, string value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_DESCRICAO] = @PON_DESCRICAO WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_DESCRICAO = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_TIPO(string pon_id, string value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_TIPO] = @PON_TIPO WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_TIPO = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_LATITUDE(string pon_id, Decimal value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_LATITUDE] = @PON_LATITUDE WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_LATITUDE = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_LONGITUDE(string pon_id, Decimal value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_LONGITUDE] = @PON_LONGITUDE WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_LONGITUDE = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_DISTANCIA_KM(string pon_id, Decimal value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [PON_DISTANCIA_KM] = @PON_DISTANCIA_KM WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_DISTANCIA_KM = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string pon_id, int value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [TenantID] = @TenantID WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string pon_id, bool value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [Deleted] = @Deleted WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string pon_id, DateTime value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [Changed] = @Changed WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                Changed = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string pon_id, int value)
        {
            this.Query = $@" UPDATE [PontosMapa] SET [UserId] = @UserId WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                UserId = value,
                PON_ID = pon_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePontosMapaQuery(IPontosMapaEntity PontosMapa)
        {
            this.Query = $@" DELETE FROM [PontosMapa] WHERE [PON_ID] = @PON_ID ";
            this.Parameters = new
            {
                PON_ID = PontosMapa.PON_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration