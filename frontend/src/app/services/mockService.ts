import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Service } from './service';

@Injectable()
export class MockService extends Service {
    constructor(protected json: any){
      super();
    }
    get(urn: string, param: any): Observable<any>{
        return new Observable<any>((observer: Observer<any>)=>{
    	    observer.next("hello");
    	});
    }

    post(urn: string, param: any): Observable<any>{
      return new Observable<any>((observer: Observer<any>)=>{
          observer.next(true);
      });
    }

    put(urn: string, param: any): Observable<any>{
      return new Observable<any>((observer: Observer<any>)=>{
          observer.next(true);
      });
    }
    delete(urn: string, param: any): Observable<any>{
      return new Observable<any>((observer: Observer<any>)=>{
          observer.next(true);
      });
    }

}