import { Action } from '@ngrx/store';
import { Notification } from './notification.interface';
import { type } from '../../utilities';

export const SEARCH = '[Notification] Search';
export const SEARCH_COMPLETE = '[Notification] Search Complete';
export const ADD_ITEM = '[Notification] ADD_ITEM';
export const UPDATE_ITEM = '[Notification] UPDATE_ITEM';
export const DELETE_ITEM = '[Notification] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Notification] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Notification] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Notification] Load item';
export const LOAD_ITEMS = '[Notification] Load items';
export const LOAD_ITEMS_SUCCESS = '[Notification] LOAD_ITEMS_SUCCESS';
export const SELECT_ITEM = '[Notification] Select Item';

export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Notification[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Notification) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Notification) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Notification) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Notification) { }
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

    constructor(public payload: Notification[]) { console.log(payload); }
}

export class SelectItemAction implements Action {
    readonly type = SELECT_ITEM;
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
    | SelectItemAction;
