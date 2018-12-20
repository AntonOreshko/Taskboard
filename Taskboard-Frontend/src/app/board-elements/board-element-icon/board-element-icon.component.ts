import { Component, OnInit, OnDestroy, ViewChild, Input, ComponentFactoryResolver } from '@angular/core';
import { BoardElementDirective } from '../directives/board-element.directive';
import { BoardElementData } from '../interfaces/board-element-data';
import { BoardElementIconBase } from '../interfaces/board-element-icon-base';

@Component({
  selector: 'app-board-element-icon',
  templateUrl: './board-element-icon.component.html',
  styleUrls: ['./board-element-icon.component.css']
})
export class BoardElementIconComponent implements OnInit, OnDestroy {

  @Input() boardElementData: BoardElementData;

  @ViewChild(BoardElementDirective) appBoardItem: BoardElementDirective;

  constructor(private _componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    this.loadComponents();
  }

  ngOnDestroy(): void {
  }

  private loadComponents() {
    const componentFactory =
      this._componentFactoryResolver.resolveComponentFactory(
        this.boardElementData.componentType
      );

    const viewContainerRef = this.appBoardItem.viewContainerRef;
    viewContainerRef.clear();

    const componentRef = viewContainerRef.createComponent(componentFactory);
    (<BoardElementIconBase>componentRef.instance).boardElement = this.boardElementData.boardElement;
  }
}
