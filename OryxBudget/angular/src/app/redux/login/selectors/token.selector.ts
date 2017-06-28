import { createSelector } from 'reselect';
import { AppState } from './../../';

import { getAccessToken, getAuthenticated, getRetUrl, getId} from './../reducers';

export const getToken = (state: AppState) => state.security.token;
export const accessToken = createSelector(getToken, getAccessToken);
export const authenticated = createSelector(getToken, getAuthenticated);
export const retUrl = createSelector(getToken, getRetUrl);
export const id = createSelector(getToken, getId);

