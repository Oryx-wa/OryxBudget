import { Action } from '@ngrx/store';
import { Budget } from './budget.interface';
import { type } from '../../utilities';


export const SEARCH = '[Budget] Search';
export const SEARCH_COMPLETE = '[Budget] Search Complete';
export const ADD_ITEM = '[Budget] ADD_ITEM';
export const UPDATE_ITEM = '[Budget] UPDATE_ITEM';
export const DELETE_ITEM = '[Budget] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[Budget] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[Budget] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[Budget] Load item';
export const LOAD_ITEMS = '[Budget] Load items';
export const LOAD_ITEMS_SUCCESS = '[Budget] LOAD_ITEMS_SUCCESS';
export const LOAD_ITEM_SUCCESS = '[Budget] LOAD_ITEM_SUCCESS';
export const SELECT = '[Budget] Select Item';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: Budget[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: Budget) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: Budget) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: Budget) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: Budget) { }
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

    constructor(public payload: Budget[]) { }
}

export class LoadItemSuccessAction implements Action {
    readonly type = LOAD_ITEM_SUCCESS;

    constructor(public payload: string) {  }
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
    | LoadItemAction
    | LoadItemSuccessAction
    | SelectItemAction;

