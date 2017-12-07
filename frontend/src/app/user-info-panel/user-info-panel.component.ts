import { TemplateRef, ViewChild, Component, OnInit, Input, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import * as _ from 'lodash';

@Component({
  selector: 'app-user-info-panel',
  templateUrl: './user-info-panel.component.html',
  styleUrls: ['./user-info-panel.component.css']
})
export class UserInfoPanelComponent implements OnInit {

  constructor() { }

  public editUser: any;
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
  
  ngOnInit() {
  }

}
