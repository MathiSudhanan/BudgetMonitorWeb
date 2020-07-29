using BudgetMonitor.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AccountRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<AuthenticationTokenModel> LoginAsync(string url, AuthenticationModel authenticationModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (authenticationModel != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(authenticationModel), Encoding.UTF8, "application/json");
            else
                return null;

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthenticationTokenModel>(jsonString);
            }
            return new AuthenticationTokenModel();
        }

        public async Task<bool> RegisterAsync(string url, User user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (user != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            else
                return false;

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;
        }
    }
}
