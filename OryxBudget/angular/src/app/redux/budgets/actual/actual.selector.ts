import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getActualIds, getActualEntities,
    ActualState
} from './actual.reducer';

// Actual

export const getActualState = (state: AppState) => state.budgets.actual;
export const ActualEntities = createSelector(getActualState, getActualEntities);
export const ActualIds = createSelector(getActualState, getActualIds);
export const getActualCollection = createSelector(ActualEntities, ActualIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
