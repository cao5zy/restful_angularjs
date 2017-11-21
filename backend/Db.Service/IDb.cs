﻿using System;
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

        int DeleteUserById(string id);

        IEnumerable<User> GetUsers();
        int GetRoleId(string role);
    }
}