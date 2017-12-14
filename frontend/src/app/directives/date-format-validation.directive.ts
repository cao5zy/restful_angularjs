import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, Validator, ValidatorFn, Validators } from '@angular/forms';

@Directive({
  selector: '[appDateFormatValidation]',
  providers: [{provide: NG_VALIDATORS, useExisting: DateFormatValidationDirective, multi: true}]
})
export class DateFormatValidationDirective implements Validator {

  validate(control: AbstractControl):{[key:string]:any}{
  	return ((reg:RegExp):boolean=>{
  		return reg.test(control.value)
  	})(/([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8])))/) ? null : {"appDateFormatValidation":{value:"Date should be as format ####-##-##"}}
  }

}
