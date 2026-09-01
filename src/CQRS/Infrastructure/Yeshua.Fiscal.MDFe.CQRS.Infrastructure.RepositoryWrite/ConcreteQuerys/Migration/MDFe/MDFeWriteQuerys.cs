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
    public class MDFeQueryWrite : QueryBase, IMDFeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeQuery(IMDFeEntity MDFe)
        {
            this.Query = $@" INSERT INTO MDFe (ChaveAcesso, Serie, Numero, UfCarregamento, UfDescarregamento, PlacaVeiculo, EmitidoEm, AutorizadoEm, IniciadoEm, EncerradoEm, CanceladoEm, Situacao, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ChaveAcesso, @Serie, @Numero, @UfCarregamento, @UfDescarregamento, @PlacaVeiculo, @EmitidoEm, @AutorizadoEm, @IniciadoEm, @EncerradoEm, @CanceladoEm, @Situacao, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ChaveAcesso = MDFe.ChaveAcesso,
                Serie = MDFe.Serie,
                Numero = MDFe.Numero,
                UfCarregamento = MDFe.UfCarregamento,
                UfDescarregamento = MDFe.UfDescarregamento,
                PlacaVeiculo = MDFe.PlacaVeiculo,
                EmitidoEm = MDFe.EmitidoEm,
                AutorizadoEm = MDFe.AutorizadoEm,
                IniciadoEm = MDFe.IniciadoEm,
                EncerradoEm = MDFe.EncerradoEm,
                CanceladoEm = MDFe.CanceladoEm,
                Situacao = MDFe.Situacao,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeQuery(IMDFeEntity MDFe)
        {
            this.Query = $@" UPDATE MDFe SET ChaveAcesso = @ChaveAcesso, Serie = @Serie, Numero = @Numero, UfCarregamento = @UfCarregamento, UfDescarregamento = @UfDescarregamento, PlacaVeiculo = @PlacaVeiculo, EmitidoEm = @EmitidoEm, AutorizadoEm = @AutorizadoEm, IniciadoEm = @IniciadoEm, EncerradoEm = @EncerradoEm, CanceladoEm = @CanceladoEm, Situacao = @Situacao, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = MDFe.ChaveAcesso,
                Serie = MDFe.Serie,
                Numero = MDFe.Numero,
                UfCarregamento = MDFe.UfCarregamento,
                UfDescarregamento = MDFe.UfDescarregamento,
                PlacaVeiculo = MDFe.PlacaVeiculo,
                EmitidoEm = MDFe.EmitidoEm,
                AutorizadoEm = MDFe.AutorizadoEm,
                IniciadoEm = MDFe.IniciadoEm,
                EncerradoEm = MDFe.EncerradoEm,
                CanceladoEm = MDFe.CanceladoEm,
                Situacao = MDFe.Situacao,
                Changed = MDFe.Changed,
                UserId = _executionContext.UserId,
                Id = MDFe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE MDFe SET ChaveAcesso = @ChaveAcesso WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, int value)
        {
            this.Query = $@" UPDATE MDFe SET Serie = @Serie WHERE Id = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, int value)
        {
            this.Query = $@" UPDATE MDFe SET Numero = @Numero WHERE Id = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUfCarregamento(int id, string value)
        {
            this.Query = $@" UPDATE MDFe SET UfCarregamento = @UfCarregamento WHERE Id = @Id ";
            this.Parameters = new
            {
                UfCarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUfDescarregamento(int id, string value)
        {
            this.Query = $@" UPDATE MDFe SET UfDescarregamento = @UfDescarregamento WHERE Id = @Id ";
            this.Parameters = new
            {
                UfDescarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlacaVeiculo(int id, string value)
        {
            this.Query = $@" UPDATE MDFe SET PlacaVeiculo = @PlacaVeiculo WHERE Id = @Id ";
            this.Parameters = new
            {
                PlacaVeiculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitidoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET EmitidoEm = @EmitidoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                EmitidoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAutorizadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET AutorizadoEm = @AutorizadoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                AutorizadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIniciadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET IniciadoEm = @IniciadoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                IniciadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEncerradoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET EncerradoEm = @EncerradoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                EncerradoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanceladoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET CanceladoEm = @CanceladoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                CanceladoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSituacao(int id, int value)
        {
            this.Query = $@" UPDATE MDFe SET Situacao = @Situacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Situacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MDFe SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MDFe SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFe SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MDFe SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeQuery(IMDFeEntity MDFe)
        {
            this.Query = $@" DELETE FROM MDFe WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MDFe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration