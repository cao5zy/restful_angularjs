
using System;
using System.Collections.Generic;
using Models;
using System.ServiceModel.Web;

namespace UserService
{
    public class InfrastructureService : IUserService
    {
		private IUserService _service = null;
        private log4net.ILog _log = null;

		public InfrastructureService(IUserService service, log4net.ILog logger)
        {
            this._service = service;
			this._log = logger;
        }

		public System.Boolean IsUniqueUser(System.String userName){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {userName=userName, _name="IsUniqueUser"});
				return this._service.IsUniqueUser(userName);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "IsUniqueUser", ex = ex});
				return false;
			}
		}

		public System.String CreateUser(Models.User user){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {user=user, _name="CreateUser"});
				return this._service.CreateUser(user);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "CreateUser", ex = ex});
				return "";
			}
		}

		public System.Int32 DeleteUser(System.String userId){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {userId=userId, _name="DeleteUser"});
				return this._service.DeleteUser(userId);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "DeleteUser", ex = ex});
				return 0;
			}
		}

		public List<Models.Role> GetRoles(){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {_name="GetRoles"});
				return this._service.GetRoles();
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "GetRoles", ex = ex});
				return null;
			}
		}

		public List<Models.Rule> GetRules(System.String category){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {category=category, _name="GetRules"});
				return this._service.GetRules(category);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "GetRules", ex = ex});
				return null;
			}
		}

		public List<Models.User> GetUsers(System.String name,System.String role){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {name=name, role=role, _name="GetUsers"});
				return this._service.GetUsers(name,role);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "GetUsers", ex = ex});
				return null;
			}
		}

		public Models.User UpdateUser(Models.User user){
			var ctx = WebOperationContext.Current;
			ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
			try{
				this._log.Debug(new {user=user, _name="UpdateUser"});
				return this._service.UpdateUser(user);
			}
			catch(Exception ex)
			{
				ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;  
				ctx.OutgoingResponse.StatusDescription = ex.Message;  
				this._log.Error(new { name = "UpdateUser", ex = ex});
				return null;
			}
		}
	}
}


