using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Wcf;
using Db.Service;

namespace UserService
{
    public class Global : System.Web.HttpApplication
    {
        public void Application_Error(object sender, EventArgs e)
        {
            AutofacServiceHostFactory.Container.Resolve<log4net.ILog>().Error(new { sender = sender, arg = e });
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            AutofacServiceHostFactory.Container = new Func<string, ContainerBuilder, IContainer>((namedService, builder) =>
            {
                builder.RegisterType<UserService>()
                    .Named<IUserService>(namedService);

                builder.RegisterType<DbService>().As<IDb>();

                builder.RegisterInstance<log4net.ILog>(log4net.LogManager.GetLogger(typeof(Global)))
                    .As<log4net.ILog>();

                builder.Register(container => new InfrastructureService(container.ResolveNamed<IUserService>(namedService)
                    , container.Resolve<log4net.ILog>()));

                log4net.Config.XmlConfigurator.Configure();

                return builder.Build();
            })("userService", new ContainerBuilder());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var getDomainName = new Func<string>(() =>
            {
                return new Func<string, string>(setting =>
                {
                    return setting != null ? setting.ToLower() : "";
                })(HttpContext.Current.Request.Headers["Origin"]);
            });

            var getConfigedDomains = new Func<List<string>>(() =>
            {
                return new Func<string, List<string>>((setting) =>
                {
                    return (setting != null ? setting.Split(',').ToList() : new List<string>())
                    .ConvertAll(n => n.ToLower());
                })
                (ConfigurationManager.AppSettings["allowedDomains"]);

            });

            var isDomainAllowed = new Func<bool>(() =>
            {
                return string.IsNullOrEmpty(getDomainName()) ? false :
                getConfigedDomains().Contains(getDomainName());
            });

            var handleResponse = new Action<string, string, string, string, HttpRequest, HttpResponse>((allowedmethods, domain, maxAge, contentType, request, response) =>
            {
                response.AddHeader("Access-Control-Allow-Origin", domain);

                if (request.HttpMethod == "OPTIONS")
                {
                    //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                    response.AddHeader("Access-Control-Allow-Methods", allowedmethods);
                    response.AddHeader("Access-Control-Allow-Headers", request.Headers["Access-Control-Request-Headers"] == null? "": request.Headers["Access-Control-Request-Headers"].ToString());
                    response.AddHeader("Access-Control-Max-Age", maxAge);
                    response.AddHeader("ContentType", contentType);
                    response.End();
                }

            });

            if (isDomainAllowed())
                handleResponse("POST, PUT, DELETE, GET", getDomainName(), "1728000", "application/json", HttpContext.Current.Request, HttpContext.Current.Response);
        }

    }
}