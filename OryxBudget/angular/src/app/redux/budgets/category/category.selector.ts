import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getCategoryIds, getCategoryEntities,
    CategoryState
} from './category.reducer';

// Category

export const getCategoryState = (state: AppState) => state.budgets.category;
export const CategoryEntities = createSelector(getCategoryState, getCategoryEntities);
export const CategoryIds = createSelector(getCategoryState, getCategoryIds);
export const getCategoryCollection = createSelector(CategoryEntities, CategoryIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
