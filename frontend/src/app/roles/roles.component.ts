import { Component, OnInit } from '@angular/core';
import useService from './../services/useService';
import { Service } from './../services';
import { CommonDescriptor } from './../models';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {
  roleList: Observable<Array<any>> = null;
  roleService: any = null;
  constructor(private _service: Service) {
  	this.roleService = useService(new CommonDescriptor("Role"), this._service);
  }

  ngOnInit() {
  	this.roleList = this.roleService({method: 'get', param: {}});
  }

}
