import { Identifiable } from 'src/app/core/interfaces/identifiable';
import { Creatable } from 'src/app/core/interfaces/creatable';
import { Descriptable } from 'src/app/core/interfaces/descriptable';
import { BoardItem } from './board-item';

export interface BoardElement extends Identifiable, Creatable, Descriptable, BoardItem {

}
