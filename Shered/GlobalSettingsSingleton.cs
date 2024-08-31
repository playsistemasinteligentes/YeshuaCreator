using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioDeTestes.config
{
   public class GlobalSettingsSingleton
    {
        private static readonly Lazy<GlobalSettingsSingleton> _instance =
            new Lazy<GlobalSettingsSingleton>(() => new GlobalSettingsSingleton());
        public object _instanceLock = new object();

        private string _connectionStringWrite { get; set;}
        private string _connectionStringRead { get; set;}
        public HttpClient Client = new HttpClient();
        public int Contador { get; private set; }

        private GlobalSettingsSingleton()
        {
        }

        public string GetConnectionStringWrite()
        {
            if (!_connectionStringWrite.IsNullOrEmpty())
                return _connectionStringWrite;
            else
                throw new FileNotFoundException("String de conexão write não informado");
        }
        public string GetConnectionStringRead()
        {
            if (!_connectionStringRead.IsNullOrEmpty())
                return _connectionStringRead;
            else
                throw new FileNotFoundException("String de conexão read não informado");
        }
        public GlobalSettingsSingleton SetStringConetionWrite(string stringConetionWrite)
        {
            _connectionStringWrite = stringConetionWrite;
            return this;
        }
        public GlobalSettingsSingleton SetStringConetionRead(string stringConetionRead)
        {
            _connectionStringRead = stringConetionRead;
            return this;
        }

        public static GlobalSettingsSingleton Instance {get {return _instance.Value;} }

    }
}
