using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IUserService
    {
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Rule GetRule(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(string id, string role)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(string id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
