import { Completable } from 'src/app/core/interfaces/completable';
import { BoardElement } from './board-element';

export interface Task extends BoardElement, Completable {

}
