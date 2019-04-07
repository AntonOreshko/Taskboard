import { Identifiable } from 'src/app/core/interfaces/identifiable';
import { Creatable } from 'src/app/core/interfaces/creatable';
import { Descriptable } from 'src/app/core/interfaces/descriptable';
import { Completable } from 'src/app/core/interfaces/completable';
import { TaskItem } from './task-item';

export interface Subtask extends Identifiable, Creatable, Descriptable, Completable, TaskItem {

}
