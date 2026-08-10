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
    public class MDFeEncerramentoQueryWrite : QueryBase, IMDFeEncerramentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeEncerramentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            this.Query = $@" INSERT INTO MDFeEncerramento (MDFeId, ChaveAcesso, UfCarregamento, UfDescarregamento, PlacaVeiculo, SolicitadoEm, AutorizadoEm, Protocolo, CodigoRetorno, MensagemRetorno, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MDFeId, @ChaveAcesso, @UfCarregamento, @UfDescarregamento, @PlacaVeiculo, @SolicitadoEm, @AutorizadoEm, @Protocolo, @CodigoRetorno, @MensagemRetorno, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeId = MDFeEncerramento.MDFeId,
                ChaveAcesso = MDFeEncerramento.ChaveAcesso,
                UfCarregamento = MDFeEncerramento.UfCarregamento,
                UfDescarregamento = MDFeEncerramento.UfDescarregamento,
                PlacaVeiculo = MDFeEncerramento.PlacaVeiculo,
                SolicitadoEm = MDFeEncerramento.SolicitadoEm,
                AutorizadoEm = MDFeEncerramento.AutorizadoEm,
                Protocolo = MDFeEncerramento.Protocolo,
                CodigoRetorno = MDFeEncerramento.CodigoRetorno,
                MensagemRetorno = MDFeEncerramento.MensagemRetorno,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET MDFeId = @MDFeId, ChaveAcesso = @ChaveAcesso, UfCarregamento = @UfCarregamento, UfDescarregamento = @UfDescarregamento, PlacaVeiculo = @PlacaVeiculo, SolicitadoEm = @SolicitadoEm, AutorizadoEm = @AutorizadoEm, Protocolo = @Protocolo, CodigoRetorno = @CodigoRetorno, MensagemRetorno = @MensagemRetorno, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MDFeId = MDFeEncerramento.MDFeId,
                ChaveAcesso = MDFeEncerramento.ChaveAcesso,
                UfCarregamento = MDFeEncerramento.UfCarregamento,
                UfDescarregamento = MDFeEncerramento.UfDescarregamento,
                PlacaVeiculo = MDFeEncerramento.PlacaVeiculo,
                SolicitadoEm = MDFeEncerramento.SolicitadoEm,
                AutorizadoEm = MDFeEncerramento.AutorizadoEm,
                Protocolo = MDFeEncerramento.Protocolo,
                CodigoRetorno = MDFeEncerramento.CodigoRetorno,
                MensagemRetorno = MDFeEncerramento.MensagemRetorno,
                Changed = MDFeEncerramento.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeEncerramento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeId(int id, int value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET MDFeId = @MDFeId WHERE Id = @Id ";
            this.Parameters = new
            {
                MDFeId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET ChaveAcesso = @ChaveAcesso WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUfCarregamento(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET UfCarregamento = @UfCarregamento WHERE Id = @Id ";
            this.Parameters = new
            {
                UfCarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUfDescarregamento(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET UfDescarregamento = @UfDescarregamento WHERE Id = @Id ";
            this.Parameters = new
            {
                UfDescarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlacaVeiculo(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET PlacaVeiculo = @PlacaVeiculo WHERE Id = @Id ";
            this.Parameters = new
            {
                PlacaVeiculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSolicitadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET SolicitadoEm = @SolicitadoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                SolicitadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAutorizadoEm(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET AutorizadoEm = @AutorizadoEm WHERE Id = @Id ";
            this.Parameters = new
            {
                AutorizadoEm = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocolo(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET Protocolo = @Protocolo WHERE Id = @Id ";
            this.Parameters = new
            {
                Protocolo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigoRetorno(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET CodigoRetorno = @CodigoRetorno WHERE Id = @Id ";
            this.Parameters = new
            {
                CodigoRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemRetorno(int id, string value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET MensagemRetorno = @MensagemRetorno WHERE Id = @Id ";
            this.Parameters = new
            {
                MensagemRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MDFeEncerramento SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            this.Query = $@" DELETE FROM MDFeEncerramento WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MDFeEncerramento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration