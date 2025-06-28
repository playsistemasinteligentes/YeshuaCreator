using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Services
{
    public interface ICacheKeyIndexManager
    {
        void AddKey(string prefix, string key);
        void RemoveKey(string prefix, string key);
        IEnumerable<string> GetKeys(string prefix);
        void RemoveAll(string prefix);
    }

}
