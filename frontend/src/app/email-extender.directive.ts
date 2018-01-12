import { AfterContentInit, ElementRef, Directive, Input } from '@angular/core';

@Directive({
  selector: 'appEmailExtender'
})
export class EmailExtenderDirective implements AfterContentInit
 {
  @Input() email:string = null;

  constructor(private element: ElementRef) {
  }

  ngAfterContentInit(){
  	console.log('ngAfterContentInit email:', this.email);
  }

}
