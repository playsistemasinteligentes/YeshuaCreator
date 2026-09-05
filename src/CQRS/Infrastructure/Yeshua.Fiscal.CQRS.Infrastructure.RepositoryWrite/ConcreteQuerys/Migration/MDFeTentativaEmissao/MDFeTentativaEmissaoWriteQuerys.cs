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
    public class MDFeTentativaEmissaoQueryWrite : QueryBase, IMDFeTentativaEmissaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeTentativaEmissaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeTentativaEmissaoQuery(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            this.Query = $@" INSERT INTO [MDFeTentativaEmissao] ([MDFeSolicitacaoFiscalId], [ChaveAcesso], [Numero], [Serie], [Tentativa], [XmlAssinadoStorageKey], [XmlProcStorageKey], [XmlHash], [CodigoRetorno], [MensagemRetorno], [ProtocoloAutorizacao], [EnviadoEmUtc], [AutorizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDFeSolicitacaoFiscalId, @ChaveAcesso, @Numero, @Serie, @Tentativa, @XmlAssinadoStorageKey, @XmlProcStorageKey, @XmlHash, @CodigoRetorno, @MensagemRetorno, @ProtocoloAutorizacao, @EnviadoEmUtc, @AutorizadoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeTentativaEmissao.MDFeSolicitacaoFiscalId,
                ChaveAcesso = MDFeTentativaEmissao.ChaveAcesso,
                Numero = MDFeTentativaEmissao.Numero,
                Serie = MDFeTentativaEmissao.Serie,
                Tentativa = MDFeTentativaEmissao.Tentativa,
                XmlAssinadoStorageKey = MDFeTentativaEmissao.XmlAssinadoStorageKey,
                XmlProcStorageKey = MDFeTentativaEmissao.XmlProcStorageKey,
                XmlHash = MDFeTentativaEmissao.XmlHash,
                CodigoRetorno = MDFeTentativaEmissao.CodigoRetorno,
                MensagemRetorno = MDFeTentativaEmissao.MensagemRetorno,
                ProtocoloAutorizacao = MDFeTentativaEmissao.ProtocoloAutorizacao,
                EnviadoEmUtc = MDFeTentativaEmissao.EnviadoEmUtc,
                AutorizadoEmUtc = MDFeTentativaEmissao.AutorizadoEmUtc,
                Status = MDFeTentativaEmissao.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeTentativaEmissaoQuery(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId, [ChaveAcesso] = @ChaveAcesso, [Numero] = @Numero, [Serie] = @Serie, [Tentativa] = @Tentativa, [XmlAssinadoStorageKey] = @XmlAssinadoStorageKey, [XmlProcStorageKey] = @XmlProcStorageKey, [XmlHash] = @XmlHash, [CodigoRetorno] = @CodigoRetorno, [MensagemRetorno] = @MensagemRetorno, [ProtocoloAutorizacao] = @ProtocoloAutorizacao, [EnviadoEmUtc] = @EnviadoEmUtc, [AutorizadoEmUtc] = @AutorizadoEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeTentativaEmissao.MDFeSolicitacaoFiscalId,
                ChaveAcesso = MDFeTentativaEmissao.ChaveAcesso,
                Numero = MDFeTentativaEmissao.Numero,
                Serie = MDFeTentativaEmissao.Serie,
                Tentativa = MDFeTentativaEmissao.Tentativa,
                XmlAssinadoStorageKey = MDFeTentativaEmissao.XmlAssinadoStorageKey,
                XmlProcStorageKey = MDFeTentativaEmissao.XmlProcStorageKey,
                XmlHash = MDFeTentativaEmissao.XmlHash,
                CodigoRetorno = MDFeTentativaEmissao.CodigoRetorno,
                MensagemRetorno = MDFeTentativaEmissao.MensagemRetorno,
                ProtocoloAutorizacao = MDFeTentativaEmissao.ProtocoloAutorizacao,
                EnviadoEmUtc = MDFeTentativaEmissao.EnviadoEmUtc,
                AutorizadoEmUtc = MDFeTentativaEmissao.AutorizadoEmUtc,
                Status = MDFeTentativaEmissao.Status,
                Changed = MDFeTentativaEmissao.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeTentativaEmissao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Numero] = @Numero WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Serie] = @Serie WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTentativa(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Tentativa] = @Tentativa WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Tentativa = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlAssinadoStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [XmlAssinadoStorageKey] = @XmlAssinadoStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlAssinadoStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlProcStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [XmlProcStorageKey] = @XmlProcStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlProcStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlHash(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [XmlHash] = @XmlHash WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigoRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [CodigoRetorno] = @CodigoRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CodigoRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [MensagemRetorno] = @MensagemRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MensagemRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocoloAutorizacao(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [ProtocoloAutorizacao] = @ProtocoloAutorizacao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProtocoloAutorizacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEnviadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [EnviadoEmUtc] = @EnviadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EnviadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAutorizadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [AutorizadoEmUtc] = @AutorizadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AutorizadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeTentativaEmissao] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeTentativaEmissaoQuery(IMDFeTentativaEmissaoEntity MDFeTentativaEmissao)
        {
            this.Query = $@" DELETE FROM [MDFeTentativaEmissao] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFeTentativaEmissao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration