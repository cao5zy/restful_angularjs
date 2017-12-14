import { Descriptor } from './descriptor';
import * as _ from 'lodash';

export class CommonDescriptor extends Descriptor {
  constructor(urn: string){
    super();
    this.urn = urn;
  }

  getConvert(obj: any):any{
    return (((dic)=>{
    	   console.log('getConvert.obj', obj);
    	   return dic["_body" in obj ? 0 : 1]();
    })({
	0:()=>_.map(JSON.parse(obj._body), json=>json),
	1:()=>obj
    }));
  }

  postPreConvert(obj: any):any{
    return obj;
  }
  postConvert(obj: any):any{
      return obj._body == "\"\"" ? _.extend(obj, {_body:""}):obj;
    }

  deletePreConvert(obj: any):any{
    console.log('deletePreConvert', obj);
    return obj
  }

  putPreConvert(obj: any):any{
    return obj;
  }
  putConvert(obj: any):any {
    return obj._body == "\"\"" ? _.extend(obj, {_body:""}):obj;
  }

}