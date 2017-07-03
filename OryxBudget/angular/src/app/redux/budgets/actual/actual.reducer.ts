import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './actual.action';
import { Actual } from './actual.interface';
import {
    arrayOfActual, ActualEntity,
    actualSchema, initActual
} from './actual.model';

import { updateObject } from '../../utilities';

export interface ActualState {
    ids: string[];
    entities: ActualEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initActualState: ActualState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const ActualReducer: ActionReducer<ActualState> = (state: ActualState = initActualState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newActual: any = normalize(action.payload, actualSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newActual.result),
                entities: _.merge({}, state.entities, newActual.entities.Actual),
                lastUpdate: new Date(),
                selectedId: newActual.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Actual: any = normalize(action.payload, arrayOfActual);
            console.log(Actual.entities.Actual);
            return updateObject({}, updateObject(state, {
                ids: Actual.result,
                entities: Actual.entities.Actual,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
        case AllActions.SELECT:
            return updateObject({}, updateObject(state, { selectedId: action.payload }));
        default:
            return state;

    }
};
export const getActualEntities = (state: ActualState) => state.entities;
export const getActualIds = (state: ActualState) => state.ids;
export const getSelectedActualId = (state: ActualState) => state.selectedId;

export const getSelectedActual = createSelector(getActualEntities, getSelectedActualId, (entities, selectedId) => {
    if (selectedId === null) {
        return initActual;
    }
    return entities[selectedId];
});
