import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import useService from './../services/useService';
import { Service } from './../services';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/modal-options.class';
import { CommonDescriptor } from './../models';
import { UserInfoPanelComponent } from './../user-info-panel/user-info-panel.component';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  memberList: Observable<Array<any>> = null; 
  memberService: any = null;
  modal:BsModalRef;
  selectedUser:any = null;

  constructor(private modalService: BsModalService,
    private _service: Service) {
  		this.memberService = useService(new CommonDescriptor(), this._service);
  }

  ngOnInit() {
  	this.memberList = this.memberService({method:"get", param: {}});
  }

  selectUser(user, template){
    this.selectedUser = user;
    this.modal = this.modalService.show(template);
  }
}
