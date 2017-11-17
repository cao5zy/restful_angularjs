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
            AutofacHostFactory.Container = new Func<ContainerBuilder, IContainer>((builder) =>
            {
                builder.RegisterType<global::UserService.UserService>();
                return builder.Build();
            })(new ContainerBuilder());
        }

    }
}