using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace UserService
{
    public class InfrastructureService : IUserService
    {
        private IUserService _service = null;
        public InfrastructureService(IUserService service)
        {
            
            this._service = service;
        }
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