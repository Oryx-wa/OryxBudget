import { Schema, arrayOf } from 'normalizr/lib';
import { OperatorType } from './operatorType.interface';
export const operatorTypeSchema = new Schema('OperatorType');
export const arrayOfOperatorType = arrayOf(operatorTypeSchema);



export const initOperatorType: OperatorType = {
    id: '',
    name: '',
};
export interface OperatorTypeEntity {
    [id: string]: OperatorType;
}
