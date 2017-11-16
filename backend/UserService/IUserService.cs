﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate="Roles")]
        List<Role> GetRoles();

        [OperationContract]
        [WebGet(UriTemplate ="User/{id}/{role}")]
        List<User> GetUsers(string id, string role);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "User")]
        void CreateUser(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "User/{id}")]
        User UpdateUser(string id, User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "User/{id}")]
        int DeleteUser(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Rule/{id}")]
        Rule GetRule(string id);
        // TODO: Add your service operations here
    }
}
