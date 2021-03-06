﻿using System;
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
            db.CreateUser(new User {
                UserId = db.NewUserId(),
                Username = user.Username,
                RoleId = user.RoleId,
                Mobile = user.Mobile,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            });
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

        public static User CheckUniqueUser(User user, IDb db)
        {
            if (IsUniqueUser(user.Username, db)
                || (user.UserId != 0 && GetUserById(user.UserId, db).Username == user.Username))
                return user;
            else
                throw new Exceptions.UserUniqueException(user.Username);
        }

        public static bool IsUniqueUser(string userName, IDb db)
        {
            var users = GetUsers(0, userName, null, db);
            return string.IsNullOrEmpty(userName) ? false:
                users.Count == 0 || !users.Exists(n=>n.Username.ToLower() == userName.ToLower());
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
                db.CreateUser(new User {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.UserId,
                    RoleId = user.RoleId,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    DateOfBirth = user.DateOfBirth,
                    Username = user.Username
                });
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
