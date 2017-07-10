import * as fromRoot from './../../';
import { createSelector } from 'reselect';

import { AppState } from './../../';

import {
    getNotificationId, getNotificationEntities,
    INotificationState, getSelectedNotification
} from './notification.reducer';

export const getNotificationState = (state: AppState) => state.budgets.notification;
export const NotificationEntities = createSelector(getNotificationState, getNotificationEntities);
export const NotificationIds = createSelector(getNotificationState, getNotificationId);
export const getNotificationCollection = createSelector(NotificationEntities, NotificationIds, (entities, ids) => {
    return ids.map(id => entities[id]);
});
export const SelectedNotification = (state: AppState) => createSelector(getNotificationState, getSelectedNotification)
