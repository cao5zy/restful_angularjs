import { Descriptor } from './descriptor';
import * as _ from 'lodash';

export class MemberDescriptor extends Descriptor {
  constructor(){
    super();
    this.urn = "User";
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

  deletePreConvert(obj: any):any{
    console.log('deletePreConvert', obj);
    return {instanceName:obj}
  }

  putPreConvert(obj: any):any{
    //{originalInstanceName: orginalInstanceName,
    //        	  model: this.appViewModel}
    return obj;
  }
}