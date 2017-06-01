import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getPeriodIds, getPeriodEntities,
    PeriodState
} from './period.reducer';

// Period

export const getPeriodState = (state: AppState) => state.budgets.period;
export const PeriodEntities = createSelector(getPeriodState, getPeriodEntities);
export const PeriodIds = createSelector(getPeriodState, getPeriodIds);
export const getPeriodCollection = createSelector(PeriodEntities, PeriodIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
