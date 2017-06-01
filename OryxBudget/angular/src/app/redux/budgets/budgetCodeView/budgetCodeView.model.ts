import { Schema, arrayOf } from 'normalizr/lib';
import { BudgetCodeView } from './budgetCodeView.interface';
export const budgetCodeViewSchema = new Schema('BudgetCodeView');
export const arrayOfBudgetCodeView = arrayOf(budgetCodeViewSchema);



export const initBudgetCodeView: BudgetCodeView = {
    id: '',
    code: '',
    description: '',
    fatherNum: '',
    level: '',
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
    budgetId: '',
};
export interface BudgetCodeViewEntity {
    [id: string]: BudgetCodeView;
}
