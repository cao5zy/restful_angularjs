using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Db.Service
{
    public class DbService : IDb
    {
        private user_dbEntities _dbContext = new user_dbEntities();
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public int DeleteUserById(string id)
        {
            throw new NotImplementedException();
        }

        public int GetRoleId(string role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return from user in this._dbContext.User select user;
        }
    }
}
