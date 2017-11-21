using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Service;

namespace Models.Service.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            new Action<Moq.Mock<IDb>, User>((mock, user) =>
            {
                mock.Setup(n => n.CreateUser(user));

                UserService.CreateUser(user, mock.Object);

            })(new Moq.Mock<IDb>(), new User { });
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            new Action<Moq.Mock<IDb>, string>((mock, id) =>
            {
                mock.Setup(n => n.DeleteUserById(id)).Returns(1);

                Assert.AreEqual(1, UserService.DeleteUser(id, mock.Object));

            })(new Moq.Mock<IDb>(), "abc");
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            new Action<Moq.Mock<IDb>, string, string>((mock, name, role) =>
            {
                mock.Setup(n => n.GetRoleId(role)).Returns(0);
                mock.Setup(n => n.GetUsers()).Returns(new List<User> { new User { Username="abc"} });

                Assert.AreEqual("abc", UserService.GetUsers(name, role, mock.Object).First().Username);

            })(new Moq.Mock<IDb>(), "abc", null);
        }
    }
}