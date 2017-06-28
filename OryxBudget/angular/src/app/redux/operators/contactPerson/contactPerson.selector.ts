import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getContactPersonIds, getContactPersonEntities,
    ContactPersonState
} from './contactPerson.reducer';

// ContactPerson
/*
export const getContactPersonState = (state: AppState) => state.operators.contactPerson;
export const ContactPersonEntities = createSelector(getContactPersonState, getContactPersonEntities);
export const ContactPersonIds = createSelector(getContactPersonState, getContactPersonIds);
export const getContactPersonCollection = createSelector(ContactPersonEntities, ContactPersonIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
*/