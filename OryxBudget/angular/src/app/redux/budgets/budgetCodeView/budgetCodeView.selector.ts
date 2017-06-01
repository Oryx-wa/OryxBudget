import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetCodeViewIds, getBudgetCodeViewEntities,
    BudgetCodeViewState
} from './budgetCodeView.reducer';

// BudgetCodeView

export const getBudgetCodeViewState = (state: AppState) => state.budgets.budgetCodeView;
export const BudgetCodeViewEntities = createSelector(getBudgetCodeViewState, getBudgetCodeViewEntities);
export const BudgetCodeViewIds = createSelector(getBudgetCodeViewState, getBudgetCodeViewIds);
export const getBudgetCodeViewCollection = createSelector(BudgetCodeViewEntities, BudgetCodeViewIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
