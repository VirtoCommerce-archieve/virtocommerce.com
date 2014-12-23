using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.App_Start
{
    using System.Web.Http;

    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();
        }

    }
}