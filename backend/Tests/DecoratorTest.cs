using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Diagnostics;
using Autofac;

namespace Tests
{
    interface ICommand
    {
        void Do();
    }

    class BusinessCommand : ICommand
    {
        public void Do()
        {
            Debug.Print("Do it in business");
        }
    }

    class DecoratorCommand : ICommand
    {
        private ICommand _cmd;

        public DecoratorCommand(ICommand cmd)
        {
            this._cmd = cmd;    
        }
        public void Do()
        {
            this._cmd.Do();
            Debug.Print("do other things here");
        }
    }
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class DecoratorTest
    {
        [TestMethod]
        public void Decorate_Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BusinessCommand>()
                .Named<ICommand>("business");

            builder.Register(c => new DecoratorCommand(c.ResolveNamed<ICommand>("business")))
                .As<DecoratorCommand>()
                .As<ICommand>();

            using(var container = builder.Build())
            {
                container.Resolve<ICommand>().Do();
                container.Resolve<DecoratorCommand>().Do();

            }

        }
    }
}
