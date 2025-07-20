using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IYStandardFieldsQueryWrite 
     {
        public QueryModel InserirYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields);
        public QueryModel UpdateYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields);
        public QueryModel DeleteYStandardFieldsQuery(IYStandardFieldsEntity YStandardFields);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration