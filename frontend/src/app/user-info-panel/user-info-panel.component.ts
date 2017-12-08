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
  memberService: any = null;

  constructor(private _service: Service) { 
      this.memberService = useService(new CommonDescriptor(), this._service);
  }

  @Input() set user(user:any){
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
  }


  saveUser(){

    this.memberService({method:'post', param:this.editUser})
      .subscribe(res=>{console.log(res);});
    this.onSave.next("");
  }

  hide(){
    this.onHide.next("");
  }
}
