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

        public static int DeleteUser(int userId, IDb db)
        {
            return db.DeleteUserById(userId);
        }

        public static List<User> GetUsers(string name, string role, IDb db)
        {
            var filterName = new Func<IEnumerable<User>, IEnumerable<User>>((users) =>
            {
                return !string.IsNullOrEmpty(name) ? from user in users
                                                     where user.Username.Contains(name)
                                                     select user : users;
            });

            var filterRole = new Func<IEnumerable<User>, int, IEnumerable<User>>((users, roleId) =>
            {
                return roleId != 0 ? from user in users
                                     where user.RoleId == roleId
                                     select user : users;
            });

            return filterName(filterRole(db.GetUsers(), GetRoleId(role, db))).ToList();
        }

        public static int GetRoleId(string role, IDb db)
        {
            return string.IsNullOrEmpty(role) ? 0 : db.GetRoleId(role);
        }

        public static User UpdateUser(User user, IDb db)
        {
            var getOldUser = new Func<User>(() =>
            {
                return (from u in GetUsers(user.Username, null, db)
                        where u.UserId == user.UserId
                        select u).FirstOrDefault();
            });

            var update = new Func<User>(() => {
                db.DeleteUserById(user.UserId);
                db.CreateUser(user);
                return user;
            });

            return new Func<User, User>((oldUser) =>
            {
                if (oldUser != null)
                    return update();
                else
                    throw new ArgumentException("update user not found");
            })(getOldUser());
            
            
        }
    }
}
