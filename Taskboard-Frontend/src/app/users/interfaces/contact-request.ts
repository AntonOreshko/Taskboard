import { Identifiable } from 'src/app/core/interfaces/identifiable';

export interface ContactRequest extends Identifiable {
    senderId: number;
    receiverId: number;
}
