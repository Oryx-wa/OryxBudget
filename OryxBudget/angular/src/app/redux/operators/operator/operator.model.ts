import { Schema, arrayOf } from 'normalizr/lib';
import { Operator } from './operator.interface';
export const operatorSchema = new Schema('Operator');
export const arrayOfOperator = arrayOf(operatorSchema);



export const initOperator: Operator = {
    id: '',
    name: '',
    code: '',
    operatorTypeId: '',
    imageSrc: '',
};
export interface OperatorEntity {
    [id: string]: Operator;
}
