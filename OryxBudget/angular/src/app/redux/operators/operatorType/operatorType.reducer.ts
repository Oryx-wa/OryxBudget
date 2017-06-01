import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './operatorType.action';
import { OperatorType } from './operatorType.interface';
import {
    arrayOfOperatorType, OperatorTypeEntity,
    operatorTypeSchema, initOperatorType
} from './operatorType.model';

import { updateObject } from '../../utilities';

export interface OperatorTypeState {
    ids: string[];
    entities: OperatorTypeEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initOperatorTypeState: OperatorTypeState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const OperatorTypeReducer: ActionReducer<OperatorTypeState> = (state: OperatorTypeState = initOperatorTypeState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newOperatorType: any = normalize(action.payload, operatorTypeSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newOperatorType.result),
                entities: _.merge({}, state.entities, newOperatorType.entities.OperatorType),
                lastUpdate: new Date(),
                selectedId: newOperatorType.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const OperatorType: any = normalize(action.payload, arrayOfOperatorType);
            return updateObject({}, updateObject(state, {
                ids: OperatorType.result,
                entities: OperatorType.entities.OperatorType,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getOperatorTypeEntities = (state: OperatorTypeState) => state.entities;
export const getOperatorTypeIds = (state: OperatorTypeState) => state.ids;
export const getSelectedOperatorTypeId = (state: OperatorTypeState) => state.selectedId;

export const getSelectedOperatorType = createSelector(getOperatorTypeEntities, getSelectedOperatorTypeId, (entities, selectedId) => {
    if (selectedId === null) {
        return initOperatorType;
    }
    return entities[selectedId];
});
