using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Db.Service
{
    public interface IDb
    {
        void CreateUser(User user);

        IEnumerable<User> GetUsers();
        int GetRoleId(string role);

        int DeleteUser(User user);

        IEnumerable<Role> GetRoles();
    }
}
