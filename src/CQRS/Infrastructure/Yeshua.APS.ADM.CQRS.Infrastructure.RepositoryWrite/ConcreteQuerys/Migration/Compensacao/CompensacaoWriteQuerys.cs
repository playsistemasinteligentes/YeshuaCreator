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
    public class CompensacaoQueryWrite : QueryBase, ICompensacaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CompensacaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCompensacaoQuery(ICompensacaoEntity Compensacao)
        {
            this.Query = $@" INSERT INTO Compensacao (GRP_ID, OND_ID, COM_VINCO1_OND, COM_VINCO2_OND, COM_VINCO3_OND, COM_VINCO4_OND, COM_VINCO5_OND, COM_VINCO6_OND, COM_VINCO7_OND, COM_VINCO8_OND, COM_VINCO9_OND, COM_VINCO10_OND, COM_VINCO1_CONVERSAO, COM_VINCO2_CONVERSAO, COM_VINCO3_CONVERSAO, COM_VINCO4_CONVERSAO, COM_VINCO5_CONVERSAO, COM_VINCO6_CONVERSAO, COM_VINCO7_CONVERSAO, COM_VINCO8_CONVERSAO, COM_VINCO9_CONVERSAO, COM_VINCO10_CONVERSAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@GRP_ID, @OND_ID, @COM_VINCO1_OND, @COM_VINCO2_OND, @COM_VINCO3_OND, @COM_VINCO4_OND, @COM_VINCO5_OND, @COM_VINCO6_OND, @COM_VINCO7_OND, @COM_VINCO8_OND, @COM_VINCO9_OND, @COM_VINCO10_OND, @COM_VINCO1_CONVERSAO, @COM_VINCO2_CONVERSAO, @COM_VINCO3_CONVERSAO, @COM_VINCO4_CONVERSAO, @COM_VINCO5_CONVERSAO, @COM_VINCO6_CONVERSAO, @COM_VINCO7_CONVERSAO, @COM_VINCO8_CONVERSAO, @COM_VINCO9_CONVERSAO, @COM_VINCO10_CONVERSAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRP_ID = Compensacao.GRP_ID,
                OND_ID = Compensacao.OND_ID,
                COM_VINCO1_OND = Compensacao.COM_VINCO1_OND,
                COM_VINCO2_OND = Compensacao.COM_VINCO2_OND,
                COM_VINCO3_OND = Compensacao.COM_VINCO3_OND,
                COM_VINCO4_OND = Compensacao.COM_VINCO4_OND,
                COM_VINCO5_OND = Compensacao.COM_VINCO5_OND,
                COM_VINCO6_OND = Compensacao.COM_VINCO6_OND,
                COM_VINCO7_OND = Compensacao.COM_VINCO7_OND,
                COM_VINCO8_OND = Compensacao.COM_VINCO8_OND,
                COM_VINCO9_OND = Compensacao.COM_VINCO9_OND,
                COM_VINCO10_OND = Compensacao.COM_VINCO10_OND,
                COM_VINCO1_CONVERSAO = Compensacao.COM_VINCO1_CONVERSAO,
                COM_VINCO2_CONVERSAO = Compensacao.COM_VINCO2_CONVERSAO,
                COM_VINCO3_CONVERSAO = Compensacao.COM_VINCO3_CONVERSAO,
                COM_VINCO4_CONVERSAO = Compensacao.COM_VINCO4_CONVERSAO,
                COM_VINCO5_CONVERSAO = Compensacao.COM_VINCO5_CONVERSAO,
                COM_VINCO6_CONVERSAO = Compensacao.COM_VINCO6_CONVERSAO,
                COM_VINCO7_CONVERSAO = Compensacao.COM_VINCO7_CONVERSAO,
                COM_VINCO8_CONVERSAO = Compensacao.COM_VINCO8_CONVERSAO,
                COM_VINCO9_CONVERSAO = Compensacao.COM_VINCO9_CONVERSAO,
                COM_VINCO10_CONVERSAO = Compensacao.COM_VINCO10_CONVERSAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCompensacaoQuery(ICompensacaoEntity Compensacao)
        {
            this.Query = $@" UPDATE Compensacao SET COM_ID = @COM_ID, GRP_ID = @GRP_ID, OND_ID = @OND_ID, COM_VINCO1_OND = @COM_VINCO1_OND, COM_VINCO2_OND = @COM_VINCO2_OND, COM_VINCO3_OND = @COM_VINCO3_OND, COM_VINCO4_OND = @COM_VINCO4_OND, COM_VINCO5_OND = @COM_VINCO5_OND, COM_VINCO6_OND = @COM_VINCO6_OND, COM_VINCO7_OND = @COM_VINCO7_OND, COM_VINCO8_OND = @COM_VINCO8_OND, COM_VINCO9_OND = @COM_VINCO9_OND, COM_VINCO10_OND = @COM_VINCO10_OND, COM_VINCO1_CONVERSAO = @COM_VINCO1_CONVERSAO, COM_VINCO2_CONVERSAO = @COM_VINCO2_CONVERSAO, COM_VINCO3_CONVERSAO = @COM_VINCO3_CONVERSAO, COM_VINCO4_CONVERSAO = @COM_VINCO4_CONVERSAO, COM_VINCO5_CONVERSAO = @COM_VINCO5_CONVERSAO, COM_VINCO6_CONVERSAO = @COM_VINCO6_CONVERSAO, COM_VINCO7_CONVERSAO = @COM_VINCO7_CONVERSAO, COM_VINCO8_CONVERSAO = @COM_VINCO8_CONVERSAO, COM_VINCO9_CONVERSAO = @COM_VINCO9_CONVERSAO, COM_VINCO10_CONVERSAO = @COM_VINCO10_CONVERSAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_ID = Compensacao.COM_ID,
                GRP_ID = Compensacao.GRP_ID,
                OND_ID = Compensacao.OND_ID,
                COM_VINCO1_OND = Compensacao.COM_VINCO1_OND,
                COM_VINCO2_OND = Compensacao.COM_VINCO2_OND,
                COM_VINCO3_OND = Compensacao.COM_VINCO3_OND,
                COM_VINCO4_OND = Compensacao.COM_VINCO4_OND,
                COM_VINCO5_OND = Compensacao.COM_VINCO5_OND,
                COM_VINCO6_OND = Compensacao.COM_VINCO6_OND,
                COM_VINCO7_OND = Compensacao.COM_VINCO7_OND,
                COM_VINCO8_OND = Compensacao.COM_VINCO8_OND,
                COM_VINCO9_OND = Compensacao.COM_VINCO9_OND,
                COM_VINCO10_OND = Compensacao.COM_VINCO10_OND,
                COM_VINCO1_CONVERSAO = Compensacao.COM_VINCO1_CONVERSAO,
                COM_VINCO2_CONVERSAO = Compensacao.COM_VINCO2_CONVERSAO,
                COM_VINCO3_CONVERSAO = Compensacao.COM_VINCO3_CONVERSAO,
                COM_VINCO4_CONVERSAO = Compensacao.COM_VINCO4_CONVERSAO,
                COM_VINCO5_CONVERSAO = Compensacao.COM_VINCO5_CONVERSAO,
                COM_VINCO6_CONVERSAO = Compensacao.COM_VINCO6_CONVERSAO,
                COM_VINCO7_CONVERSAO = Compensacao.COM_VINCO7_CONVERSAO,
                COM_VINCO8_CONVERSAO = Compensacao.COM_VINCO8_CONVERSAO,
                COM_VINCO9_CONVERSAO = Compensacao.COM_VINCO9_CONVERSAO,
                COM_VINCO10_CONVERSAO = Compensacao.COM_VINCO10_CONVERSAO,
                Changed = Compensacao.Changed,
                UserId = _executionContext.UserId,
                Id = Compensacao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_ID(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_ID = @COM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID(int id, string value)
        {
            this.Query = $@" UPDATE Compensacao SET GRP_ID = @GRP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_ID(int id, string value)
        {
            this.Query = $@" UPDATE Compensacao SET OND_ID = @OND_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OND_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO1_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO1_OND = @COM_VINCO1_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO1_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO2_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO2_OND = @COM_VINCO2_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO2_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO3_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO3_OND = @COM_VINCO3_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO3_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO4_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO4_OND = @COM_VINCO4_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO4_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO5_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO5_OND = @COM_VINCO5_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO5_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO6_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO6_OND = @COM_VINCO6_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO6_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO7_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO7_OND = @COM_VINCO7_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO7_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO8_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO8_OND = @COM_VINCO8_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO8_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO9_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO9_OND = @COM_VINCO9_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO9_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO10_OND(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO10_OND = @COM_VINCO10_OND WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO10_OND = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO1_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO1_CONVERSAO = @COM_VINCO1_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO1_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO2_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO2_CONVERSAO = @COM_VINCO2_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO2_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO3_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO3_CONVERSAO = @COM_VINCO3_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO3_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO4_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO4_CONVERSAO = @COM_VINCO4_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO4_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO5_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO5_CONVERSAO = @COM_VINCO5_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO5_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO6_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO6_CONVERSAO = @COM_VINCO6_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO6_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO7_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO7_CONVERSAO = @COM_VINCO7_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO7_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO8_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO8_CONVERSAO = @COM_VINCO8_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO8_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO9_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO9_CONVERSAO = @COM_VINCO9_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO9_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOM_VINCO10_CONVERSAO(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET COM_VINCO10_CONVERSAO = @COM_VINCO10_CONVERSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                COM_VINCO10_CONVERSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Compensacao SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Compensacao SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Compensacao SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCompensacaoQuery(ICompensacaoEntity Compensacao)
        {
            this.Query = $@" DELETE FROM Compensacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Compensacao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration