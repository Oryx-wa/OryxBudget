import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budgetCode.action';
import { BudgetCode } from './budgetCode.interface';
import {
    arrayOfBudgetCode, BudgetCodeEntity,
    budgetCodeSchema, initBudgetCode
} from './budgetCode.model';

import { updateObject } from '../../utilities';

export interface BudgetCodeState {
    ids: string[];
    entities: BudgetCodeEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initBudgetCodeState: BudgetCodeState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const BudgetCodeReducer: ActionReducer<BudgetCodeState> = (state: BudgetCodeState = initBudgetCodeState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudgetCode: any = normalize(action.payload, budgetCodeSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudgetCode.result),
                entities: _.merge({}, state.entities, newBudgetCode.entities.BudgetCode),
                lastUpdate: new Date(),
                selectedId: newBudgetCode.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const BudgetCode: any = normalize(action.payload, arrayOfBudgetCode);
            return updateObject({}, updateObject(state, {
                ids: BudgetCode.result,
                entities: BudgetCode.entities.BudgetCode,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getBudgetCodeEntities = (state: BudgetCodeState) => state.entities;
export const getBudgetCodeIds = (state: BudgetCodeState) => state.ids;
export const getSelectedBudgetCodeId = (state: BudgetCodeState) => state.selectedId;

export const getSelectedBudgetCode = createSelector(getBudgetCodeEntities, getSelectedBudgetCodeId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudgetCode;
    }
    return entities[selectedId];
});
