import { ActionReducer } from '@ngrx/store';
import { normalize } from 'normalizr/lib';
import { createSelector } from 'reselect';
import * as _ from 'lodash';

import * as AllActions from './notification.action';
import { Notification } from './notification.interface';
import {
    arrayOfNotification, NotificationEntity, notificationSchema, initNotification
} from './notification.model';
import { updateObject } from '../../utilities';

export interface INotificationState {
    ids: string[];
    entities: NotificationEntity;
    lastUpdate: Date;
    selectedId: string | null;
}

export const initNotificationState: INotificationState = {
    ids: [],
    entities: {},
    lastUpdate: new Date(),
    selectedId: null,
};

export const NotificationReducer: ActionReducer<INotificationState> = (state: INotificationState = initNotificationState,
    action: AllActions.Actions) => {
      switch (action.type) {
          case AllActions.ADD_UPDATE_ITEM_SUCCESS:
            const newNotification: any = normalize(action.payload, notificationSchema);

            return Object.assign({}, state, {
                ids: _.union(state.ids, newNotification.result),
                entities: _.merge({}, state.entities, newNotification.entities.notification),
                lastUpdate: new Date(),
                selectedId: newNotification.result
            });

          case AllActions.LOAD_ITEMS_SUCCESS:
            if (action.payload === null) {
                return state;
            }
            const notification: any = normalize(action.payload, arrayOfNotification);
            return updateObject({}, updateObject(state, {
                ids: notification.result,
                entities: notification.entities.Notification,
                lastUpdate: new Date(),
                selectedId: state.selectedId
            }));
          case AllActions.SELECT_ITEM:
            return updateObject({}, updateObject(state, { selectedId: action.payload }));
          default:
            return state;

      }
  }

  export const getNotificationEntities = (state: INotificationState) => state.entities;
  export const getNotificationId = (state: INotificationState) => state.ids;
  export const getSelectedNotificationId = (state: INotificationState) => state.selectedId;

  export const getSelectedNotification = createSelector(getNotificationEntities, getSelectedNotificationId, (entities, selectedId) => {
      if (selectedId === null) {
          return initNotification;
      }
      return entities[selectedId];
  });
