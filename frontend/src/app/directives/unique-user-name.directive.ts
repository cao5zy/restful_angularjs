import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator, ValidatorFn, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';

@Directive({
  selector: '[appUniqueUserName]',
  providers: [{provide: NG_VALIDATORS, useExisting: UniqueUserNameDirective, multi: true}]
})
export class UniqueUserNameDirective {

  constructor() { }

  validate(control:AbstractControl):Observable<{[key:string]:string}>{
  	return new Observable<{[key:string]:string}>((observer:Observer<{[key:string]:string}>)=>{
  		observer.next(null);
  	});
  }

}
