import { Action } from '@ngrx/store';
import { Operator } from './operator.interface';
import { type } from '../../utilities';


export const SEARCH = '[Operator] Search';
export const SEARCH_COMPLETE = '[Operator] Search Complete';
export const ADD_ITEM = '[Operator] ADD_ITEM';
export const UPDATE_ITEM = '[Operator] UPDATE_ITEM';
export const DELETE_ITEM = '[Operator] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Operator] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Operator] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Operator] Load item';
export const LOAD_ITEMS = '[Operator] Load items';
export const LOAD_ITEMS_SUCCESS = '[Operator] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Operator[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Operator) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Operator) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Operator) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Operator) { }
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

    constructor(public payload: Operator[]){ }
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

