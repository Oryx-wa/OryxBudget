import { Action } from '@ngrx/store';
import { Attachment } from './attachment.interface';
import { type } from '../../utilities';


export const SEARCH = '[Attachment] Search';
export const SEARCH_COMPLETE = '[Attachment] Search Complete';
export const ADD_ITEM = '[Attachment] ADD_ITEM';
export const UPDATE_ITEM = '[Attachment] UPDATE_ITEM';
export const DELETE_ITEM = '[Attachment] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Attachment] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Attachment] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Attachment] Load item';
export const LOAD_ITEMS = '[Attachment] Load items';
export const LOAD_ITEMS_SUCCESS = '[Attachment] LOAD_ITEMS_SUCCESS';

export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Attachment[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Attachment) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Attachment) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Attachment) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Attachment) { }
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

    constructor(public payload: Attachment[]) { console.log(payload); }
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

