import { compose } from '@ngrx/core/compose';
import { combineReducers, ActionReducer } from '@ngrx/store';
import { storeFreeze } from 'ngrx-store-freeze';
import { environment } from '../../environments/environment';

import { StoreStatus } from './utilities/util';


import { SecurityReducer, LoginSTATE } from './login/reducers';



import * as fromBudget from './budgets';
import * as fromOperator from './operators';
import * as General from './general';
import * as fromLogin from './login';






export * from './budgets';
export * from './operators';
export * from './general';
export * from './utilities';
export * from './login';




export interface AppState {
  budgets: fromBudget.BdState;
  security: fromLogin.LoginSTATE;
  operators: fromOperator.OperatorsState;
  // errors: General.ErrorState;
  // storestatus: StoreStatus;

}

const reducers = {
  budgets: fromBudget.bdReducer,
  security: fromLogin.SecurityReducer,
  operators: fromOperator.OperatorsReducer,
  // errors: General.errorsReducer,
  //  storestatus: General.notificationReducer,
};

const developmentReducer: ActionReducer<AppState> = compose(storeFreeze, combineReducers)(reducers);
const productionReducer: ActionReducer<AppState> = combineReducers(reducers);

// const developmentReducer: ActionReducer<AppState> = reducers;
// const productionReducer: ActionReducer<AppState> = combineReducers(reducers);

export function reducer(state: any, action: any) {

  if (environment.production) {
    return productionReducer(state, action);
  } else {
    return developmentReducer(state, action);
  }

}

export function initialState() {
  const ret = {
    budgets: fromBudget.initBdState,
    security: fromLogin.initLoginState
  };
  console.log(ret);
  return ret;
}

export interface Lookup {
  id: string;
  name: string;
}




/**
 * Every reducer module exports selector functions, however child reducers
 * have no knowledge of the overall state tree. To make them useable, we
 * need to make new selectors that wrap them.
 *
 * Once again our compose function comes in handy. From right to left, we
 * first select the books state then we pass the state to the book
 * reducer's getBooks selector, finally returning an observable
 * of search results.
 *
 * Share memoizes the selector functions and publishes the result. This means
 * every time you call the selector, you will get back the same result
 * observable. Each subscription to the resultant observable
 * is shared across all subscribers.
 */

