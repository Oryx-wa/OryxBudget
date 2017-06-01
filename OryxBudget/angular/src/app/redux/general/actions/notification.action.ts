import { Action } from '@ngrx/store';



   export const SET_LOADING = 'Loading from Backend';
   export const SET_LOADED = 'Loaded from Backend Successfully';
   export const SET_SAVING = 'Saving to Backend';
   export const SET_SAVED = 'Saved Successfully';
   export const SET_LOADING_ERROR = 'Error Loading from Backend';
   export const SET_SAVING_ERROR = 'Error Saving from Backend';
   export const CLEAR_ALL = 'Cleal all notification';
   export const SET_MESSAGE = 'Notification Message';


export class SetLoading implements Action {
    readonly type = SET_LOADING;

    constructor(public payload: string) { }
}

export class SetLoaded implements Action {
    readonly type = SET_LOADED;

    constructor(public payload: string) { }
}

export class SetSaving implements Action {
    readonly type = SET_SAVING;

    constructor(public payload: string) { }
}

export class SetSaved implements Action {
    readonly type = SET_SAVED;

    constructor(public payload: string) { }
}

export class SetSavingError implements Action {
    readonly type = SET_SAVING_ERROR;

    constructor(public payload: string) { }
}

export class SetLoadingError implements Action {
    readonly type = SET_LOADING_ERROR;

    constructor(public payload: string) { }
}

export class ClearAll implements Action {
    readonly type = CLEAR_ALL;

    constructor(public payload: string) { }
}

export type Actions = SetLoaded | SetLoading | SetLoadingError |
    SetSaving | SetSaved | SetSavingError | ClearAll;
