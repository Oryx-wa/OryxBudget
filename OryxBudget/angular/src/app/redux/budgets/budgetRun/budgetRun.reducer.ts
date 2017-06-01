import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budgetRun.action';
import { BudgetRun } from './budgetRun.interface';
import {
    arrayOfBudgetRun, BudgetRunEntity,
    budgetRunSchema, initBudgetRun
} from './budgetRun.model';

import { updateObject } from '../../utilities';

export interface BudgetRunState {
    ids: string[];
    entities: BudgetRunEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initBudgetRunState: BudgetRunState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const BudgetRunReducer: ActionReducer<BudgetRunState> = (state: BudgetRunState = initBudgetRunState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudgetRun: any = normalize(action.payload, budgetRunSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudgetRun.result),
                entities: _.merge({}, state.entities, newBudgetRun.entities.BudgetRun),
                lastUpdate: new Date(),
                selectedId: newBudgetRun.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const BudgetRun: any = normalize(action.payload, arrayOfBudgetRun);
            return updateObject({}, updateObject(state, {
                ids: BudgetRun.result,
                entities: BudgetRun.entities.BudgetRun,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getBudgetRunEntities = (state: BudgetRunState) => state.entities;
export const getBudgetRunIds = (state: BudgetRunState) => state.ids;
export const getSelectedBudgetRunId = (state: BudgetRunState) => state.selectedId;

export const getSelectedBudgetRun = createSelector(getBudgetRunEntities, getSelectedBudgetRunId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudgetRun;
    }
    return entities[selectedId];
});
