import { User } from 'src/app/auth/interfaces/user';

export interface UserWithContactStatus extends User {
    contactStatus: string;
}
