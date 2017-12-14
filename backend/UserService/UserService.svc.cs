using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Db.Service;
using Models;
using Models.Service;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private IDb _db = null;
        public UserService(IDb db)
        {
            this._db = db;
        }

        public bool IsUniqueUser(string userName)
        {
            return Models.Service.UserService.IsUniqueUser(userName, this._db);
        }

        public string CreateUser(User user)
        {
            try
            {
                Models.Service.UserService.CreateUser(
                    Models.Service.UserService.CheckUniqueUser(
                        RuleService.ValidateUser(user), this._db), this._db);
                return "";
            }
            catch (Models.Service.Exceptions.UserUniqueException ex)
            {
                return ex.Message;
            }

        }

        public int DeleteUser(string userId)
        {
            return Models.Service.UserService.DeleteUser(
                RuleService.ValidateUser(
                    Models.Service.UserService.GetUserById(int.Parse(userId), this._db))
                    , this._db);
        }

        public List<Role> GetRoles()
        {
            return RoleService.GetRoles(this._db);
        }

        public List<Rule> GetRules(string category)
        {
            return RuleService.GetRules(category);
        }

        public List<User> GetUsers(string name, string role)
        {
            return Models.Service.UserService.GetUsers(0, name == "_default" ? "" : name, role == "_default" ? "" : role, this._db);
        }

        public string UpdateUser(User user)
        {
            try
            {
                Models.Service.UserService.UpdateUser(Models.Service.UserService.CheckUniqueUser(RuleService.ValidateUser(user), this._db), this._db);
                return "";
            }
            catch (Models.Service.Exceptions.UserUniqueException ex)
            {
                return ex.Message;
            }
        }

    }
}
