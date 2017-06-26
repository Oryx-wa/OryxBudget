import { ActionReducer } from '@ngrx/store';
import * as NotificationActions from './../actions/notification.action';
import { updateObject } from './../../utilities/util';

import { StoreStatus, initStoreStatus } from './../../utilities/util';

export const notificationReducer: ActionReducer<StoreStatus> =
    (state: StoreStatus = initStoreStatus, action: NotificationActions.Actions) => {
        switch (action.type) {
            case NotificationActions.SET_LOADING:
                return updateObject({}, updateObject(state, {
                    loading: true, loaded: false, loadingError: false,
                    message: action.payload,
                    saving: false, saved: false, savingError: false,
                }));
            // tslint:disable-next-line:no-trailing-whitespace

            case NotificationActions.SET_LOADED:
                return updateObject({}, updateObject(state, {
                    loading: false, loaded: true, loadingError: false, message: action.payload,
                    saving: false, saved: false, savingError: false,
                }));
            // tslint:disable-next-line:no-trailing-whitespace

            case NotificationActions.SET_LOADING_ERROR:
                return updateObject({}, updateObject(state, {
                    loading: false, loaded: false, loadingError: true, message: action.payload,
                    saving: false, saved: false, savingError: false,
                }));

            case NotificationActions.SET_SAVING:
                return updateObject({}, updateObject(state, {
                    saving: true, saved: false, savingError: false, message: action.payload,
                    loading: false, loaded: false, loadingError: false
                }));

            case NotificationActions.SET_SAVED:
                return updateObject({}, updateObject(state, {
                    saving: false, saved: true, savingError: false, message: action.payload,
                    loading: false, loaded: false, loadingError: false
                }));

            case NotificationActions.SET_SAVING_ERROR:
                return updateObject({}, updateObject(state, {
                    saving: false, saved: false, savingError: true, message: action.payload,
                    loading: false, loaded: false, loadingError: false
                }));

            case NotificationActions.CLEAR_ALL:
                return initStoreStatus;
            default:
                return state;
        }
    };

export const getLoadingStatus = (state: StoreStatus) => state.loading;
export const getLoadedStatus = (state: StoreStatus) => state.loaded;
export const getLoadingErrorStatus = (state: StoreStatus) => state.loadingError;

export const getSavingStatus = (state: StoreStatus) => state.saving;
export const getSavedStatus = (state: StoreStatus) => state.saved;
export const getSavingErrorStatus = (state: StoreStatus) => state.savingError;

export const getMessage = (state: StoreStatus) => state.message;

