using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Wcf;

namespace UserService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AutofacHostFactory.Container = new Func<string, ContainerBuilder, IContainer>((namedService, builder) =>
            {
                builder.RegisterType<UserService>()
                    .Named<IUserService>(namedService);

                builder.RegisterInstance<log4net.ILog>(log4net.LogManager.GetLogger(typeof(Global)))
                    .As<log4net.ILog>();

                builder.Register(container => new InfrastructureService(container.ResolveNamed<IUserService>(namedService)
                    , container.Resolve<log4net.ILog>()));

                return builder.Build();
            })("userService", new ContainerBuilder());
        }

    }
}