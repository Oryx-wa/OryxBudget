import { Action } from '@ngrx/store';
import { Category } from './category.interface';
import { type } from '../../utilities';


export const SEARCH = '[Category] Search';
export const SEARCH_COMPLETE = '[Category] Search Complete';
export const ADD_ITEM = '[Category] ADD_ITEM';
export const UPDATE_ITEM = '[Category] UPDATE_ITEM';
export const DELETE_ITEM = '[Category] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Category] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Category] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Category] Load item';
export const LOAD_ITEMS = '[Category] Load items';
export const LOAD_ITEMS_SUCCESS = '[Category] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Category[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Category) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Category) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Category) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Category) { }
}

export class LoadItemAction implements Action {
    readonly type = LOAD_ITEM;
    constructor(public payload: number) { }
}

export class DeleteItemSuccessAction implements Action {
    readonly type = DELETE_ITEM_SUCCESS;
    constructor(public payload: number) { }
}

export class LoadItemsAction implements Action {
    readonly type = LOAD_ITEMS;
    constructor(public payload: '') { }
}

export class LoadItemsSuccessAction implements Action {
    readonly type = LOAD_ITEMS_SUCCESS;

    constructor(public payload: Category[]) { console.log(payload); }
}


export type Actions
    = SearchAction
    | SearchCompleteAction
    | LoadItemAction
    | LoadItemsAction
    | LoadItemsSuccessAction
    | DeleteItemAction
    | AddItemAction
    | AddUpdateItemSuccessAction
    | DeleteItemSuccessAction
    | UpdateItemAction;

