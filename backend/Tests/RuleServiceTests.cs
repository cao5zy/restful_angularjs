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

        [TestMethod()]
        public void CheckWithRuleTest_mobile_normal()
        {
            string reason = "";

            Assert.IsTrue(RuleService.CheckWithRule("3232322122", "mobile", out reason));
            Assert.AreEqual("", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_mobile_invalid()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("323-2322122", "mobile", out reason));
            Assert.AreEqual("mobile", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_mobile_empty()
        {
            string reason = "";

            Assert.IsFalse(RuleService.CheckWithRule("", "mobile", out reason));
            Assert.AreEqual("mobile", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_email_normal()
        {
            string reason = "";

            Assert.IsTrue(RuleService.CheckWithRule("czy@163.com", "email", out reason));
            Assert.AreEqual("", reason);
        }

        [TestMethod()]
        public void CheckWithRuleTest_email_empty()
        {
            string reason = "";

            Assert.IsTrue(RuleService.CheckWithRule("", "email", out reason));
            Assert.AreEqual("", reason);
        }
    }
}