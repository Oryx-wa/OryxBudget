import { Action } from '@ngrx/store';



export const  ADD_ERROR = 'Add Error';
export const  REMOVE_ERROR = 'Remove Error';
export const  RESET_ERROR = 'Reset Error';
export const  ADD_LOADING_ERROR = '[Error] Loading Error';
export const  ADD_SAVING_ERROR = '[Error] Saving Error';


export class ErrorAddAction implements Action {
  readonly type = ADD_ERROR;

  constructor(public payload: any) { }
}

export class ErrorRemoveAction implements Action {
  readonly type = REMOVE_ERROR;
  constructor(public payload: number) { }
}

export class ErrorRessetAction implements Action {
  readonly type = RESET_ERROR;
  constructor( public payload: '') { }
}

export class ErrorAddLoadingAction implements Action {
  readonly type = ADD_LOADING_ERROR;

  constructor(public payload: any) { }
}

export class ErrorAddSavingAction implements Action {
  readonly type = ADD_SAVING_ERROR;

  constructor(public payload: any) { }
}


export type error = {
  index: number,
  error: string
}

export type Actions = ErrorAddAction | ErrorRemoveAction | ErrorRessetAction | ErrorAddLoadingAction | ErrorAddSavingAction;

