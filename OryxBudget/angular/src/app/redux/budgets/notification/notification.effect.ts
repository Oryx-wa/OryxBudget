import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { NotificationService } from './notification.service';
import * as CommentNotificationActions from './notification.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';
import { NotificationSelector } from './../notification';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';


@Injectable()
export class NotificationEffects implements OnDestroy {


  @Effect() LoadNotifications$: Observable<Action> = this.actions$
      .ofType(CommentNotificationActions.LOAD_ITEMS)
      .withLatestFrom(this.store$.select(state => state.security.user))
      .map(([action, user]) => {
          const resp = { operatorId: user.operatorId, workProgram: user.dept };
          return resp;
      })
      .mergeMap(payload => this.notificationService.getAllUnreadNotifications(payload.operatorId, payload.workProgram)
          .mergeMap(notifications => {
                return Observable.from([new CommentNotificationActions.LoadItemsSuccessAction(notifications)]);
            })
          .catch(err => {
              return Observable.from([new ErrorActions.ErrorAddAction(err),
              new NotificationActions.SetLoaded('Unread notifications loaded.')]);
          }));

  @Effect() AddNotification$: Observable<Action> = this.actions$
    .ofType(CommentNotificationActions.ADD_ITEM)
    .mergeMap(action => this.notificationService.addNotification(action.payload)
        .map(notifications => new CommentNotificationActions.AddUpdateItemSuccessAction(notifications))
        .catch(err => {
            return Observable.from([new ErrorActions.ErrorAddAction(err),
            new NotificationActions.SetSavingError('Error saving Notification')]);
        }));

  constructor(
        private actions$: Actions,
        private store$: Store<AppState>,
        private notificationService: NotificationService
    ) { }

  ngOnDestroy() {
      console.log('ngOnDestroy');
  }
}
