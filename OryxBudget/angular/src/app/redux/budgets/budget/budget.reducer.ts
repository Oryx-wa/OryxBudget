import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budget.action';
import { Budget } from './budget.interface';
import { Budgets, Actual, BudgetLines, LineComments, LineStatus } from './models';
import {
    arrayOfBudget, arrayOfActuals, arrayOfLineComments, arrayOfLines,
    budgetSchema, actualSchema, linesSchema, lineCommentsSchema,
    initBudget, initActual, initBudgetLines, initLineComments, initLineStatus
} from './models';

export interface BudgetEntity {
    [id: string]: Budget;
}

import { updateObject } from '../../utilities';

export interface BudgetState {
    ids: string[];
    entities: BudgetEntity;
    lastUpdate: Date;
    selectedId: string | null;
    workProgramState: string | null;

}

export const initBudgetState: BudgetState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
    workProgramState: null
};

export const BudgetReducer: ActionReducer<BudgetState> = (state: BudgetState = initBudgetState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudget: any = normalize(action.payload, budgetSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudget.result),
                entities: _.merge({}, state.entities, newBudget.entities.Budget),
                lastUpdate: new Date(),
                selectedId: newBudget.result
            });

        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Budget: any = normalize(action.payload, arrayOfBudget);
            return updateObject({}, updateObject(state, {
                ids: Budget.result,
                entities: Budget.entities.Budget,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

        case AllActions.LOAD_ITEM_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const singleBudget: any = normalize(action.payload, arrayOfBudget);
            return updateObject({}, updateObject(state, {
                ids: Budget.result,
                entities: Budget.entities.Budget,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

        case AllActions.SELECT:
            return updateObject({}, updateObject(state, { selectedId: action.payload }));

        case AllActions.GET_WORKPROGRAM_STATUS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const status: string = action.payload.budgetStatus;
            return _.assign({}, state, { workProgramState: status });

        default:
            return state;
    }
};

export const getBudgetEntities = (state: BudgetState) => state.entities;
export const getBudgetIds = (state: BudgetState) => state.ids;
export const getSelectedBudgetId = (state: BudgetState) => state.selectedId;
export const getWorkProgramStatus = (state: BudgetState) => state.workProgramState;

export const getSelectedBudget = createSelector(getBudgetEntities, getSelectedBudgetId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudget;
    }
    return entities[selectedId];
});
