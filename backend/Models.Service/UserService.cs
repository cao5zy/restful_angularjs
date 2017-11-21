using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Service;

namespace Models.Service
{
    public static class UserService
    {
        public static void CreateUser(User user, IDb db)
        {
            db.CreateUser(user);
        }

        public static int DeleteUser(string id, IDb db)
        {
            return db.DeleteUserById(id);
        }

        public static List<User> GetUsers(string name, string role, IDb db)
        {
            var filterName = new Func<IEnumerable<User>, IEnumerable<User>>((users) => {
                return !string.IsNullOrEmpty(name) ? from user in users
                                                    where user.Username.Contains(name)
                                                    select user : users;
            });

            var filterRole = new Func<IEnumerable<User>, int, IEnumerable<User>>((users, roleId) => {
                return roleId != 0 ? from user in users
                                     where user.RoleId == roleId
                                     select user : users;
            });

            return filterName(filterRole(db.GetUsers(), GetRoleId(role, db))).ToList();
        }

        private static int GetRoleId(string role, IDb db)
        {
            return string.IsNullOrEmpty(role) ? 0 : db.GetRoleId(role);
        }

        public static User UpdateUser(string id, User user, IDb _db)
        {
            throw new NotImplementedException();
        }
    }
}
