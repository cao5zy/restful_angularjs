import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import * as _ from 'lodash';
import { Descriptor } from './../models/descriptor';
import { Service } from './service';
import { ServiceParam } from './../models/serviceParam';

export default function(descriptor: Descriptor, service: Service): (serviceParam: ServiceParam)=>Observable<any>{

    return (param: ServiceParam): Observable<any>=>{
      return new Observable<any>((observer: Observer<any>)=>{
	  service[param.method](descriptor.urn, descriptor[param.method + "PreConvert"](param.param))
	  .subscribe((result)=>{
	      if(_.isArray(result)){
		  observer.next(_.map(result, n=>descriptor[param.method + "Convert"](n)))
	      }
	      else
	      {
		  observer.next(descriptor[param.method + "Convert"](result))
	      }
	  });
      });
      
    };
}