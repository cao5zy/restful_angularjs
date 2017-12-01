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

        public static int DeleteUser(User user, IDb db)
        {
            return db.DeleteUser(user);
        }

        public static List<User> GetUsers(int userId, string name, string role, IDb db)
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

            var filterUserId = new Func<IEnumerable<User>, IEnumerable<User>>((users) => {
                return userId != 0 ? from user in users
                                     where user.UserId == userId
                                     select user : users;
            });

            return userId != 0 ? filterUserId(db.GetUsers()).ToList()
                : filterName(filterRole(db.GetUsers(), GetRoleId(role, db)))
                .ToList()
                .ConvertAll(n=>new User { UserId = n.UserId,
                    RoleId = n.RoleId,
                    Role = new Role { RoleId = n.Role.RoleId, Name = n.Role.Name },
                    Username = n.Username,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    Email = n.Email,
                    Mobile = n.Mobile,
                    DateOfBirth = n.DateOfBirth
                });
        }

        public static User GetUserById(int userId, IDb db)
        {
            return GetUsers(userId, null, null, db).FirstOrDefault();
        }

        public static int GetRoleId(string role, IDb db)
        {
            return string.IsNullOrEmpty(role) ? 0 : db.GetRoleId(role);
        }

        public static User UpdateUser(User user, IDb db)
        {
            var update = new Func<User, User>((oldUser) => {
                db.DeleteUser(oldUser);
                db.CreateUser(user);
                return user;
            });

            return new Func<User, User>((oldUser) =>
            {
                if (oldUser != null)
                    return update(oldUser);
                else
                    throw new ArgumentException("update user not found");
            })(GetUserById(user.UserId, db));
            
            
        }
    }
}
