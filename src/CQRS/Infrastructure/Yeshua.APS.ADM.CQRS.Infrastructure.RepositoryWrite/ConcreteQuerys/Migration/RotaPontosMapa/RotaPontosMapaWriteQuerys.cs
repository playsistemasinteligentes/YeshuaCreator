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
    public class RotaPontosMapaQueryWrite : QueryBase, IRotaPontosMapaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RotaPontosMapaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa)
        {
            this.Query = $@" INSERT INTO RotaPontosMapa (ROT_ID, PON_ID_DESTINO, PON_ID_ORIGEM, ROT_CUSTO_TOTAL, PON_ID_ROTEIRO, ROT_ORDEM_ROTEIRO, ROT_TIPO, ROT_DISTANCIA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ROT_ID, @PON_ID_DESTINO, @PON_ID_ORIGEM, @ROT_CUSTO_TOTAL, @PON_ID_ROTEIRO, @ROT_ORDEM_ROTEIRO, @ROT_TIPO, @ROT_DISTANCIA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ROT_ID = RotaPontosMapa.ROT_ID,
                PON_ID_DESTINO = RotaPontosMapa.PON_ID_DESTINO,
                PON_ID_ORIGEM = RotaPontosMapa.PON_ID_ORIGEM,
                ROT_CUSTO_TOTAL = RotaPontosMapa.ROT_CUSTO_TOTAL,
                PON_ID_ROTEIRO = RotaPontosMapa.PON_ID_ROTEIRO,
                ROT_ORDEM_ROTEIRO = RotaPontosMapa.ROT_ORDEM_ROTEIRO,
                ROT_TIPO = RotaPontosMapa.ROT_TIPO,
                ROT_DISTANCIA = RotaPontosMapa.ROT_DISTANCIA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_ID = @ROT_ID, PON_ID_DESTINO = @PON_ID_DESTINO, PON_ID_ORIGEM = @PON_ID_ORIGEM, ROT_CUSTO_TOTAL = @ROT_CUSTO_TOTAL, PON_ID_ROTEIRO = @PON_ID_ROTEIRO, ROT_ORDEM_ROTEIRO = @ROT_ORDEM_ROTEIRO, ROT_TIPO = @ROT_TIPO, ROT_DISTANCIA = @ROT_DISTANCIA, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_ID = RotaPontosMapa.ROT_ID,
                PON_ID_DESTINO = RotaPontosMapa.PON_ID_DESTINO,
                PON_ID_ORIGEM = RotaPontosMapa.PON_ID_ORIGEM,
                ROT_CUSTO_TOTAL = RotaPontosMapa.ROT_CUSTO_TOTAL,
                PON_ID_ROTEIRO = RotaPontosMapa.PON_ID_ROTEIRO,
                ROT_ORDEM_ROTEIRO = RotaPontosMapa.ROT_ORDEM_ROTEIRO,
                ROT_TIPO = RotaPontosMapa.ROT_TIPO,
                ROT_DISTANCIA = RotaPontosMapa.ROT_DISTANCIA,
                Changed = RotaPontosMapa.Changed,
                UserId = _executionContext.UserId,
                Id = RotaPontosMapa.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_ID(int id, string value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_ID = @ROT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_ID_DESTINO(int id, string value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET PON_ID_DESTINO = @PON_ID_DESTINO WHERE Id = @Id ";
            this.Parameters = new
            {
                PON_ID_DESTINO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET PON_ID_ORIGEM = @PON_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                PON_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_CUSTO_TOTAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_CUSTO_TOTAL = @ROT_CUSTO_TOTAL WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_CUSTO_TOTAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_ID_ROTEIRO(int id, string value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET PON_ID_ROTEIRO = @PON_ID_ROTEIRO WHERE Id = @Id ";
            this.Parameters = new
            {
                PON_ID_ROTEIRO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_ORDEM_ROTEIRO(int id, int value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_ORDEM_ROTEIRO = @ROT_ORDEM_ROTEIRO WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_ORDEM_ROTEIRO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_TIPO = @ROT_TIPO WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_DISTANCIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET ROT_DISTANCIA = @ROT_DISTANCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_DISTANCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE RotaPontosMapa SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRotaPontosMapaQuery(IRotaPontosMapaEntity RotaPontosMapa)
        {
            this.Query = $@" DELETE FROM RotaPontosMapa WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = RotaPontosMapa.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration