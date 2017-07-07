import { Action } from '@ngrx/store';
import { BudgetLines } from './budgetLine.interface';
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
export const LOAD_ITEM_SUCCESS = '[BudgetLine] LOAD_ITEM_SUCCESS';
export const SELECT = '[BudgetLine] Select Item';
export const RESET = '[BudgetLine] Reset';
export const UPDATE_STATUS = '[BudgetLine] Update Status';
export const UPDATE_STATUS_VALUE = '[BudgetLine] Update Status with value';
export const RESET_APPROVAL_UPDATES = '[BudgetLine] Reset approval updates';
export const SAVE_APPROVAL_UPDATES = '[BudgetLine] Save approval updates';
export const SAVE_APPROVAL_UPDATES_SUCCESS = '[BudgetLine] Save approval updates success';
export const SIGN_OFF = '[Budget Line] Sign off';
export const SIGN_OFF_SUCCESS = '[Budget Line] Sign Off Success';
export const FILTER = '[Budget Line] filtered';


export class SearchAction implements Action {
    readonly type = SEARCH;
    constructor(public payload: string) { }
}

export class SearchCompleteAction implements Action {
    readonly type = SEARCH_COMPLETE;
    constructor(public payload: BudgetLines[]) { }
}

export class AddItemAction implements Action {
    readonly type = ADD_ITEM;
    constructor(public payload: BudgetLines) { }
}

export class UpdateItemAction implements Action {
    readonly type = UPDATE_ITEM;
    constructor(public payload: BudgetLines) { }
}

export class DeleteItemAction implements Action {
    readonly type = DELETE_ITEM;
    constructor(public payload: BudgetLines) { }
}

export class AddUpdateItemSuccessAction implements Action {
    readonly type = ADD_UPDATE_ITEM_SUCCESS;
    constructor(public payload: BudgetLines) { }
}

export class LoadItemAction implements Action {
    readonly type = LOAD_ITEM;
    constructor(public payload: any) { }
}

export class DeleteItemSuccessAction implements Action {
    readonly type = DELETE_ITEM_SUCCESS;
    constructor(public payload: number) { }
}

export class LoadItemsAction implements Action {
    readonly type = LOAD_ITEMS;
    constructor(public payload: string) { console.log(payload) }
}

export class LoadItemsSuccessAction implements Action {
    readonly type = LOAD_ITEMS_SUCCESS;

    constructor(public payload: BudgetLines[]) { console.log(payload); }
}
export class LoadItemSuccessAction implements Action {
    readonly type = LOAD_ITEM_SUCCESS;

    constructor(public payload: any) { console.log(payload); }
}

export class SelectItemAction implements Action {
    readonly type = SELECT;

    constructor(public payload: string) { }
}

export class ResetAction implements Action {
    readonly type = RESET;
    constructor(public payload = '') { }
}

export class UpdateStatusAction implements Action {
    readonly type = UPDATE_STATUS;
    constructor(public payload: { code: string, status: number }) { }
}

export class UpdateStatusValueAction implements Action {
    readonly type = UPDATE_STATUS_VALUE;
    constructor(public payload: BudgetLines) { console.log(payload) }
}

export class ResetApprovalUpdateAction implements Action {
    readonly type = RESET_APPROVAL_UPDATES;
    constructor(public payload = '') { }
}

export class SaveApprovalUpdates implements Action {
    readonly type = SAVE_APPROVAL_UPDATES;
    constructor(public payload = '') { }
}



export class SignOffAction implements Action {
    readonly type = SIGN_OFF;
    constructor(public payload = '') { }
}
export class SignOffSuccessAction implements Action {
    readonly type = SIGN_OFF_SUCCESS;
    constructor(public payload = '') { }
}

export class FilterAction implements Action {
    readonly type = FILTER;
    constructor(public payload: boolean) { }
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
    | LoadItemSuccessAction
    | SelectItemAction
    | ResetAction
    | UpdateStatusAction
    | UpdateStatusValueAction
    | ResetApprovalUpdateAction
    | SaveApprovalUpdates
    | SignOffAction
    | SignOffSuccessAction
    | FilterAction;

