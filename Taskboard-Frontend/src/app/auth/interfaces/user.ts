import { Identifiable } from 'src/app/core/interfaces/identifiable';

export interface User extends Identifiable {
    email: string;
    fullName: string;
    created: Date;
}
