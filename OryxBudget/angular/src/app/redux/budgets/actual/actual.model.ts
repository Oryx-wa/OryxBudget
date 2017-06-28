import { Schema, arrayOf } from 'normalizr/lib';
import { Actual } from './actual.interface';
export const actualSchema = new Schema('Actual');
export const arrayOfActual = arrayOf(actualSchema);



export const initActual: Actual = {
    id: '',
    code: '',
    description: '',
    level: '',
    fatherNum: '',
    opActualFC: 0,
    opActualLC: 0,
    opActualUSD: 0,
    opActualCInUSD: 0,
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
    lineStatus: '',
    budgetId: '',
    finalBudgetFC: 0,
};

export interface ActualEntity {
    [id: string]: Actual;
}
