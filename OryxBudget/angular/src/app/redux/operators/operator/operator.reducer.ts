import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './operator.action';
import { Operator } from './operator.interface';
import {
    arrayOfOperator, OperatorEntity,
    operatorSchema, initOperator
} from './operator.model';

import { updateObject } from '../../utilities';

export interface OperatorState {
    ids: string[];
    entities: OperatorEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initOperatorState: OperatorState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const OperatorReducer: ActionReducer<OperatorState> = (state: OperatorState = initOperatorState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newOperator: any = normalize(action.payload, operatorSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newOperator.result),
                entities: _.merge({}, state.entities, newOperator.entities.Operator),
                lastUpdate: new Date(),
                selectedId: newOperator.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Operator: any = normalize(action.payload, arrayOfOperator);
            return updateObject({}, updateObject(state, {
                ids: Operator.result,
                entities: Operator.entities.Operator,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
        default:
            return state;
    }
};
export const getOperatorEntities = (state: OperatorState) => state.entities;
export const getOperatorIds = (state: OperatorState) => state.ids;
export const getSelectedOperatorId = (state: OperatorState) => state.selectedId;

export const getSelectedOperator = createSelector(getOperatorEntities, getSelectedOperatorId, (entities, selectedId) => {
    if (selectedId === null) {
        return initOperator;
    }
    return entities[selectedId];
});
