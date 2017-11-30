
using System;
using System.Collections.Generic;
using Models;

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

		public void CreateUser(Models.User user){
			try{
				this._log.Debug(new {user=user, _name="CreateUser"});
				 this._service.CreateUser(user);
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "CreateUser", ex = ex});
				
			}
		}

		public System.Int32 DeleteUser(string userId){
			try{
				this._log.Debug(new {userId=userId, _name="DeleteUser"});
				return this._service.DeleteUser(userId);
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "DeleteUser", ex = ex});
				return 0;
			}
		}

		public List<Models.Role> GetRoles(){
			try{
				this._log.Debug(new {_name="GetRoles"});
				return this._service.GetRoles();
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "GetRoles", ex = ex});
				return null;
			}
		}

		public List<Models.Rule> GetRules(System.String category){
			try{
				this._log.Debug(new {category=category, _name="GetRules"});
				return this._service.GetRules(category);
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "GetRules", ex = ex});
				return null;
			}
		}

		public List<Models.User> GetUsers(System.String name,System.String role){
			try{
				this._log.Debug(new {name=name, role=role, _name="GetUsers"});
				return this._service.GetUsers(name,role);
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "GetUsers", ex = ex});
				return null;
			}
		}

		public Models.User UpdateUser(Models.User user){
			try{
				this._log.Debug(new {user=user, _name="UpdateUser"});
				return this._service.UpdateUser(user);
			}
			catch(Exception ex)
			{
				this._log.Error(new { name = "UpdateUser", ex = ex});
				return null;
			}
		}
	}
}


