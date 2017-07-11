import { Schema, arrayOf } from 'normalizr/lib';
import { BudgetLines } from './budgetLine.interface';
export const budgetLineSchema = new Schema('BudgetLine', { idAttribute: 'code' });
export const arrayOfBudgetLine = arrayOf(budgetLineSchema);

export const initBudgetLines: BudgetLines = {
    id: '',
    code: '',
    description: '',
    level: '',
    fatherNum: '',
    opBudgetFC: 0,
    opBudgetLC: 0,
    opBudgetUSD: 0,
    subComBudgetFC: 0,
    subComBudgetLC: 0,
    subComBudgetUSD: 0,
    tecComBudgetFC: 0,
    tecComBudgetLC: 0,
    tecComBudgetUSD: 0,
    malComBudgetFC: 0,
    malComBudgetLC: 0,
    malComBudgetUSD: 0,
    finalBudgetFC: 0,
    finalBudgetLC: 0,
    finalBudgetUSD: 0,
    opActualFC: 0,
    opActualLC: 0,
    opActualUSD: 0,
    subComActualFC: 0,
    subComActualLC: 0,
    subComActualUSD: 0,
    tecComActualFC: 0,
    tecComActualLC: 0,
    tecComActualUSD: 0,
    malComActualFC: 0,
    malComActualLC: 0,
    malComActualUSD: 0,
    finalActualFC: 0,
    finalActualLC: 0,
    finalActualUSD: 0,
    lineStatus: 1,
    budgetId: '',
    workProgramStatus: 0,
    touched: false,
    dept: ''
};

export interface BudgetLineEntity {
    [id: string]: BudgetLines;
}
