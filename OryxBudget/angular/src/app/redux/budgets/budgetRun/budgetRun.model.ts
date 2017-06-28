import { Schema, arrayOf } from 'normalizr/lib';
import { BudgetRun } from './budgetRun.interface';
export const budgetRunSchema = new Schema('BudgetRun');
export const arrayOfBudgetRun = arrayOf(budgetRunSchema);



export const initBudgetRun: BudgetRun = {
    id: '',
    budgetId: '',
    budget: '',
    startDate: new Date(),
    endDate: new Date(),

};
export interface BudgetRunEntity {
    [id: string]: BudgetRun;
}
