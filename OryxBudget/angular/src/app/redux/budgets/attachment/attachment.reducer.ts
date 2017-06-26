import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './attachment.action';
import { Attachment } from './attachment.interface';
import {
    arrayOfAttachment, AttachmentEntity,
    attachmentSchema, initAttachment
} from './attachment.model';

import { updateObject } from '../../utilities';

export interface AttachmentState {
    ids: string[];
    entities: AttachmentEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initAttachmentState: AttachmentState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const AttachmentReducer: ActionReducer<AttachmentState> = (state: AttachmentState = initAttachmentState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newAttachment: any = normalize(action.payload, attachmentSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newAttachment.result),
                entities: _.merge({}, state.entities, newAttachment.entities.Attachment),
                lastUpdate: new Date(),
                selectedId: newAttachment.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Attachment: any = normalize(action.payload, arrayOfAttachment);
            return updateObject({}, updateObject(state, {
                ids: Attachment.result,
                entities: Attachment.entities.Attachment,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getAttachmentEntities = (state: AttachmentState) => state.entities;
export const getAttachmentIds = (state: AttachmentState) => state.ids;
export const getSelectedAttachmentId = (state: AttachmentState) => state.selectedId;

export const getSelectedAttachment = createSelector(getAttachmentEntities, getSelectedAttachmentId, (entities, selectedId) => {
    if (selectedId === null) {
        return initAttachment;
    }
    return entities[selectedId];
});
