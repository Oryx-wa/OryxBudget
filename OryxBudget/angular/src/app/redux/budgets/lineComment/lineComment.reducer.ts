import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './lineComment.action';
import { LineComment } from './lineComment.interface';
import {
    arrayOfLineComment, LineCommentEntity,
    lineCommentSchema, initLineComment
} from './lineComment.model';

import { updateObject } from '../../utilities';

export interface LineCommentState {
    ids: string[];
    entities: LineCommentEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initLineCommentState: LineCommentState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const LineCommentReducer: ActionReducer<LineCommentState> = (state: LineCommentState = initLineCommentState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newLineComment: any = normalize(action.payload, lineCommentSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newLineComment.result),
                entities: _.merge({}, state.entities, newLineComment.entities.LineComment),
                lastUpdate: new Date(),
                selectedId: newLineComment.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const LineComment: any = normalize(action.payload, arrayOfLineComment);
            return updateObject({}, updateObject(state, {
                ids: LineComment.result,
                entities: LineComment.entities.LineComment,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
        case AllActions.SELECT_ITEM:
            return updateObject({}, updateObject(state, { selectedId: action.payload }));
        default:
            return state;
    }
};
export const getLineCommentEntities = (state: LineCommentState) => state.entities;
export const getLineCommentIds = (state: LineCommentState) => state.ids;
export const getSelectedLineCommentId = (state: LineCommentState) => state.selectedId;

export const getSelectedLineComment = createSelector(getLineCommentEntities, getSelectedLineCommentId, (entities, selectedId) => {
    if (selectedId === null) {
        return initLineComment;
    }
    return entities[selectedId];
});
