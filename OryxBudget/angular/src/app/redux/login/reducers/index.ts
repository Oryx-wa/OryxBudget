import { combineReducers, ActionReducer } from '@ngrx/store';

export * from './login';
export * from './token';
export * from './menu';

import { LoginReducer } from './login';
import { TokenReducer } from './token';
import { MenuReducer } from './menu';
import { User, Token, Menu, initMenu, initToken, initUser } from '../models';
import * as DashboardReducer from './dashboard';
import { createSelector } from 'reselect';
import { AppState } from './../../';



const reducers = {
    token: TokenReducer,
    user: LoginReducer,
    menus: MenuReducer

}

export const SecurityReducer = combineReducers(reducers);

export interface LoginSTATE {
    user: User;
    token: Token;
    menus: Menu[];

}

export const initLoginState: LoginSTATE = {
    user: initUser,
    token: initToken,
    menus: initMenu
}


export const getMenus = (state: AppState) => state.security.menus;


// export const dept = createSelector(getUser,  )
