import * as fromRoot from './../../';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import { AppState } from './../../';

import {
    getBudgetLineIds, getBudgetLineEntities,
    BudgetLineState, getSelectedBudgetLine, getTouched
} from './budgetLine.reducer';

import { BudgetLines } from './budgetLine.interface';
// BudgetLine
// const dept = (state: AppState) => state.security.user.dept;
export const getBudgetLineState = (state: AppState) => state.budgets.budgetLine;
export const BudgetLineEntities = createSelector(getBudgetLineState, getBudgetLineEntities);
export const BudgetLineIds = createSelector(getBudgetLineState, getBudgetLineIds);
export const getBudgetLineCollection = createSelector( BudgetLineEntities, BudgetLineIds, (entities, ids) => {
    if (ids.length === 0) {
        return [];
    }

    return ids.map(id =>  entities[id]);
});
export const getBudgetLineLevel2Collection = createSelector(BudgetLineEntities, BudgetLineIds, (entities, ids) => {
    if (ids.length === 0) {
        return [];
    }
    const ret: BudgetLines[] = []
    ids.map(id => {
        if (entities[id].level === '2') {
            ret.push(entities[id]);
        }
    });
    return ret;
});
export const selectedBudgetLine = createSelector(getBudgetLineState, getSelectedBudgetLine);
export const touched = createSelector(getBudgetLineState, getTouched);

export const getUntouchedCollection = createSelector(BudgetLineEntities, BudgetLineIds, (entities, ids) => {
    if (ids.length === 0) {
        return [];
    }

    const ret = ids.map(id => {
        if (entities[id].lineStatus === 1) {
            return entities[id];
        }
    });
    return ret;
});