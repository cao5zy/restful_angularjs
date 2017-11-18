
using System;
using System.Collections.Generic;
using Models;

namespace UserService
{
    public class InfrastructureService1 : IUserService
    {
		private IUserService _service = null;
		public InfrastructureService1(IUserService service)
        {
            this._service = service;
        }

		public void CreateUser(Models.User user){
			try{
				 this._service.CreateUser(user);
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}

		public System.Int32 DeleteUser(System.String id){
			try{
				return this._service.DeleteUser(id);
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}

		public List<Models.Role> GetRoles(){
			try{
				return this._service.GetRoles();
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}

		public Models.Rule GetRule(System.String id){
			try{
				return this._service.GetRule(id);
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}

		public List<Models.User> GetUsers(System.String id,System.String role){
			try{
				return this._service.GetUsers(id,role);
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}

		public Models.User UpdateUser(System.String id,Models.User user){
			try{
				return this._service.UpdateUser(id,user);
			}
			catch(Exception ex)
			{
				//Log ex
				throw;
			}
		}
	}
}


