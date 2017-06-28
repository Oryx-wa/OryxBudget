import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetRunIds, getBudgetRunEntities,
    BudgetRunState
} from './budgetRun.reducer';

// BudgetRun

export const getBudgetRunState = (state: AppState) => state.budgets.budgetRun;
export const BudgetRunEntities = createSelector(getBudgetRunState, getBudgetRunEntities);
export const BudgetRunIds = createSelector(getBudgetRunState, getBudgetRunIds);
export const getBudgetRunCollection = createSelector(BudgetRunEntities, BudgetRunIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
