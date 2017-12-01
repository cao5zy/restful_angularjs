import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import useService from './../services/useService';
import { Service } from './../services';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/modal-options.class';
import { MemberDescriptor } from './../models';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  memberList: Observable<Array<any>> = null; 
  memberService: any = null;
  constructor(private modalService: BsModalService,
    private _service: Service) {
  		this.memberService = useService(new MemberDescriptor(), this._service);
  }

  ngOnInit() {
  	this.memberList = this.memberService({method:"get", param: {}});
  }

}
