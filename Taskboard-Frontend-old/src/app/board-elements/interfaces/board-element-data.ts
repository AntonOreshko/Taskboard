import { Type } from '@angular/core';
import { BoardElement } from './board-element';

export interface BoardElementData {
    componentType: Type<any>;
    boardElement: BoardElement;
}
