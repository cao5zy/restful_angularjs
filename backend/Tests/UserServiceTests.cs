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
            new Action<Moq.Mock<IDb>, int>((mock, id) =>
            {
                mock.Setup(n => n.DeleteUserById(id)).Returns(1);

                Assert.AreEqual(1, UserService.DeleteUser(id, mock.Object));

            })(new Moq.Mock<IDb>(), 1);
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            new Action<Moq.Mock<IDb>, string, string>((mock, name, role) =>
            {
                mock.Setup(n => n.GetRoleId(role)).Returns(0);
                mock.Setup(n => n.GetUsers()).Returns(new List<User> { new User { Username = "abc" } });

                Assert.AreEqual(name, UserService.GetUsers(name, role, mock.Object).First().Username);

            })(new Moq.Mock<IDb>(), "abc", null);
        }

        [TestMethod()]
        public void GetUsersTest_EmptyList()
        {
            new Action<Moq.Mock<IDb>, string, string>((mock, name, role) =>
            {
                mock.Setup(n => n.GetRoleId(role)).Returns(0);
                mock.Setup(n => n.GetUsers()).Returns(new List<User> { new User { Username = "bc" } });

                Assert.AreEqual(0, UserService.GetUsers(name, role, mock.Object).Count);

            })(new Moq.Mock<IDb>(), "abc", null);
        }

        [TestMethod()]
        public void GetRoleIdTest()
        {
            new Action<Moq.Mock<IDb>, string, int>((mock, role, returnVal) =>
            {
                mock.Setup(n => n.GetRoleId(role)).Returns(returnVal);

                Assert.AreEqual(returnVal, UserService.GetRoleId(role, mock.Object));

            })(new Moq.Mock<IDb>(), "abc", 1);
        }

        [TestMethod()]
        public void GetRoleIdTest_Return_Zero()
        {
            new Action<Moq.Mock<IDb>, string, int>((mock, role, returnVal) =>
            {
                mock.Setup(n => n.GetRoleId(role)).Returns(returnVal);

                Assert.AreEqual(returnVal, UserService.GetRoleId(role, mock.Object));

            })(new Moq.Mock<IDb>(), null, 0);
        }

 

        [TestMethod()]
        public void UpdateUserTest()
        {
            new Action<Moq.Mock<IDb>, User>((mock, user) =>
            {
                mock.Setup(n => n.GetUsers()).Returns(new List<User> { new User { UserId = 1, Username = "alan", FirstName="ZonYing"} });
                mock.Setup(n => n.GetRoleId(null)).Returns(0);
                mock.Setup(n => n.DeleteUserById(user.UserId));
                mock.Setup(n => n.CreateUser(user));
                
                
                Assert.AreEqual(user.FirstName, UserService.UpdateUser(user, mock.Object).FirstName);

            })(new Moq.Mock<IDb>(), 
            new User { UserId = 1, Username = "alan", FirstName="Zongying"});
        }
    }
}