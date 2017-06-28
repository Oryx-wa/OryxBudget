import {Schema, arrayOf } from 'normalizr/lib';
import { ContactPerson } from './contactPerson.interface';
export const contactPersonSchema = new Schema('ContactPerson');
export const arrayOfContactPerson = arrayOf(contactPersonSchema);



export const initContactPerson: ContactPerson = {
    id: '',
    userSign: '',
    lastName: '',
    operatorId: '',
};
export interface ContactPersonEntity {
    [id: string]: ContactPerson;
}
