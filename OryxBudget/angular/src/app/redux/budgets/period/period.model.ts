import { Schema, arrayOf } from 'normalizr/lib';
import { Period } from './period.interface';
export const periodSchema = new Schema('Period');
export const arrayOfPeriod = arrayOf(periodSchema);



export const initPeriod: Period = {
    id: '',
    description: '',
    startDate: new Date(),
    endDate: new Date(),


};
export interface PeriodEntity {
    [id: string]: Period;
}
