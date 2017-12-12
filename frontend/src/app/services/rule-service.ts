import { Injectable } from '@angular/core';
import * as rules from './../rules.json';
import * as _ from 'lodash';

@Injectable()
export class RuleService {

  constructor() { }

  checkRule(ruleName: string, value: string):{result:boolean, reason: string }
  {
    let check:(rule:any)=>{result: boolean, reason: string} = (rule)=>{
    	return ((value == null || value.length == 0) && rule[ruleName].canbeempty) ? 
	    	{result: true, reason:""} :
	    	(value != null && rule[ruleName].blacklist && _.find(rule[ruleName].blacklist, n=>n.toLowerCase() == value.toLowerCase())) ?
	    	{result: false, reason:`'${value}'' is not allowed.`} :
	    	(value != null && rule[ruleName].validexpression && !new RegExp(rule[ruleName].validexpression).test(value)) ?
	    	{result: false, reason: "contains invalid charactor"} :
        value == null ?
        {result: false, reason: `${ruleName} should not be empty`} :
	    	{result: true, reason: ""};
    };
    return ((rule)=>{
    	return ruleName in rule ? check(rule): {result: false, reason: `${ruleName} is not defined`};

    })(rules.default);
  }
}
