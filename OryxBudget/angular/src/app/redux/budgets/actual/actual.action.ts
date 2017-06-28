import { Action } from '@ngrx/store';
import { Actual } from './actual.interface';
import { type } from '../../utilities';


export const SEARCH = '[Actual] Search';
export const SEARCH_COMPLETE = '[Actual] Search Complete';
export const ADD_ITEM = '[Actual] ADD_ITEM';
export const UPDATE_ITEM = '[Actual] UPDATE_ITEM';
export const DELETE_ITEM = '[Actual] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Actual] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Actual] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Actual] Load item';
export const LOAD_ITEMS = '[Actual] Load items';
export const LOAD_ITEMS_SUCCESS = '[Actual] LOAD_ITEMS_SUCCESS';
export const LOAD_ITEM_SUCCESS = '[Actual] LOAD_ITEM_SUCCESS';
export const SELECT = '[Actual] Select Item';

export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Actual[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Actual) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Actual) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Actual) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Actual) { }
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

    constructor(public payload: Actual[]) { console.log(payload); }
}

export class LoadItemSuccessAction implements Action {
    readonly type = LOAD_ITEM_SUCCESS;

    constructor(public payload: any) { console.log(payload); }
}

export class SelectItemAction implements Action {
    readonly type = SELECT;

    constructor(public payload: string) { }
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
    | UpdateItemAction
    | LoadItemSuccessAction
    | SelectItemAction;

