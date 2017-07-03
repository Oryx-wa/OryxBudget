import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getDept, getMalCom, getName, getNapims, getOperator,
    getSubCom, getTecCom, getLevel, getDisplay
} from './../reducers/index';

export const getUser = (state: AppState) => state.security.user;

export const dept = createSelector(getUser, getDept);
export const malCom = createSelector(getUser, getMalCom);
export const name = createSelector(getUser, getName);
export const napims = createSelector(getUser, getNapims);
export const operator = createSelector(getUser, getOperator);
export const subCom = createSelector(getUser, getSubCom);
export const tecCom = createSelector(getUser, getTecCom);
export const showLevel = createSelector(getUser, getLevel);
export const display = createSelector(getUser, getDisplay)


