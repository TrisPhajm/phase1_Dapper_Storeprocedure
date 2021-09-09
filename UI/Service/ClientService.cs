using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UI.Service
{
    public class ClientService : IClientService
    {
        private readonly IHttpClientFactory _client_Factory;

        public ClientService(IHttpClientFactory clientFactory)
        {
            _client_Factory = clientFactory;
        }
        public async Task<bool> Delete(string url)
        {
            var client = _client_Factory.CreateClient("api_server");
            var student = await client.GetAsync(url);
            if (student == null)
            {
                return false;
            }
            var response = await client.DeleteAsync(url);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string url)
        {
            var client = _client_Factory.CreateClient("api_server");
            var response = await client.GetAsync(url);
            string body = await response.Content.ReadAsStringAsync();
            var student_list = JsonConvert.DeserializeObject<List<T>>(body);
            return student_list;
        }

        public async Task<T> GetById<T>(string url)
        {
            var client = _client_Factory.CreateClient("api_server");
            var response = await client.GetAsync(url);
            string body = await response.Content.ReadAsStringAsync();
            var student_list = JsonConvert.DeserializeObject<T>(body);
            return student_list;
        }

        public async Task<IEnumerable<T>> GetDataListById<T>(string url)
        {
            var client = _client_Factory.CreateClient("api_server");
            var response = await client.GetAsync(url);
            string body = await response.Content.ReadAsStringAsync();
            if (body != "No Result")
            {
                var student_list = JsonConvert.DeserializeObject<List<T>>(body);
                return student_list;
            }
            return null;
        }

        public async Task<bool> Post<T>(string url, T content)
        {
            var client = _client_Factory.CreateClient("api_server");
            StringContent httpContent = null;
            if (content != null)
            {
                httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }
            var response = await client.PostAsync(url, httpContent);
            var return_res = response.Content.ReadAsStringAsync();
            return return_res != null? true : false;
        }

        public async Task<bool> Put<T>(string url, T content)
        {
            var client = _client_Factory.CreateClient("api_server");
            var student = await client.GetAsync(url);
            if (student == null)
            {
                return false;
            }
            StringContent httpContent = null;
            if (content != null)
            {
                httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }
            var response = await client.PutAsync(url, httpContent);
            var return_res = response.Content.ReadAsStringAsync();
            return return_res != null ? true : false;
        }
    }
}
