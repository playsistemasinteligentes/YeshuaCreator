using System;

namespace RepositoryInterfaces.Services
{
    public interface ICacheService<T>
    {
        /// <summary>
        /// Recupera um valor do cache pela chave completa.
        /// </summary>
        T Get(string key);

        /// <summary>
        /// Armazena um valor no cache com uma chave e um prefixo explícito.
        /// O prefixo é usado para permitir remoção em massa por categoria.
        /// </summary>
        void Set(string key, T value, string prefix, TimeSpan? expiration = null);

        /// <summary>
        /// Remove uma entrada do cache com base na chave e prefixo.
        /// </summary>
        void Remove(string key, string prefix);

        /// <summary>
        /// Remove todas as entradas do cache associadas a um prefixo.
        /// </summary>
        void RemoveByPrefix(string prefix);
    }
}
