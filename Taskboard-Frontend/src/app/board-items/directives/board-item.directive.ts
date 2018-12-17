import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appBoardItem]'
})
export class BoardItemDirective {

  constructor(public viewContainerRef: ViewContainerRef) { }

}
