import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getBudgetIds, getBudgetEntities, getPrintOut,
    BudgetState, getSelectedBudget, getWorkProgramStatus, getWorkProgramStatusNumber,
    getAllWorkProgramStatusEntities, getAllWorkProgramStatusIds
} from './budget.reducer';

// Budget

export const getBudgetState = (state: AppState) => state.budgets.budget;
export const getUserState = (state: AppState) => state.security.user;
export const BudgetEntities = createSelector(getBudgetState, getBudgetEntities);
export const BudgetIds = createSelector(getBudgetState, getBudgetIds);
export const getBudgetCollection = createSelector(BudgetEntities, BudgetIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
export const selectedBudget = createSelector(getBudgetState, getSelectedBudget);
export const workProgramStatus = createSelector(getBudgetState, getWorkProgramStatus);
export const printOut = createSelector(getBudgetState, getPrintOut);
export const workProgramStatusNumber = createSelector(getBudgetState, getWorkProgramStatusNumber);

export const workStatusIds = createSelector(getBudgetState, getAllWorkProgramStatusIds);
export const workStatusEntities = createSelector(getBudgetState, getAllWorkProgramStatusEntities);
export const getAllStatusCollection = createSelector( workStatusEntities,
    workStatusIds, (entities, ids) => {
        return ids.map(id => entities[id]);
    });