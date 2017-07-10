import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';
import * as _ from 'lodash';
import { Action, ActionReducer } from '@ngrx/store';
import { UserModel } from '../models';
import { LoginActions } from '../actions';




export const LoginReducer: ActionReducer<UserModel.User> =
  (state: UserModel.User = UserModel.initUser, action: LoginActions.Actions) => {
    switch (action.type) {
      case LoginActions.LOGIN:
        return state;
      case LoginActions.LOGIN_SUCCESS:
        const newUser: UserModel.User = _.assign({}, action.payload, setUser(action.payload.role));
        return newUser;
      case LoginActions.LOGOUT:
        return UserModel.initUser;
      case LoginActions.SELECT_OPERATOR:
        return _.assign({}, state, { operatorId: action.payload });
      case LoginActions.SELECT_DISPLAY:
        return _.assign({}, state, { display: action.payload });
      default:
        return state;
    }
  };

function setUser(roles: string[]) {

  let ret = {};
  roles.map(role => {
    switch (role) {
      case 'SubCom':
        ret = _.assign({}, ret, { showSubCom: true, showLevel: 1 });

        break;
      case 'TecCom':
        ret = _.assign({}, ret, { showTecCom: true, showLevel: 2 });
        break;
      case 'MalCom':
        ret = _.assign({}, ret, { showMalCom: true, showLevel: 3 });
        break;
      case 'Final':
        ret = _.assign({}, ret, { showFinalCom: true, showLevel: 3 });
        break;
      case 'Production':
        ret = _.assign({}, ret, { dept: 'Production' });

        break;
      case 'Exploration':
        ret = _.assign({}, ret, { dept: 'Exploration' });

        break;
      case 'Facilities':
        ret = _.assign({}, ret, { dept: 'Facilities' });
        break;
       case 'All':
        ret = _.assign({}, ret, { dept: 'All' });
        break;
      case 'Operator':
        ret = _.assign({}, ret, { operator: true });
        break;
      case 'NAPIMS':
        ret = _.assign({}, ret, { napims: true });
        break;
      default:
        break;
    }
  });

  return ret;
}

export const getDept = (state: UserModel.User) => state.dept;
export const getSubCom = (state: UserModel.User) => state.showSubCom;
export const getTecCom = (state: UserModel.User) => state.showTecCom;
export const getMalCom = (state: UserModel.User) => state.showMalCom;
export const getOperator = (state: UserModel.User) => state.operator;
export const getNapims = (state: UserModel.User) => state.napims;
export const getName = (state: UserModel.User) => state.full_name;
export const getLevel = (state: UserModel.User) => state.showLevel;
export const getDisplay = (state: UserModel.User) => state.display;
