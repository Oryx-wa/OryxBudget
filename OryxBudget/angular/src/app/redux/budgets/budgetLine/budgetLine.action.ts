import { Action } from '@ngrx/store';
import { BudgetLine } from './budgetLine.interface';
import { type } from '../../utilities';


export const SEARCH = '[BudgetLine] Search';
export const SEARCH_COMPLETE = '[BudgetLine] Search Complete';
export const ADD_ITEM = '[BudgetLine] ADD_ITEM';
export const UPDATE_ITEM = '[BudgetLine] UPDATE_ITEM';
export const DELETE_ITEM = '[BudgetLine] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[BudgetLine] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[BudgetLine] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[BudgetLine] Load item';
export const LOAD_ITEMS = '[BudgetLine] Load items';
export const LOAD_ITEMS_SUCCESS = '[BudgetLine] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: BudgetLine[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: BudgetLine) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: BudgetLine) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: BudgetLine) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: BudgetLine) { }
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

    constructor(public payload: BudgetLine[]) { console.log(payload); }
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

