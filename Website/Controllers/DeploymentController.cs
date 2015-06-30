using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace VirtoCommerce.Controllers
{
    [RoutePrefix("api/deploy")]
    public class DeploymentController : ApiController
    {
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Deploy(string token)
        {
            await DeployGit();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public async Task DeployGit()
        {
            using (var client = new HttpClient())
            {
                var authToken = ConfigurationManager.AppSettings["DeployAuthenticationToken"];
                var scmUrl = "https://virtocommerce-public.scm.azurewebsites.net/deploy";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
                var deployResponse = await client.PostAsJsonAsync(scmUrl, new { format = "basic", url = "https://github.com/VirtoCommerce/virtocommerce.com.git" });//.GetAsync(scmUrl);//.PutAsJsonAsync(scmUrl, new StringContent("{}", Encoding.UTF8, "application/json"));
                //var output = await deployResponse.Content.ReadAsStringAsync();
            }
        }
    }
}