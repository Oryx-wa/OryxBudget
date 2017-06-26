import { Schema, arrayOf } from 'normalizr/lib';
import { BudgetLine } from './budgetLine.interface';
export const budgetLineSchema = new Schema('budgetLine');
export const arrayOfBudgetLine = arrayOf(budgetLineSchema);


export const initBudgetLine: BudgetLine = {
    id: '',
    rowNumber: '',
    code: '',
    opBudgetFC: 0.0,
    description: '',
    opBudgetLC: 0.0,
    opBudgetUSD: 0.0,
    opBudgetLCInUSD: 0.0,
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
    lineStatus: '',
    approvalStatus: '',
    budgetId: '',
    categoryId: '',
};
export interface BudgetLineEntity {
    [id: string]: BudgetLine;
}
