import { Identifiable } from 'src/app/core/interfaces/identifiable';
import { Descriptable } from 'src/app/core/interfaces/descriptable';

export interface NoteEditData extends Identifiable, Descriptable {
    id: number;
    name: string;
    description: string;
}
