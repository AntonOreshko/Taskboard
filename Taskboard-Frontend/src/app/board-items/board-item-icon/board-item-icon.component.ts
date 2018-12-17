import { Component, OnInit, OnDestroy, ViewChild, Input, ComponentFactoryResolver } from '@angular/core';
import { BoardItemDirective } from '../directives/board-item.directive';
import { IconItemData } from '../interfaces/icon-item-data';
import { BoardIcon } from '../interfaces/board-icon';

@Component({
  selector: 'app-board-item-icon',
  templateUrl: './board-item-icon.component.html',
  styleUrls: ['./board-item-icon.component.css']
})
export class BoardItemIconComponent implements OnInit, OnDestroy {

  @Input() iconItemData: IconItemData;

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
        this.iconItemData.component
      );

    const viewContainerRef = this.appBoardItem.viewContainerRef;
    viewContainerRef.clear();

    const componentRef = viewContainerRef.createComponent(componentFactory);
    (<BoardIcon>componentRef.instance).item = this.iconItemData.iconItem;
  }
}
