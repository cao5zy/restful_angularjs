import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator, ValidatorFn, Validators } from '@angular/forms';

@Directive({
  selector: '[appUserNameRule]',
  providers: [{provide: NG_VALIDATORS, useExisting: UserNameRuleDirective, multi: true}]
})
export class UserNameRuleDirective implements Validator {

  constructor() { }

  validate(control: AbstractControl):{[key: string]: any}{
  	console.log('validate:', control.value);
  	return null;
  }
}
