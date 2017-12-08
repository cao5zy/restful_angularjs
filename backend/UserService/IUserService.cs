using System;
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
        [WebGet(UriTemplate = "Role", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Role> GetRoles();

        [OperationContract]
        [WebGet(UriTemplate = "User/{id=_default}/{role=_default}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<User> GetUsers(string id, string role);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "User", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void CreateUser(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "User", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        User UpdateUser(User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "User/{userId}")]
        int DeleteUser(string userId);

        [OperationContract]
        [WebGet(UriTemplate = "Rule/{category}")]
        List<Rule> GetRules(string category);
        // TODO: Add your service operations here
    }
}
