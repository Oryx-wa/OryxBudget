import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getLineCommentIds, getLineCommentEntities,
    LineCommentState
} from './lineComment.reducer';

// LineComment
/*
 export const getLineCommentState = (state: AppState) => state.budgets.;
export const LineCommentEntities = createSelector(getLineCommentState, getLineCommentEntities);
export const LineCommentIds = createSelector(getLineCommentState, getLineCommentIds);
export const getLineCommentCollection = createSelector(LineCommentEntities, LineCommentIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
*/