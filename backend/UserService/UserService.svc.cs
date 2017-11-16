using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;
using Models.Service;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IUserService
    {
        public void CreateUser(User user)
        {
            Models.Service.UserService.CreateUser(
                RuleService.ValidateUser(user));
        }

        public int DeleteUser(string id)
        {
            return Models.Service.UserService.DeleteUser(
                RuleService.ValidateUser(id));
        }

        public List<Role> GetRoles()
        {
            return RoleService.GetRoles();
        }

        public Rule GetRule(string id)
        {
            return RuleService.GetRule(id);
        }

        public List<User> GetUsers(string id, string role)
        {
            return Models.Service.UserService.GetUsers(id, role);
        }

        public User UpdateUser(string id, User user)
        {
            return Models.Service.UserService.UpdateUser(id, RuleService.ValidateUser(user));
        }
    }
}
