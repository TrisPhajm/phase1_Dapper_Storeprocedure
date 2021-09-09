using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Service
{
    public interface IClientService
    {
        Task<IEnumerable<T>> GetAll<T>(string url);
        Task<T> GetById<T>(string url);//id in url
        Task<IEnumerable<T>> GetDataListById<T>(string url);
        Task<bool> Post<T>(string url, T content);
        Task<bool> Put<T>(string url, T content);
        Task<bool> Delete(string url);
    }
}
