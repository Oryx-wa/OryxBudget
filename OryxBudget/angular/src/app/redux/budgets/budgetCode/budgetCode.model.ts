import { Schema, arrayOf } from 'normalizr/lib';
import { BudgetCode } from './budgetCode.interface';
export const budgetCodeSchema = new Schema('BudgetCode');
export const arrayOfBudgetCode = arrayOf(budgetCodeSchema);



export const initBudgetCode: BudgetCode = {
    id: '',
    description: '',
    code: '',
    secondDescription: '',
    fatherNum: '',
    level: '',
    active: '',
    categoryId: '',
    postable: '',
    level1: '',
    level2: '',

};
export interface BudgetCodeEntity {
    [id: string]: BudgetCode;
}
