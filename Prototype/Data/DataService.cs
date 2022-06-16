using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace Prototype
{
    public class DataService
    {
        // Readonly better protection, field can not be accidently changed

        private readonly HttpClient Client;
        private readonly Dictionary<string, string> ModalEndpoints;
        private readonly string BaseUrlAddress;

        public DataService(string baseAddress)
        {
            var insecureHandler = DependencyService.Get<IHttpClientHandlerService>().GetHandler();
            Client = new HttpClient(insecureHandler);

            BaseUrlAddress = baseAddress;

            ModalEndpoints = new Dictionary<string, string>();
        }

        /// <summary>
        /// // get class type name
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public DataService AddEntityModelEndpoint<TEntity>(string endpoint)
        {
            
            ModalEndpoints.Add(typeof(TEntity).FullName, endpoint);
            return this;
        }

        /// <summary>
        /// // private helper method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        private string GetEntityEndpoint<TEntity>() => ModalEndpoints[typeof(TEntity).FullName];

        /// <summary>
        /// // GET request 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
        where TEntity : new()
        {
            var endpoint = GetEntityEndpoint<TEntity>();
            var url = $"{BaseUrlAddress}/{endpoint}?searchExpression={filter}";
            var uri = new Uri(string.Format(url));
            
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                var deserialisedContent = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(content);
                
                return deserialisedContent.ToList<TEntity>();
            }
            return default;

        }

        /// <summary>
        /// // GET request
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync<TEntity, T>(T id)
            where TEntity : new()
        {
            var endpoint = GetEntityEndpoint<TEntity>();
            var uri = new Uri($"{BaseUrlAddress}/{endpoint}/{id}");
            
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                var deserialisedContent = JsonConvert.DeserializeObject<TEntity>(content);
                
                return deserialisedContent;
            }
            return default;
        }

        /// <summary>
        /// // PUT request
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<TEntity, T>(TEntity entity, T id)
        {
            var endpoint = GetEntityEndpoint<TEntity>();
                var url = $"{BaseUrlAddress}/{endpoint}/{id}";
                var uri = new Uri(url);
            
            var jsonEntity = JsonConvert.SerializeObject(entity); 
            var content = new StringContent(jsonEntity, Encoding.UTF8, "application/json");
            
            var response = await Client.PutAsync(uri, content);
            
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// // DELETE request
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<TEntity, T>(TEntity entity, T id)
        {
            var endpoint = GetEntityEndpoint<TEntity>();
                var url = $"{BaseUrlAddress}/{endpoint}/{id}";
                var uri = new Uri(url);
            
            var response = await Client.DeleteAsync(uri);
            
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// // POST request
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> InsertAsync<TEntity>(TEntity entity)
        {
            var endpoint = GetEntityEndpoint<TEntity>();
                var url = $"{BaseUrlAddress}/{endpoint}";
                var uri = new Uri(url);
            
            var jsonEntity = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(jsonEntity, Encoding.UTF8, "application/json");
            
            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                
                var deserialisedContent = JsonConvert.DeserializeObject<TEntity>(responseContent);
               
                return deserialisedContent;
            }
            return default;
        }
        
    }
}