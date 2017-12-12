import { Directive, Input } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator, ValidatorFn, Validators } from '@angular/forms';
import * as rules from './rules.json';
import { RuleService } from './services';

@Directive({
  selector: '[appRule]',
  providers: [{provide: NG_VALIDATORS, useExisting: RuleDirective, multi: true}]
})
export class RuleDirective implements Validator {
  @Input() appRule: string;
  constructor(private _ruleService: RuleService){}
  validate(control: AbstractControl):{[key: string]: any}{
  	if (!control.dirty && control.value == null)
  		return null;

  	let result = this._ruleService.checkRule(this.appRule, control.value);
  	if (result.result)
  		return null;
  	else
  		return {"appRule": {value: result.reason}};
  }
}
