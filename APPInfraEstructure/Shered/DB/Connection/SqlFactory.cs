using DominioDeTestes.config;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Shered.DB.Connection
{
    public class SqlFactory 
    {
        private readonly EnumSqlConections _typeConnection;
        private readonly string _stringConection;

        public SqlFactory(EnumSqlConections typeConnection, string stringConection)
        {
            _typeConnection = typeConnection;
            _stringConection = stringConection;
        }

        public IDbConnection SqlConnection()
        {
            if (_typeConnection == EnumSqlConections.SqlServer)
            {
                return new SqlConnection(_stringConection);
            }
            return null;
        }
    }
}
