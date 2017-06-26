import { Action } from '@ngrx/store';
import { BudgetRun } from './budgetRun.interface';
import { type } from '../../utilities';


export const SEARCH = '[BudgetRun] Search';
export const SEARCH_COMPLETE = '[BudgetRun] Search Complete';
export const ADD_ITEM = '[BudgetRun] ADD_ITEM';
export const UPDATE_ITEM = '[BudgetRun] UPDATE_ITEM';
export const DELETE_ITEM = '[BudgetRun] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[BudgetRun] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[BudgetRun] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[BudgetRun] Load item';
export const LOAD_ITEMS = '[BudgetRun] Load items';
export const LOAD_ITEMS_SUCCESS = '[BudgetRun] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: BudgetRun[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: BudgetRun) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: BudgetRun) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: BudgetRun) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: BudgetRun) { }
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

    constructor(public payload: BudgetRun[]) { console.log(payload); }
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

