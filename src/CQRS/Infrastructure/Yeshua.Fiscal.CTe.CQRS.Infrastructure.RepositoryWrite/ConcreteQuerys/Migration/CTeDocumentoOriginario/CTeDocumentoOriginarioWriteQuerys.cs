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
    public class CTeDocumentoOriginarioQueryWrite : QueryBase, ICTeDocumentoOriginarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeDocumentoOriginarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            this.Query = $@" INSERT INTO CTeDocumentoOriginario (CTeSolicitacaoFiscalId, TipoDocumento, ChaveAcesso, Numero, Serie, EmitenteDocumento, DestinatarioDocumento, ValorDocumento, PesoBruto, SnapshotJson, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CTeSolicitacaoFiscalId, @TipoDocumento, @ChaveAcesso, @Numero, @Serie, @EmitenteDocumento, @DestinatarioDocumento, @ValorDocumento, @PesoBruto, @SnapshotJson, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeDocumentoOriginario.CTeSolicitacaoFiscalId,
                TipoDocumento = CTeDocumentoOriginario.TipoDocumento,
                ChaveAcesso = CTeDocumentoOriginario.ChaveAcesso,
                Numero = CTeDocumentoOriginario.Numero,
                Serie = CTeDocumentoOriginario.Serie,
                EmitenteDocumento = CTeDocumentoOriginario.EmitenteDocumento,
                DestinatarioDocumento = CTeDocumentoOriginario.DestinatarioDocumento,
                ValorDocumento = CTeDocumentoOriginario.ValorDocumento,
                PesoBruto = CTeDocumentoOriginario.PesoBruto,
                SnapshotJson = CTeDocumentoOriginario.SnapshotJson,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId, TipoDocumento = @TipoDocumento, ChaveAcesso = @ChaveAcesso, Numero = @Numero, Serie = @Serie, EmitenteDocumento = @EmitenteDocumento, DestinatarioDocumento = @DestinatarioDocumento, ValorDocumento = @ValorDocumento, PesoBruto = @PesoBruto, SnapshotJson = @SnapshotJson, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeDocumentoOriginario.CTeSolicitacaoFiscalId,
                TipoDocumento = CTeDocumentoOriginario.TipoDocumento,
                ChaveAcesso = CTeDocumentoOriginario.ChaveAcesso,
                Numero = CTeDocumentoOriginario.Numero,
                Serie = CTeDocumentoOriginario.Serie,
                EmitenteDocumento = CTeDocumentoOriginario.EmitenteDocumento,
                DestinatarioDocumento = CTeDocumentoOriginario.DestinatarioDocumento,
                ValorDocumento = CTeDocumentoOriginario.ValorDocumento,
                PesoBruto = CTeDocumentoOriginario.PesoBruto,
                SnapshotJson = CTeDocumentoOriginario.SnapshotJson,
                Changed = CTeDocumentoOriginario.Changed,
                UserId = _executionContext.UserId,
                Id = CTeDocumentoOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET TipoDocumento = @TipoDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                TipoDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET ChaveAcesso = @ChaveAcesso WHERE Id = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET Numero = @Numero WHERE Id = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET Serie = @Serie WHERE Id = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET EmitenteDocumento = @EmitenteDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDestinatarioDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET DestinatarioDocumento = @DestinatarioDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                DestinatarioDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorDocumento(int id, Decimal value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET ValorDocumento = @ValorDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                ValorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET PesoBruto = @PesoBruto WHERE Id = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET SnapshotJson = @SnapshotJson WHERE Id = @Id ";
            this.Parameters = new
            {
                SnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CTeDocumentoOriginario SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeDocumentoOriginarioQuery(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            this.Query = $@" DELETE FROM CTeDocumentoOriginario WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CTeDocumentoOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration