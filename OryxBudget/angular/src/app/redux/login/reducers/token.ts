import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import { Action, ActionReducer } from '@ngrx/store';
import { UserModel } from '../models';
import { TokenActions } from '../actions';



export const TokenReducer: ActionReducer<UserModel.Token> = (state: UserModel.Token = UserModel.initToken,
  action: TokenActions.Actions) => {
  switch (action.type) {
    case TokenActions.SET_TOKEN:
      console.log(action.payload);
      return Object.assign({}, state, action.payload);
    case TokenActions.INIT_TOKEN:
      return UserModel.initToken;
    case TokenActions.GET_URL_SUCCESS:
      console.log(action.payload);

      return Object.assign({}, state, { retUrl: action.payload });
    case TokenActions.SET_URL:
      return Object.assign({}, state, { retUrl: action.payload });
    default:
      return state;
  }
};

export const getAuthenticated = (state: UserModel.Token) => state.authenticated;
export const getId = (state: UserModel.Token) => state.id;
export const getAccessToken = (state: UserModel.Token) => state.access;
export const getRetUrl = (state: UserModel.Token) => state.retUrl;


