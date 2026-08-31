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
    public class CTeTentativaEmissaoQueryWrite : QueryBase, ICTeTentativaEmissaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeTentativaEmissaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao)
        {
            this.Query = $@" INSERT INTO CTeTentativaEmissao (CTeSolicitacaoFiscalId, ChaveAcesso, Numero, Serie, Tentativa, XmlAssinadoStorageKey, XmlProcStorageKey, XmlHash, CodigoRetorno, MensagemRetorno, ProtocoloAutorizacao, EnviadoEmUtc, AutorizadoEmUtc, Status, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CTeSolicitacaoFiscalId, @ChaveAcesso, @Numero, @Serie, @Tentativa, @XmlAssinadoStorageKey, @XmlProcStorageKey, @XmlHash, @CodigoRetorno, @MensagemRetorno, @ProtocoloAutorizacao, @EnviadoEmUtc, @AutorizadoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeTentativaEmissao.CTeSolicitacaoFiscalId,
                ChaveAcesso = CTeTentativaEmissao.ChaveAcesso,
                Numero = CTeTentativaEmissao.Numero,
                Serie = CTeTentativaEmissao.Serie,
                Tentativa = CTeTentativaEmissao.Tentativa,
                XmlAssinadoStorageKey = CTeTentativaEmissao.XmlAssinadoStorageKey,
                XmlProcStorageKey = CTeTentativaEmissao.XmlProcStorageKey,
                XmlHash = CTeTentativaEmissao.XmlHash,
                CodigoRetorno = CTeTentativaEmissao.CodigoRetorno,
                MensagemRetorno = CTeTentativaEmissao.MensagemRetorno,
                ProtocoloAutorizacao = CTeTentativaEmissao.ProtocoloAutorizacao,
                EnviadoEmUtc = CTeTentativaEmissao.EnviadoEmUtc,
                AutorizadoEmUtc = CTeTentativaEmissao.AutorizadoEmUtc,
                Status = CTeTentativaEmissao.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId, ChaveAcesso = @ChaveAcesso, Numero = @Numero, Serie = @Serie, Tentativa = @Tentativa, XmlAssinadoStorageKey = @XmlAssinadoStorageKey, XmlProcStorageKey = @XmlProcStorageKey, XmlHash = @XmlHash, CodigoRetorno = @CodigoRetorno, MensagemRetorno = @MensagemRetorno, ProtocoloAutorizacao = @ProtocoloAutorizacao, EnviadoEmUtc = @EnviadoEmUtc, AutorizadoEmUtc = @AutorizadoEmUtc, Status = @Status, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeTentativaEmissao.CTeSolicitacaoFiscalId,
                ChaveAcesso = CTeTentativaEmissao.ChaveAcesso,
                Numero = CTeTentativaEmissao.Numero,
                Serie = CTeTentativaEmissao.Serie,
                Tentativa = CTeTentativaEmissao.Tentativa,
                XmlAssinadoStorageKey = CTeTentativaEmissao.XmlAssinadoStorageKey,
                XmlProcStorageKey = CTeTentativaEmissao.XmlProcStorageKey,
                XmlHash = CTeTentativaEmissao.XmlHash,
                CodigoRetorno = CTeTentativaEmissao.CodigoRetorno,
                MensagemRetorno = CTeTentativaEmissao.MensagemRetorno,
                ProtocoloAutorizacao = CTeTentativaEmissao.ProtocoloAutorizacao,
                EnviadoEmUtc = CTeTentativaEmissao.EnviadoEmUtc,
                AutorizadoEmUtc = CTeTentativaEmissao.AutorizadoEmUtc,
                Status = CTeTentativaEmissao.Status,
                Changed = CTeTentativaEmissao.Changed,
                UserId = _executionContext.UserId,
                Id = CTeTentativaEmissao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET ChaveAcesso = @ChaveAcesso WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Numero = @Numero WHERE Id = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Serie = @Serie WHERE Id = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTentativa(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Tentativa = @Tentativa WHERE Id = @Id ";
            this.Parameters = new
            {
                Tentativa = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlAssinadoStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET XmlAssinadoStorageKey = @XmlAssinadoStorageKey WHERE Id = @Id ";
            this.Parameters = new
            {
                XmlAssinadoStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlProcStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET XmlProcStorageKey = @XmlProcStorageKey WHERE Id = @Id ";
            this.Parameters = new
            {
                XmlProcStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlHash(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET XmlHash = @XmlHash WHERE Id = @Id ";
            this.Parameters = new
            {
                XmlHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigoRetorno(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET CodigoRetorno = @CodigoRetorno WHERE Id = @Id ";
            this.Parameters = new
            {
                CodigoRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemRetorno(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET MensagemRetorno = @MensagemRetorno WHERE Id = @Id ";
            this.Parameters = new
            {
                MensagemRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocoloAutorizacao(int id, string value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET ProtocoloAutorizacao = @ProtocoloAutorizacao WHERE Id = @Id ";
            this.Parameters = new
            {
                ProtocoloAutorizacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEnviadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET EnviadoEmUtc = @EnviadoEmUtc WHERE Id = @Id ";
            this.Parameters = new
            {
                EnviadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAutorizadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET AutorizadoEmUtc = @AutorizadoEmUtc WHERE Id = @Id ";
            this.Parameters = new
            {
                AutorizadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CTeTentativaEmissao SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao)
        {
            this.Query = $@" DELETE FROM CTeTentativaEmissao WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CTeTentativaEmissao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration