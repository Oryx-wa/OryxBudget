import { Action } from '@ngrx/store';
import { BudgetCode } from './budgetCode.interface';
import { type } from '../../utilities';


export const SEARCH = '[BudgetCode] Search';
export const SEARCH_COMPLETE = '[BudgetCode] Search Complete';
export const ADD_ITEM = '[BudgetCode] ADD_ITEM';
export const UPDATE_ITEM = '[BudgetCode] UPDATE_ITEM';
export const DELETE_ITEM = '[BudgetCode] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[BudgetCode] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[BudgetCode] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[BudgetCode] Load item';
export const LOAD_ITEMS = '[BudgetCode] Load items';
export const LOAD_ITEMS_SUCCESS = '[BudgetCode] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: BudgetCode[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: BudgetCode) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: BudgetCode) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: BudgetCode) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: BudgetCode) { }
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

    constructor(public payload: BudgetCode[]) { console.log(payload); }
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

