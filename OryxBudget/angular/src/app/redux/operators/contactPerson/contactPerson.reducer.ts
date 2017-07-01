import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './contactPerson.action';
import { ContactPerson } from './contactPerson.interface';
import {
    arrayOfContactPerson, ContactPersonEntity,
    contactPersonSchema, initContactPerson
} from './contactPerson.model';

import { updateObject } from '../../utilities';

export interface ContactPersonState {
    ids: string[];
    entities: ContactPersonEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initContactPersonState: ContactPersonState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const ContactPersonReducer: ActionReducer<ContactPersonState> = (state: ContactPersonState = initContactPersonState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newContactPerson: any = normalize(action.payload, contactPersonSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newContactPerson.result),
                entities: _.merge({}, state.entities, newContactPerson.entities.ContactPerson),
                lastUpdate: new Date(),
                selectedId: newContactPerson.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const ContactPerson: any = normalize(action.payload, arrayOfContactPerson);
            return updateObject({}, updateObject(state, {
                ids: ContactPerson.result,
                entities: ContactPerson.entities.ContactPerson,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
        default:
            return state;
    }
};
export const getContactPersonEntities = (state: ContactPersonState) => state.entities;
export const getContactPersonIds = (state: ContactPersonState) => state.ids;
export const getSelectedContactPersonId = (state: ContactPersonState) => state.selectedId;

export const getSelectedContactPerson = createSelector(getContactPersonEntities, getSelectedContactPersonId, (entities, selectedId) => {
    if (selectedId === null) {
        return initContactPerson;
    }
    return entities[selectedId];
});
