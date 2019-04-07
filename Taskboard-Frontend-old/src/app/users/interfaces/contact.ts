import { Identifiable } from 'src/app/core/interfaces/identifiable';

export interface Contact extends Identifiable {
    firstUserId: number;
    secondUserId: number;
}
