import { Action } from '@ngrx/store';
import { BudgetCodeView } from './budgetCodeView.interface';
import { type } from '../../utilities';


export const SEARCH = '[BudgetCodeView] Search';
export const SEARCH_COMPLETE = '[BudgetCodeView] Search Complete';
export const ADD_ITEM = '[BudgetCodeView] ADD_ITEM';
export const UPDATE_ITEM = '[BudgetCodeView] UPDATE_ITEM';
export const DELETE_ITEM = '[BudgetCodeView] DELETE_ITEM';
export const ADD_UPDATE_ITEM_SUCCESS = '[BudgetCodeView] ADD_UPDATE_ITEM_SUCCESS';
export const DELETE_ITEM_SUCCESS = '[BudgetCodeView] DELETE_ITEM_SUCCESS';
export const LOAD_ITEM = '[BudgetCodeView] Load item';
export const LOAD_ITEMS = '[BudgetCodeView] Load items';
export const LOAD_ITEMS_SUCCESS = '[BudgetCodeView] LOAD_ITEMS_SUCCESS';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: BudgetCodeView[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: BudgetCodeView) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: BudgetCodeView) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: BudgetCodeView) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: BudgetCodeView) { }
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

    constructor(public payload: BudgetCodeView[]) { console.log(payload); }
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

