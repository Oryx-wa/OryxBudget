import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getOperatorIds, getOperatorEntities,
    OperatorState
} from './operator.reducer';

// Operator
/*
export const getOperatorState = (state: AppState) => state.operators.operator;
export const OperatorEntities = createSelector(getOperatorState, getOperatorEntities);
export const OperatorIds = createSelector(getOperatorState, getOperatorIds);
export const getOperatorCollection = createSelector(OperatorEntities, OperatorIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
*/