import { Action } from '@ngrx/store';
import { Menu } from './../models';
import { type } from '../../utilities';
import {User} from './../models/user.model';




 export const   LOAD_MENU = '[Menu] Load';
 export const   LOAD_MENU_SUCCESS = '[Menu] Load Success';
 export const   INIT_MENU = '[Menu] Initialisation';
 export const   LOAD_DASHBOARD = '[Menu] Load Dashboards';
 export const   LOAD_DASHBOARD_SUCCESS = '[Menu] Load Dashboards Success';


export class LoadMenu implements Action {
 readonly type = LOAD_MENU;
  constructor(public payload: User) { }
}

export class LoadMenuSuccess implements Action {
 readonly type = LOAD_MENU_SUCCESS;
  constructor(public payload: Menu[]){ }
}

export class InitMenu implements Action {
 readonly type = INIT_MENU;
  constructor( ){ }
}



export type Actions
    = LoadMenu 
    | LoadMenuSuccess
    | InitMenu;

