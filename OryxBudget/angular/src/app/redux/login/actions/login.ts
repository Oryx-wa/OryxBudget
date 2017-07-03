import { Action } from '@ngrx/store';
import { User } from './../models';
import { type } from '../../utilities';
/**
 * Instead of passing around action string constants and manually recreating
 * action objects at the point of dispatch, we create services encapsulating
 * each appropriate action group. Action types are included as static
 * members and kept next to their action creator. This promotes a
 * uniform interface and single import for appropriate actions
 * within your application components.
 */


export const LOGIN = '[login] Start';
export const LOGIN_SUCCESS = '[login] Complete';
export const LOGOUT = '[logout] Complet';
export const SELECT_OPERATOR = '[login] Napims select operator';
export const SELECT_DISPLAY = '[login] Select display';


export class LoginAction implements Action {
  readonly type = LOGIN;

}

export class LogOutAction implements Action {
  readonly type = LOGOUT;
  constructor(public payload: User) { }
}


export class LoginSuccessAction implements Action {
  readonly type = LOGIN_SUCCESS;
  constructor(public payload: User) { }
}

export class SelectOperatorAction implements Action {
  readonly type = SELECT_OPERATOR;
  constructor(public payload: string) { }
}

export class SelectDisplay implements Action {
  readonly type = SELECT_DISPLAY;
  constructor(public payload: string) { }
}

export type Actions =
  LoginAction | LogOutAction |
  LoginSuccessAction | SelectOperatorAction |
  SelectDisplay;
