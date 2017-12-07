import { TemplateRef, EventEmitter, ViewChild, Output, Component, OnInit, Input, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import * as _ from 'lodash';

@Component({
  selector: 'app-user-info-panel',
  templateUrl: './user-info-panel.component.html',
  styleUrls: ['./user-info-panel.component.css']
})
export class UserInfoPanelComponent implements OnInit {

  constructor() { }
  editUser:any = null;

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
    this.onSave.next("");
    //this.memberService({method:'post', param:this.editUser});
  }

  hide(){
    this.onHide.next("");
  }
}
