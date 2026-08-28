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
    public class MapaQueryWrite : QueryBase, IMapaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MapaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMapaQuery(IMapaEntity Mapa)
        {
            this.Query = $@" INSERT INTO Mapa (PON_ID, PON_ID_VIZINHO, MAP_DISTANCIA, MAP_CUSTO_PEDAGIO_POR_EIXO, ROD_ID, MAP_ALTURA_ROD, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@PON_ID, @PON_ID_VIZINHO, @MAP_DISTANCIA, @MAP_CUSTO_PEDAGIO_POR_EIXO, @ROD_ID, @MAP_ALTURA_ROD, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PON_ID = Mapa.PON_ID,
                PON_ID_VIZINHO = Mapa.PON_ID_VIZINHO,
                MAP_DISTANCIA = Mapa.MAP_DISTANCIA,
                MAP_CUSTO_PEDAGIO_POR_EIXO = Mapa.MAP_CUSTO_PEDAGIO_POR_EIXO,
                ROD_ID = Mapa.ROD_ID,
                MAP_ALTURA_ROD = Mapa.MAP_ALTURA_ROD,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMapaQuery(IMapaEntity Mapa)
        {
            this.Query = $@" UPDATE Mapa SET MAP_ID = @MAP_ID, PON_ID = @PON_ID, PON_ID_VIZINHO = @PON_ID_VIZINHO, MAP_DISTANCIA = @MAP_DISTANCIA, MAP_CUSTO_PEDAGIO_POR_EIXO = @MAP_CUSTO_PEDAGIO_POR_EIXO, ROD_ID = @ROD_ID, MAP_ALTURA_ROD = @MAP_ALTURA_ROD, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MAP_ID = Mapa.MAP_ID,
                PON_ID = Mapa.PON_ID,
                PON_ID_VIZINHO = Mapa.PON_ID_VIZINHO,
                MAP_DISTANCIA = Mapa.MAP_DISTANCIA,
                MAP_CUSTO_PEDAGIO_POR_EIXO = Mapa.MAP_CUSTO_PEDAGIO_POR_EIXO,
                ROD_ID = Mapa.ROD_ID,
                MAP_ALTURA_ROD = Mapa.MAP_ALTURA_ROD,
                Changed = Mapa.Changed,
                UserId = _executionContext.UserId,
                Id = Mapa.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAP_ID(int id, int value)
        {
            this.Query = $@" UPDATE Mapa SET MAP_ID = @MAP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MAP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_ID(int id, string value)
        {
            this.Query = $@" UPDATE Mapa SET PON_ID = @PON_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PON_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePON_ID_VIZINHO(int id, string value)
        {
            this.Query = $@" UPDATE Mapa SET PON_ID_VIZINHO = @PON_ID_VIZINHO WHERE Id = @Id ";
            this.Parameters = new
            {
                PON_ID_VIZINHO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAP_DISTANCIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Mapa SET MAP_DISTANCIA = @MAP_DISTANCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                MAP_DISTANCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAP_CUSTO_PEDAGIO_POR_EIXO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Mapa SET MAP_CUSTO_PEDAGIO_POR_EIXO = @MAP_CUSTO_PEDAGIO_POR_EIXO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAP_CUSTO_PEDAGIO_POR_EIXO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROD_ID(int id, int value)
        {
            this.Query = $@" UPDATE Mapa SET ROD_ID = @ROD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAP_ALTURA_ROD(int id, Decimal value)
        {
            this.Query = $@" UPDATE Mapa SET MAP_ALTURA_ROD = @MAP_ALTURA_ROD WHERE Id = @Id ";
            this.Parameters = new
            {
                MAP_ALTURA_ROD = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Mapa SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Mapa SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Mapa SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Mapa SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMapaQuery(IMapaEntity Mapa)
        {
            this.Query = $@" DELETE FROM Mapa WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Mapa.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration