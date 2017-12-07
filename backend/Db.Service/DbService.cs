using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace Db.Service
{
    public class DbService : IDb
    {
        private user_dbEntities _dbContext = new user_dbEntities();
        public void CreateUser(User user)
        {
            this._dbContext.User.Add(user);
            this._dbContext.SaveChanges();
        }

        public int DeleteUser(User user)
        {
            return new Func<int, int>(result =>
            {
                this._dbContext.SaveChanges();
                return result;
            })(this._dbContext.User.Remove(user) != null ? 1 : 0);

        }

        public int GetRoleId(string roleName)
        {
            return (from role in this._dbContext.Role
                    where role.Name == roleName
                    select role.RoleId).FirstOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            return from role in this._dbContext.Role
                   select role;
        }

        public IEnumerable<User> GetUsers()
        {
            return from user in this._dbContext.User select user;
        }

        public int NewUserId()
        {
            using (var conn = new SqlConnection(this._dbContext.Database.Connection.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT NEXT VALUE FOR IDS.UserId";
                    cmd.CommandType = System.Data.CommandType.Text;
                    return new Func<object, int>(result => Convert.IsDBNull(result) ? 0 : Convert.ToInt32(result))
                        (cmd.ExecuteScalar());
                }
            }
        }
    }
}
