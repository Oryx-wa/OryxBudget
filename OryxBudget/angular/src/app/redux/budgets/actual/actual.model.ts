import { Schema, arrayOf } from 'normalizr/lib';
import { Actual } from './actual.interface';
export const actualSchema = new Schema('Actual');
export const arrayOfActual = arrayOf(actualSchema);



export const initActual: Actual = {
    id: '',
    opActualFC: 0.0,
    description: '',
    opActualLC: 0.0,
    opActualLCInUSD: 0.0,
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
export interface ActualEntity {
    [id: string]: Actual;
}
