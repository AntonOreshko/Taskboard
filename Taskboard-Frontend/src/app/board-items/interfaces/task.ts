import { BoardItem } from './board-item';

export interface Task extends BoardItem {
    completed: boolean;
    completedById: number;
}
