import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './budgetCodeView.action';
import { BudgetCodeView } from './budgetCodeView.interface';
import {
    arrayOfBudgetCodeView, BudgetCodeViewEntity,
    budgetCodeViewSchema, initBudgetCodeView
} from './budgetCodeView.model';

import { updateObject } from '../../utilities';

export interface BudgetCodeViewState {
    ids: string[];
    entities: BudgetCodeViewEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initBudgetCodeViewState: BudgetCodeViewState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const BudgetCodeViewReducer: ActionReducer<BudgetCodeViewState> = (state: BudgetCodeViewState = initBudgetCodeViewState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newBudgetCodeView: any = normalize(action.payload, budgetCodeViewSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newBudgetCodeView.result),
                entities: _.merge({}, state.entities, newBudgetCodeView.entities.BudgetCodeView),
                lastUpdate: new Date(),
                selectedId: newBudgetCodeView.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const BudgetCodeView: any = normalize(action.payload, arrayOfBudgetCodeView);
            return updateObject({}, updateObject(state, {
                ids: BudgetCodeView.result,
                entities: BudgetCodeView.entities.BudgetCodeView,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getBudgetCodeViewEntities = (state: BudgetCodeViewState) => state.entities;
export const getBudgetCodeViewIds = (state: BudgetCodeViewState) => state.ids;
export const getSelectedBudgetCodeViewId = (state: BudgetCodeViewState) => state.selectedId;

export const getSelectedBudgetCodeView = createSelector(getBudgetCodeViewEntities, getSelectedBudgetCodeViewId, (entities, selectedId) => {
    if (selectedId === null) {
        return initBudgetCodeView;
    }
    return entities[selectedId];
});
