import { Component, OnInit, OnDestroy, ViewChild, Input, ComponentFactoryResolver } from '@angular/core';
import { BoardItemDirective } from '../directives/board-item.directive';
import { BoardElementData } from '../interfaces/board-element-data';
import { BoardElementIconComponent } from '../interfaces/board-element-icon-component';

@Component({
  selector: 'app-board-item-icon',
  templateUrl: './board-item-icon.component.html',
  styleUrls: ['./board-item-icon.component.css']
})
export class BoardItemIconComponent implements OnInit, OnDestroy {

  @Input() boardElementData: BoardElementData;

  @ViewChild(BoardItemDirective) appBoardItem: BoardItemDirective;

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
    (<BoardElementIconComponent>componentRef.instance).boardElement = this.boardElementData.boardElement;
  }
}
