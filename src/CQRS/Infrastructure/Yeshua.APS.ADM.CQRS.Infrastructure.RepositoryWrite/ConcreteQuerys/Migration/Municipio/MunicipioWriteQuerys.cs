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
    public class MunicipioQueryWrite : QueryBase, IMunicipioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MunicipioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMunicipioQuery(IMunicipioEntity Municipio)
        {
            this.Query = $@" INSERT INTO Municipio (MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId) VALUES(@MUN_ID, @MUN_NOME, @UF_COD, @MUN_CODIGO_IBGE, @MUN_LATITUDE, @MUN_LONGITUDE, @MUN_ID_INTEGRACAO_ERP, @MUN_CODIGO_SIAFI, @MUN_CODIGO_CNPJ, @MUN_DISTANCIA_KM, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MUN_ID = Municipio.MUN_ID,
                MUN_NOME = Municipio.MUN_NOME,
                UF_COD = Municipio.UF_COD,
                MUN_CODIGO_IBGE = Municipio.MUN_CODIGO_IBGE,
                MUN_LATITUDE = Municipio.MUN_LATITUDE,
                MUN_LONGITUDE = Municipio.MUN_LONGITUDE,
                MUN_ID_INTEGRACAO_ERP = Municipio.MUN_ID_INTEGRACAO_ERP,
                MUN_CODIGO_SIAFI = Municipio.MUN_CODIGO_SIAFI,
                MUN_CODIGO_CNPJ = Municipio.MUN_CODIGO_CNPJ,
                MUN_DISTANCIA_KM = Municipio.MUN_DISTANCIA_KM,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioQuery(IMunicipioEntity Municipio)
        {
            this.Query = $@" UPDATE Municipio SET MUN_NOME = @MUN_NOME, UF_COD = @UF_COD, MUN_CODIGO_IBGE = @MUN_CODIGO_IBGE, MUN_LATITUDE = @MUN_LATITUDE, MUN_LONGITUDE = @MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP = @MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI = @MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ = @MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM = @MUN_DISTANCIA_KM, Changed = @Changed, UserId = @UserId WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_NOME = Municipio.MUN_NOME,
                UF_COD = Municipio.UF_COD,
                MUN_CODIGO_IBGE = Municipio.MUN_CODIGO_IBGE,
                MUN_LATITUDE = Municipio.MUN_LATITUDE,
                MUN_LONGITUDE = Municipio.MUN_LONGITUDE,
                MUN_ID_INTEGRACAO_ERP = Municipio.MUN_ID_INTEGRACAO_ERP,
                MUN_CODIGO_SIAFI = Municipio.MUN_CODIGO_SIAFI,
                MUN_CODIGO_CNPJ = Municipio.MUN_CODIGO_CNPJ,
                MUN_DISTANCIA_KM = Municipio.MUN_DISTANCIA_KM,
                Changed = Municipio.Changed,
                UserId = _executionContext.UserId,
                MUN_ID = Municipio.MUN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_NOME(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_NOME = @MUN_NOME WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_NOME = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUF_COD(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET UF_COD = @UF_COD WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                UF_COD = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_CODIGO_IBGE(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_CODIGO_IBGE = @MUN_CODIGO_IBGE WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_CODIGO_IBGE = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_LATITUDE(string mun_id, Decimal value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_LATITUDE = @MUN_LATITUDE WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_LATITUDE = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_LONGITUDE(string mun_id, Decimal value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_LONGITUDE = @MUN_LONGITUDE WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_LONGITUDE = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_ID_INTEGRACAO_ERP(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_ID_INTEGRACAO_ERP = @MUN_ID_INTEGRACAO_ERP WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_ID_INTEGRACAO_ERP = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_CODIGO_SIAFI(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_CODIGO_SIAFI = @MUN_CODIGO_SIAFI WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_CODIGO_SIAFI = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_CODIGO_CNPJ(string mun_id, string value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_CODIGO_CNPJ = @MUN_CODIGO_CNPJ WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_CODIGO_CNPJ = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_DISTANCIA_KM(string mun_id, Decimal value)
        {
            this.Query = $@" UPDATE Municipio SET MUN_DISTANCIA_KM = @MUN_DISTANCIA_KM WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_DISTANCIA_KM = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string mun_id, int value)
        {
            this.Query = $@" UPDATE Municipio SET TenantID = @TenantID WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string mun_id, bool value)
        {
            this.Query = $@" UPDATE Municipio SET Deleted = @Deleted WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string mun_id, DateTime value)
        {
            this.Query = $@" UPDATE Municipio SET Changed = @Changed WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                Changed = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string mun_id, int value)
        {
            this.Query = $@" UPDATE Municipio SET UserId = @UserId WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                UserId = value,
                MUN_ID = mun_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMunicipioQuery(IMunicipioEntity Municipio)
        {
            this.Query = $@" DELETE FROM Municipio WHERE MUN_ID = @MUN_ID ";
            this.Parameters = new
            {
                MUN_ID = Municipio.MUN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration