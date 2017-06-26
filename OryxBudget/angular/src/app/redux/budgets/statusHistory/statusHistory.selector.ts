import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getStatusHistoryIds, getStatusHistoryEntities,
    StatusHistoryState
} from './statusHistory.reducer';

// StatusHistory

export const getStatusHistoryState = (state: AppState) => state.budgets.statusHistory;
export const StatusHistoryEntities = createSelector(getStatusHistoryState, getStatusHistoryEntities);
export const StatusHistoryIds = createSelector(getStatusHistoryState, getStatusHistoryIds);
export const getStatusHistoryCollection = createSelector(StatusHistoryEntities, StatusHistoryIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
