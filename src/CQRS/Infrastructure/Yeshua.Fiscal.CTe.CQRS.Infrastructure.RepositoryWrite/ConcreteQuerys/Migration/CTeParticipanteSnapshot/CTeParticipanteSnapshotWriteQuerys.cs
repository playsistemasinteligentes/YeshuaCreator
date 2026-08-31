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
    public class CTeParticipanteSnapshotQueryWrite : QueryBase, ICTeParticipanteSnapshotQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeParticipanteSnapshotQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            this.Query = $@" INSERT INTO CTeParticipanteSnapshot (CTeSolicitacaoFiscalId, Papel, Documento, Nome, InscricaoEstadual, UF, MunicipioCodigoIbge, EnderecoJson, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CTeSolicitacaoFiscalId, @Papel, @Documento, @Nome, @InscricaoEstadual, @UF, @MunicipioCodigoIbge, @EnderecoJson, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeParticipanteSnapshot.CTeSolicitacaoFiscalId,
                Papel = CTeParticipanteSnapshot.Papel,
                Documento = CTeParticipanteSnapshot.Documento,
                Nome = CTeParticipanteSnapshot.Nome,
                InscricaoEstadual = CTeParticipanteSnapshot.InscricaoEstadual,
                UF = CTeParticipanteSnapshot.UF,
                MunicipioCodigoIbge = CTeParticipanteSnapshot.MunicipioCodigoIbge,
                EnderecoJson = CTeParticipanteSnapshot.EnderecoJson,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId, Papel = @Papel, Documento = @Documento, Nome = @Nome, InscricaoEstadual = @InscricaoEstadual, UF = @UF, MunicipioCodigoIbge = @MunicipioCodigoIbge, EnderecoJson = @EnderecoJson, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = CTeParticipanteSnapshot.CTeSolicitacaoFiscalId,
                Papel = CTeParticipanteSnapshot.Papel,
                Documento = CTeParticipanteSnapshot.Documento,
                Nome = CTeParticipanteSnapshot.Nome,
                InscricaoEstadual = CTeParticipanteSnapshot.InscricaoEstadual,
                UF = CTeParticipanteSnapshot.UF,
                MunicipioCodigoIbge = CTeParticipanteSnapshot.MunicipioCodigoIbge,
                EnderecoJson = CTeParticipanteSnapshot.EnderecoJson,
                Changed = CTeParticipanteSnapshot.Changed,
                UserId = _executionContext.UserId,
                Id = CTeParticipanteSnapshot.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET CTeSolicitacaoFiscalId = @CTeSolicitacaoFiscalId WHERE Id = @Id ";
            this.Parameters = new
            {
                CTeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePapel(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET Papel = @Papel WHERE Id = @Id ";
            this.Parameters = new
            {
                Papel = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET Documento = @Documento WHERE Id = @Id ";
            this.Parameters = new
            {
                Documento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInscricaoEstadual(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET InscricaoEstadual = @InscricaoEstadual WHERE Id = @Id ";
            this.Parameters = new
            {
                InscricaoEstadual = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUF(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET UF = @UF WHERE Id = @Id ";
            this.Parameters = new
            {
                UF = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET MunicipioCodigoIbge = @MunicipioCodigoIbge WHERE Id = @Id ";
            this.Parameters = new
            {
                MunicipioCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEnderecoJson(int id, string value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET EnderecoJson = @EnderecoJson WHERE Id = @Id ";
            this.Parameters = new
            {
                EnderecoJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CTeParticipanteSnapshot SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            this.Query = $@" DELETE FROM CTeParticipanteSnapshot WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CTeParticipanteSnapshot.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration