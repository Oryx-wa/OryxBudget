import { Action } from '@ngrx/store';
import { StatusHistory } from './statusHistory.interface';
import { type } from '../../utilities';


export const SEARCH = '[StatusHistory] Search';
export const SEARCH_COMPLETE = '[StatusHistory] Search Complete';
export const ADD_ITEM = '[StatusHistory] ADD_ITEM';
export const UPDATE_ITEM = '[StatusHistory] UPDATE_ITEM';
export const DELETE_ITEM = '[StatusHistory] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[StatusHistory] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[StatusHistory] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[StatusHistory] Load item';
export const LOAD_ITEMS = '[StatusHistory] Load items';
export const LOAD_ITEMS_SUCCESS = '[StatusHistory] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: StatusHistory[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: StatusHistory) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: StatusHistory) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: StatusHistory) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: StatusHistory) { }
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

    constructor(public payload: StatusHistory[]) { console.log(payload); }
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

