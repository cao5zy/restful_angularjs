import { TemplateRef, EventEmitter, ViewChild, Output, Component, OnInit, Input, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import * as _ from 'lodash';
import useService from './../services/useService';
import { Service } from './../services';
import { CommonDescriptor } from './../models';


@Component({
  selector: 'app-user-info-panel',
  templateUrl: './user-info-panel.component.html',
  styleUrls: ['./user-info-panel.component.css']
})
export class UserInfoPanelComponent implements OnInit {

  editUser:any = null;
  callUserService: any = null;
  callRoleService: any = null;
  roleList:Array<any> = null;
  private originalUser: any = null;

  constructor(private _service: Service) { 
      this.callUserService = useService(new CommonDescriptor("User"), this._service);
      this.callRoleService = useService(new CommonDescriptor("Role"), this._service);
  }

  @Input() set user(user:any){
    this.originalUser = user;

  	this.editUser = _.extend({
      "DateOfBirthStr": "",
      "Email": "",
      "FirstName": "",
      "LastName": "",
      "Mobile": "",
      "Role": null,
      "RoleId": null,
      "UserId": null,
      "Username": ""
  	}, user);
  }
  
  @Output() onHide: EventEmitter<string> = new EventEmitter<string>();
  @Output() onSave: EventEmitter<string> = new EventEmitter<string>();
  ngOnInit() {
    this.roleList = this.callRoleService({method:'get', param:{}});
  }


  saveUser(){
    if (this.originalUser == null)
      this.callUserService({method:'post', param:this.editUser});
    else
      this.callUserService({method:'put', param:this.editUser})
      .subscribe(res=>{console.log(res);});
    
    this.onSave.next("");
  }

  hide(){
    this.onHide.next("");
  }
}
