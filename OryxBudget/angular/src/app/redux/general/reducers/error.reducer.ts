import { ErrorActions } from './../actions';
import { ActionReducer } from '@ngrx/store';
import { updateObject } from './../../utilities/util';

export interface ErrorState {
  errors: any[];
}

export const initErrorState: ErrorState = {
  errors: []
};


export const errorsReducer: ActionReducer<ErrorState> = (state: ErrorState = initErrorState, action: ErrorActions.Actions) => {
  switch (action.type) {

    case ErrorActions.ADD_ERROR:
      // console.log(action.payload);
      let newError: any[] = [action.payload];

      return updateObject({}, updateObject(state, { errors: newError }));

    case ErrorActions.ADD_SAVING_ERROR:
      // console.log(action.payload);
      let newSavingError: any[] = [action.payload];

      return updateObject({}, updateObject(state, { errors: newSavingError }));

    case ErrorActions.ADD_LOADING_ERROR:
      // console.log(action.payload);
      let newLoadingError: any[] = [action.payload];

      return updateObject({}, updateObject(state, { errors: newLoadingError }));

    case ErrorActions.REMOVE_ERROR:
      return state;

    default:
      return state;
  }
};

