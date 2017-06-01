import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './category.action';
import { Category } from './category.interface';
import {
    arrayOfCategory, CategoryEntity,
    categorySchema, initCategory
} from './category.model';

import { updateObject } from '../../utilities';

export interface CategoryState {
    ids: string[];
    entities: CategoryEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initCategoryState: CategoryState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};
export const CategoryReducer: ActionReducer<CategoryState> = (state: CategoryState = initCategoryState,
    action: AllActions.Actions) => {
    switch (action.type) {
        case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newCategory: any = normalize(action.payload, categorySchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newCategory.result),
                entities: _.merge({}, state.entities, newCategory.entities.Category),
                lastUpdate: new Date(),
                selectedId: newCategory.result
            });
        case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const Category: any = normalize(action.payload, arrayOfCategory);
            return updateObject({}, updateObject(state, {
                ids: Category.result,
                entities: Category.entities.Category,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));

    }
};
export const getCategoryEntities = (state: CategoryState) => state.entities;
export const getCategoryIds = (state: CategoryState) => state.ids;
export const getSelectedCategoryId = (state: CategoryState) => state.selectedId;

export const getSelectedCategory = createSelector(getCategoryEntities, getSelectedCategoryId, (entities, selectedId) => {
    if (selectedId === null) {
        return initCategory;
    }
    return entities[selectedId];
});
