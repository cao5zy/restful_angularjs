import { TemplateRef, ViewChild, Component, OnInit, Input, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import * as _ from 'lodash';

@Component({
  selector: 'app-user-info-panel',
  templateUrl: './user-info-panel.component.html',
  styleUrls: ['./user-info-panel.component.css']
})
export class UserInfoPanelComponent implements OnInit {

  constructor() { }

  private _user: any;
  @Input() set user(user:any){
  	console.log('user panel:', user);
  	this._user = _.extend({
  		Username:""
  	}, user);
  }
  
  ngOnInit() {
  }

}
