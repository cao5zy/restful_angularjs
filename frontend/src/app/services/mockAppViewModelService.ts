import { Injectable } from '@angular/core';
import { MockService } from './mockService';
import { AppViewModel } from './../models';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';

@Injectable()
export class MockAppViewModelService extends MockService{
  constructor(){
    super({});
  }

  get(urn: string, param: any): Observable<Array<AppViewModel>>{
    return Observable.create((observer: Observer<Array<AppViewModel>>)=>{
        observer.next(this.json["items"] as Array<AppViewModel> || []);
	observer.complete();
    });
  }

  post(urn: string, param: any): Observable<boolean>{
    return Observable.create((observer: Observer<boolean>)=>{

	((datas)=>{
	  datas.push(param);
	  console.log('datas:', datas);
	})(this.json["items"] || ((items)=>{ return this.json["items"] = items && items;})([]));

	observer.next(true);
	observer.complete();
    });
  }
  
}
