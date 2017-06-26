
export * from './contactPerson';
export * from './operator';
export * from './operatorType';

import { combineReducers } from '@ngrx/store';


import { ContactPersonReducer, ContactPersonState } from './contactPerson/contactPerson.reducer';
import { OperatorReducer, OperatorState } from './operator/operator.reducer';
import { OperatorTypeReducer, OperatorTypeState } from './operatorType/operatorType.reducer';


const reducer = {

    contactPerson: ContactPersonReducer,
    operator: OperatorReducer,
    operatorType: OperatorTypeReducer,

};

export const OperatorsReducer = combineReducers(reducer);

export interface OperatorsState {

    contactPerson: ContactPersonState;
    operator: OperatorState;
    operatorType: OperatorTypeState;
}

