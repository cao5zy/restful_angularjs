using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Service.Tests
{
    [TestClass()]
    public class RuleServiceTests
    {
        [TestMethod()]
        public void CheckWithRuleTest_username_empty()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("", "username", out reason));
            Assert.AreEqual("username", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_username_special()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("admin", "username", out reason));
            Assert.AreEqual("username", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_username_outofreange()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("alancao3210", "username", out reason));
            Assert.AreEqual("username", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_username_invalidchar()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("alanc_210", "username", out reason));
            Assert.AreEqual("username", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_username_normal()
        {
            string reason = "";

            Assert.IsTrue(RuleService.CheckWithRule("alanc210", "username", out reason));
            Assert.AreEqual("", reason);
        }
    }
}