
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
				this._log.Debug("CreateUser");
				this._log.Debug(user);
				 this._service.CreateUser(user);
			}
			catch(Exception ex)
			{
				this._log.Error("CreateUser");
				this._log.Error(ex);
				throw;
			}
		}

		public System.Int32 DeleteUser(System.Int32 userId){
			try{
				this._log.Debug("DeleteUser");
				this._log.Debug(userId);
				return this._service.DeleteUser(userId);
			}
			catch(Exception ex)
			{
				this._log.Error("DeleteUser");
				this._log.Error(ex);
				throw;
			}
		}

		public List<Models.Role> GetRoles(){
			try{
				this._log.Debug("GetRoles");
				return this._service.GetRoles();
			}
			catch(Exception ex)
			{
				this._log.Error("GetRoles");
				this._log.Error(ex);
				throw;
			}
		}

		public Models.Rule GetRule(System.String id){
			try{
				this._log.Debug("GetRule");
				this._log.Debug(id);
				return this._service.GetRule(id);
			}
			catch(Exception ex)
			{
				this._log.Error("GetRule");
				this._log.Error(ex);
				throw;
			}
		}

		public List<Models.User> GetUsers(System.String name,System.String role){
			try{
				this._log.Debug("GetUsers");
				this._log.Debug(name);
				this._log.Debug(role);
				return this._service.GetUsers(name,role);
			}
			catch(Exception ex)
			{
				this._log.Error("GetUsers");
				this._log.Error(ex);
				throw;
			}
		}

		public Models.User UpdateUser(Models.User user){
			try{
				this._log.Debug("UpdateUser");
				this._log.Debug(user);
				return this._service.UpdateUser(user);
			}
			catch(Exception ex)
			{
				this._log.Error("UpdateUser");
				this._log.Error(ex);
				throw;
			}
		}
	}
}


