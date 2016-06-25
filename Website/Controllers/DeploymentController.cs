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
                // auth token stopped working in June 2016, maybe due to updates
                /*
                var authToken = ConfigurationManager.AppSettings["DeployAuthenticationToken"];
                var scmUrl = "https://virtocommerce-public.scm.azurewebsites.net/deploy";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
                var deployResponse = await client.PostAsJsonAsync(scmUrl, new { format = "basic", url = "https://github.com/VirtoCommerce/virtocommerce.com.git" });
                */
                
                var authToken = ConfigurationManager.AppSettings["DeployAuthenticationToken"];
                var triggerUrl = ConfigurationManager.AppSettings["DeploymentTriggerUrl"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
                var deployResponse = await client.PostAsJsonAsync(triggerUrl, new { format = "basic", url = "https://github.com/VirtoCommerce/virtocommerce.com.git" });
            }
        }
    }
}
