import { Action } from '@ngrx/store';
import { ContactPerson } from './contactPerson.interface';
import { type } from '../../utilities';


export const SEARCH = '[ContactPerson] Search';
export const SEARCH_COMPLETE = '[ContactPerson] Search Complete';
export const ADD_ITEM = '[ContactPerson] ADD_ITEM';
export const UPDATE_ITEM = '[ContactPerson] UPDATE_ITEM';
export const DELETE_ITEM = '[ContactPerson] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[ContactPerson] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[ContactPerson] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[ContactPerson] Load item';
export const LOAD_ITEMS = '[ContactPerson] Load items';
export const LOAD_ITEMS_SUCCESS = '[ContactPerson] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: ContactPerson[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: ContactPerson) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: ContactPerson) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: ContactPerson) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: ContactPerson) { }
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

    constructor(public payload: ContactPerson[]) { console.log(payload); }
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

