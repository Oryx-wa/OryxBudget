import { Schema, arrayOf } from 'normalizr/lib';
import { Budget } from './budget.interface';
export const budgetSchema = new Schema('Budget');
export const arrayOfBudget = arrayOf(budgetSchema);



export const initBudget: Budget = {
    id: '',
    description: '',
    additionalStatement: '',
    periodId: '',
    opBudgetFC: 0.0,
    opBudgetLC: 0.0,
    opBudgetUSD: 0.0,
    subComBudgetFC: 0.0,
    subComBudgetLC: 0.0,
    subComBudgetUSD: 0.0,
    tecComBudgetFC: 0.0,
    tecComBudgetLC: 0.0,
    tecComBudgetUSD: 0.0,
    malComBudgetFC: 0.0,
    malComBudgetLC: 0.0,
    malComBudgetUSD: 0.0,
    finalBudgetFC: 0.0,
    finalBudgetLC: 0.0,
    finalBudgetUSD: 0.0,
    opActualFC: 0.0,
    opActualLC: 0.0,
    opActualUSD: 0.0,

    subComActualFC: 0.0,
    subComActualLC: 0.0,
    subComActualUSD: 0.0,
    tecComActualFC: 0.0,
    tecComActualLC: 0.0,
    tecComActualUSD: 0.0,
    malComActualFC: 0.0,
    malComActualLC: 0.0,
    malComActualUSD: 0.0,
    finalActualFC: 0.0,
    finalActualLC: 0.0,
    finalActualUSD: 0.0
};
export interface BudgetEntity {
    [id: string]: Budget;
}
