import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './statusHistory.action';
import { StatusHistory } from './statusHistory.interface';
import {
    arrayOfStatusHistory, StatusHistoryEntity,
    statusHistorySchema, initStatusHistory
} from './statusHistory.model';

import { updateObject } from '../../utilities';

export interface StatusHistoryState {
    ids: string[];
    entities: StatusHistoryEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initStatusHistoryState: StatusHistoryState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
}
export const StatusHistoryReducer: ActionReducer<StatusHistoryState> = (state: StatusHistoryState = initStatusHistoryState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newStatusHistory: any = normalize(action.payload, statusHistorySchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newStatusHistory.result),
                entities: _.merge({}, state.entities, newStatusHistory.entities.StatusHistory),
                lastUpdate: new Date(),
                selectedId: newStatusHistory.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const StatusHistory: any = normalize(action.payload, arrayOfStatusHistory);
            return updateObject({}, updateObject(state, {
                ids: StatusHistory.result,
                entities: StatusHistory.entities.StatusHistory,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
}
export const getStatusHistoryEntities = (state: StatusHistoryState) => state.entities;
export const getStatusHistoryIds = (state: StatusHistoryState) => state.ids;
export const getSelectedStatusHistoryId = (state: StatusHistoryState) => state.selectedId;

export const getSelectedStatusHistory = createSelector(getStatusHistoryEntities, getSelectedStatusHistoryId, (entities, selectedId) => {
    if (selectedId === null) {
        return initStatusHistory;
    }
    return entities[selectedId];
});
