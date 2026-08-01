using System.Data;

namespace Shered.DB.Connection
{
    public interface ISqlFactory
    {
        IDbConnection SqlConnection();
    }
}
