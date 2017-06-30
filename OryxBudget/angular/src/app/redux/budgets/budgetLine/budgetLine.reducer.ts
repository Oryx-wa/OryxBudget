import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budgetLine.action';
import { BudgetLines } from './budgetLine.interface';
import {
    arrayOfBudgetLine, BudgetLineEntity,
    budgetLineSchema, initBudgetLines
} from './budgetLine.model';

import { updateObject } from '../../utilities';

export interface BudgetLineState {
    ids: string[];
    entities: BudgetLineEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initBudgetLineState: BudgetLineState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const BudgetLineReducer: ActionReducer<BudgetLineState> = (state: BudgetLineState = initBudgetLineState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudgetLine: any = normalize(action.payload, budgetLineSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudgetLine.result),
                entities: _.merge({}, state.entities, newBudgetLine.entities.BudgetLine),
                lastUpdate: new Date(),
                selectedId: newBudgetLine.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const BudgetLine: any = normalize(action.payload, arrayOfBudgetLine);
           
            return updateObject({}, updateObject(state, {
                ids: BudgetLine.result,
                entities: BudgetLine.entities.BudgetLine,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
        case AllActions.SELECT:
            return updateObject({}, updateObject(state, { selectedId: action.payload }));
        default:
            return state;
    }
};
export const getBudgetLineEntities = (state: BudgetLineState) => state.entities;
export const getBudgetLineIds = (state: BudgetLineState) => state.ids;
export const getSelectedBudgetLineId = (state: BudgetLineState) => state.selectedId;

export const getSelectedBudgetLine = createSelector(getBudgetLineEntities, getSelectedBudgetLineId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudgetLines;
    }
    return entities[selectedId];
});
