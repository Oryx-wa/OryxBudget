import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetCodeIds, getBudgetCodeEntities,
    BudgetCodeState
} from './budgetCode.reducer';

// BudgetCode

export const getBudgetCodeState = (state: AppState) => state.budgets.budgetCode;
export const BudgetCodeEntities = createSelector(getBudgetCodeState, getBudgetCodeEntities);
export const BudgetCodeIds = createSelector(getBudgetCodeState, getBudgetCodeIds);
export const getBudgetCodeCollection = createSelector(BudgetCodeEntities, BudgetCodeIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
