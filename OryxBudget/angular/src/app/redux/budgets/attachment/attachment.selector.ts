import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getAttachmentIds, getAttachmentEntities,
    AttachmentState
} from './attachment.reducer';

// Attachment

export const getAttachmentState = (state: AppState) => state.budgets.attachment;
export const AttachmentEntities = createSelector(getAttachmentState, getAttachmentEntities);
export const AttachmentIds = createSelector(getAttachmentState, getAttachmentIds);
export const getAttachmentCollection = createSelector(AttachmentEntities, AttachmentIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
