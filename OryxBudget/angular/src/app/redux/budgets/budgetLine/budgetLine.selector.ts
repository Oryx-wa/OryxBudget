import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetLineIds, getBudgetLineEntities,
    BudgetLineState, getSelectedBudgetLine, getTouched
} from './budgetLine.reducer';

// BudgetLine

export const getBudgetLineState = (state: AppState) => state.budgets.budgetLine;
export const BudgetLineEntities = createSelector(getBudgetLineState, getBudgetLineEntities);
export const BudgetLineIds = createSelector(getBudgetLineState, getBudgetLineIds);
export const getBudgetLineCollection = createSelector(BudgetLineEntities, BudgetLineIds, (entities, ids) => {
    if(ids.length === 0) {
        return [];
    }
    return ids.map(id => entities[id]);
});
export const selectedBudgetLine = createSelector(getBudgetLineState, getSelectedBudgetLine);
export const touched = createSelector(getBudgetLineState, getTouched);