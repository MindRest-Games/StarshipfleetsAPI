﻿using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using Owin;

namespace StarshipfleetsAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            config.EnableCors(new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true });
            app.UseWebApi(config);
        }
    }
}