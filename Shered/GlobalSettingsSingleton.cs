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
        
        public string ConnectionString { get; private set; }
        public HttpClient Client = new HttpClient();
        public int Contador { get; private set; }

        private GlobalSettingsSingleton()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "cnx.txt");
            Client = new HttpClient();
            ConnectionString = GetConnectionString(filePath);
        }

        public void contar()
        {
            lock (_instance.Value._instanceLock)
            {
                _instance.Value.Contador++;
            }
        }
        private string GetConnectionString(string path)
        {
            // Verifica se o arquivo existe
            if (File.Exists(path))
            {
                // Lê o conteúdo do arquivo e retorna
                return File.ReadAllText(path).Trim();
            }
            else
            {
                throw new FileNotFoundException("O arquivo de configuração não foi encontrado.", path);
            }
        }

        public int GetQTD()
        {
            return _instance.Value.Contador;
        }

        public static GlobalSettingsSingleton Instance {get {return _instance.Value;} }

    }
}
