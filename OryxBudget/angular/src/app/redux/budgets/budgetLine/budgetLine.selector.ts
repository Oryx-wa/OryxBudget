import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetLineIds, getBudgetLineEntities,
    BudgetLineState
} from './budgetLine.reducer';

// BudgetLine

export const getBudgetLineState = (state: AppState) => state.budgets.budgetLine;
export const BudgetLineEntities = createSelector(getBudgetLineState, getBudgetLineEntities);
export const BudgetLineIds = createSelector(getBudgetLineState, getBudgetLineIds);
export const getBudgetLineCollection = createSelector(BudgetLineEntities, BudgetLineIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
