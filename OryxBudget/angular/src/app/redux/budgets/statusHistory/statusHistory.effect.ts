import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { StatusHistoryService } from './statusHistory.service';
import * as StatusHistoryActions from './statusHistory.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class StatusHistoryEffects implements OnDestroy {
    @Effect() LoadStatusHistorys$: Observable<Action> = this.actions$
        .ofType(StatusHistoryActions.LOAD_ITEMS)
        .mergeMap(action => this.statusHistoryService.getStatusHistorys(action.payload)
            .mergeMap(statusHistorys => {
                return Observable.from([new StatusHistoryActions.LoadItemsSuccessAction(statusHistorys)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('StatusHistory Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(StatusHistoryActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('StatusHistory saved Sucessfully'));

    @Effect() addStatusHistorys$: Observable<Action> = this.actions$
        .ofType(StatusHistoryActions.ADD_ITEM)
        .mergeMap(action => this.statusHistoryService.addStatusHistory(action.payload)
            .map(statusHistorys => new StatusHistoryActions.AddUpdateItemSuccessAction(statusHistorys))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving StatusHistory')]);
            }));

    @Effect() updateStatusHistorys$: Observable<Action> = this.actions$
        .ofType(StatusHistoryActions.UPDATE_ITEM)
        .mergeMap(action => this.statusHistoryService.updateStatusHistory(action.payload)
            .map(statusHistorys => new StatusHistoryActions.AddUpdateItemSuccessAction(statusHistorys))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving StatusHistory')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private statusHistoryService: StatusHistoryService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
