import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getOperatorTypeIds, getOperatorTypeEntities,
    OperatorTypeState
} from './operatorType.reducer';

// OperatorType

export const getOperatorTypeState = (state: AppState) => state.operators.operatorType;
export const OperatorTypeEntities = createSelector(getOperatorTypeState, getOperatorTypeEntities);
export const OperatorTypeIds = createSelector(getOperatorTypeState, getOperatorTypeIds);
export const getOperatorTypeCollection = createSelector(OperatorTypeEntities, OperatorTypeIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
