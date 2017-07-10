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
    initBudget, initActual, initBudgetLines, initLineComments, initLineStatus,
    initWorkProgramState, WorkProgramState, workProgramSchema, arrayOfWorkProgram

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
    printOut: any;
    workProgramStateIds: string[];
    workProgramStateEntities: { [id: string]: WorkProgramState; };

}

export const initBudgetState: BudgetState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
    workProgramState: null,
    printOut: null,
    workProgramStateIds: [],
    workProgramStateEntities: {}
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
        case AllActions.GET_PRINOUT_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            return _.assign({}, state, { printOut: action.payload });
        case AllActions.GET_BUDGET_ALL_WORKPROGRAM_STATUS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const wrk: any = normalize(action.payload, arrayOfWorkProgram);
            return _.assign({}, state, {
                workProgramStateIds: wrk.result,
                workProgramStateEntities: wrk.entities.WorkProgram,
                lastUpdate: new Date(),
            })
        default:
            return state;
    }
};

export const getBudgetEntities = (state: BudgetState) => state.entities;
export const getBudgetIds = (state: BudgetState) => state.ids;
export const getSelectedBudgetId = (state: BudgetState) => state.selectedId;
export const getWorkProgramStatus = (state: BudgetState) => state.workProgramState;
export const getPrintOut = (state: BudgetState) => state.printOut;
export const getAllWorkProgramStatusEntities = (state: BudgetState) => state.workProgramStateEntities;
export const getAllWorkProgramStatusIds = (state: BudgetState) => state.workProgramStateIds;


export const getSelectedBudget = createSelector(getBudgetEntities, getSelectedBudgetId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudget;
    }
    return entities[selectedId];
});

export const getWorkProgramStatusNumber = (state: BudgetState) => {
    let ret = 0;
    switch (state.workProgramState) {
        case 'Operator':
            ret = 0;
            break;
        case 'SubCom':
            ret = 1;
            break;
        case 'TecCom':
            ret = 2;
            break;
        case 'MalCom':
            ret = 3;
            break;
        case 'Final':
            ret = 4;
            break;
        default:
            ret = 0;
            break;
    }
    return ret;
}


