import { Service } from './service';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { AppConfig } from './../appConfig';

@Injectable()
export class HttpService extends Service{
    private buildUrl: (urn:string)=>string;

    constructor(private http: Http, config: AppConfig){
      super();
      console.log('httpConfig.baseUrl', config.baseUrl);
      this.buildUrl = (urn:string):string=>{
        return `${config.baseUrl}/${urn}`;
      };
    }
    get(urn: string, param: any): Observable<any>{
    	return new Observable<any>((observer: Observer<any>)=>{
	    this.http.get(this.buildUrl(urn),{params: param})
	    .subscribe((res)=>{
	        observer.next(res);
	    });
	});
        
    }
    post(urn: string, param: any): Observable<any>{

    	return new Observable<any>((observer: Observer<any>)=>{
	    this.http.post(this.buildUrl(urn),param)
	    .subscribe((res)=>{
	        observer.next(res);
	    });
	});
    
    }
    delete(urn: string, param: any): Observable<any>{
    	return new Observable<any>((observer: Observer<any>)=>{
	    this.http.delete(this.buildUrl(urn),{params: param})
	    .subscribe((res)=>{
	        observer.next(res);
	    });
	});
    
    }
    put(urn: string, param: any): Observable<any>{
    	return new Observable<any>((observer: Observer<any>)=>{
	    this.http.put(this.buildUrl(urn), param)
	    .subscribe((res)=>{
		console.log('put', res);
	        observer.next(res);
	    });
	});
    
    }
}