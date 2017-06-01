import { Schema, arrayOf } from 'normalizr/lib';
import { StatusHistory } from './statusHistory.interface';
export const statusHistorySchema = new Schema('StatusHistory');
export const arrayOfStatusHistory = arrayOf(statusHistorySchema);



export const initStatusHistory: StatusHistory = {
    id: '',
    itemStatus: '',
    code: '',
    budgetId: '',
    itemCodeStatus: '',


};
export interface StatusHistoryEntity {
    [id: string]: StatusHistory;
}
