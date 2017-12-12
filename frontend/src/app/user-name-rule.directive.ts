import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator, ValidatorFn, Validators } from '@angular/forms';
import * as rules from './rules.json';
import { RuleService } from './services';

@Directive({
  selector: '[appUserNameRule]',
  providers: [{provide: NG_VALIDATORS, useExisting: UserNameRuleDirective, multi: true}]
})
export class UserNameRuleDirective implements Validator {
  constructor(private _ruleService: RuleService){}
  validate(control: AbstractControl):{[key: string]: any}{
  	if (!control.dirty && control.value == null)
  		return null;
  	
  	let result = this._ruleService.checkRule("username", control.value);
  	if (result.result)
  		return null;
  	else
  		return {"username": result.reason};
  }
}
