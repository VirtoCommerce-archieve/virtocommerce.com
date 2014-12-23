using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VirtoCommerce.Controllers
{
    using System.IO;

    [RoutePrefix("api/deploy")]
    public class DeploymentController : ApiController
    {
        [Route("")]
        [HttpGet]
        public void Deploy()
        {
            DeployGit();
        }

        public static bool DeployGit()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://$virtocommerce-public:EajNtHWHlfrdHB3d5Ns6p6S0ZJJqk60yhggYf1hn2oasFph9Pzk7846pGGSN@virtocommerce-public.scm.azurewebsites.net/deploy");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = "{ \"format\": \"basic\", " + "  \"url\": \"https://github.com/VirtoCommerce/virtocommerce.com.git\" + \"}";

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                //Now you have your response.
                //or false depending on information in the response
                return true;
            }
        }
    }
}