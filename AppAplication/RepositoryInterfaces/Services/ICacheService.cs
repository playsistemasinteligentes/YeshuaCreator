using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Services
{
    public interface ICacheService<T>
    {
        T Get(string key);
        void Set(string key, T value, TimeSpan? expiration = null);
        void Remove(string key);
    }

}
