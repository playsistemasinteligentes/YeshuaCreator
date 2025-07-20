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
    public class YStandardFieldsQueryWrite : QueryBase, IYStandardFieldsQueryWrite
    {
        protected readonly ICurrentUser _correntUser;
        public YStandardFieldsQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields)
        {
            this.Query = $@" INSERT INTO YStandardFields (Deleted) OUTPUT INSERTED.ID VALUES(@Deleted) ";
            this.Parameters = new
            {
                Deleted = YStandardFields.Deleted,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields)
        {
            this.Query = $@" UPDATE YStandardFields SET  WHERE Deleted = @Deleted ";
            this.Parameters = new
            {
                Deleted = YStandardFields.Deleted,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields)
        {
            this.Query = $@" DELETE FROM YStandardFields WHERE Deleted = @Deleted ";
            this.Parameters = new
            {
                Deleted = YStandardFields.Deleted,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration