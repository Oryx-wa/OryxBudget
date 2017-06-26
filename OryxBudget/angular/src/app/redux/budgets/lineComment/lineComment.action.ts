import { Action } from '@ngrx/store';
import { LineComment } from './lineComment.interface';
import { type } from '../../utilities';


export const SEARCH = '[LineComment] Search';
export const SEARCH_COMPLETE = '[LineComment] Search Complete';
export const ADD_ITEM = '[LineComment] ADD_ITEM';
export const UPDATE_ITEM = '[LineComment] UPDATE_ITEM';
export const DELETE_ITEM = '[LineComment] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[LineComment] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[LineComment] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[LineComment] Load item';
export const LOAD_ITEMS = '[LineComment] Load items';
export const LOAD_ITEMS_SUCCESS = '[LineComment] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: LineComment[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: LineComment) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: LineComment) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: LineComment) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: LineComment) { }
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

    constructor(public payload: LineComment[]) { console.log(payload); }
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

