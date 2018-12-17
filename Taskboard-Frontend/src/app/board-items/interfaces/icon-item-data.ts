import { BoardItem } from './board-item';
import { Type } from '@angular/core';

export interface IconItemData {
    component: Type<any>;
    iconItem: BoardItem;
}
