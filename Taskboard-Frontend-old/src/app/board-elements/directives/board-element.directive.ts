import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appBoardElement]'
})
export class BoardElementDirective {

  constructor(public viewContainerRef: ViewContainerRef) { }

}
