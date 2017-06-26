import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './period.action';
import { Period } from './period.interface';
import {
    arrayOfPeriod, PeriodEntity,
    periodSchema, initPeriod
} from './period.model';

import { updateObject } from '../../utilities';

export interface PeriodState {
    ids: string[];
    entities: PeriodEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initPeriodState: PeriodState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const PeriodReducer: ActionReducer<PeriodState> = (state: PeriodState = initPeriodState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newPeriod: any = normalize(action.payload, periodSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newPeriod.result),
                entities: _.merge({}, state.entities, newPeriod.entities.Period),
                lastUpdate: new Date(),
                selectedId: newPeriod.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Period: any = normalize(action.payload, arrayOfPeriod);
            return updateObject({}, updateObject(state, {
                ids: Period.result,
                entities: Period.entities.Period,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getPeriodEntities = (state: PeriodState) => state.entities;
export const getPeriodIds = (state: PeriodState) => state.ids;
export const getSelectedPeriodId = (state: PeriodState) => state.selectedId;

export const getSelectedPeriod = createSelector(getPeriodEntities, getSelectedPeriodId, (entities, selectedId) => {
    if (selectedId === null) {
        return initPeriod;
    }
    return entities[selectedId];
});
