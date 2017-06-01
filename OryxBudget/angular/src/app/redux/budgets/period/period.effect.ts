import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { PeriodService } from './period.service';
import * as PeriodActions from './period.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class PeriodEffects implements OnDestroy {
    @Effect() LoadPeriods$: Observable<Action> = this.actions$
        .ofType(PeriodActions.LOAD_ITEMS)
        .mergeMap(action => this.periodService.getPeriods(action.payload)
            .mergeMap(periods => {
                return Observable.from([new PeriodActions.LoadItemsSuccessAction(periods)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Period Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(PeriodActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('Period saved Sucessfully'));

    @Effect() addPeriods$: Observable<Action> = this.actions$
        .ofType(PeriodActions.ADD_ITEM)
        .mergeMap(action => this.periodService.addPeriod(action.payload)
            .map(periods => new PeriodActions.AddUpdateItemSuccessAction(periods))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Period')]);
            }));

    @Effect() updatePeriods$: Observable<Action> = this.actions$
        .ofType(PeriodActions.UPDATE_ITEM)
        .mergeMap(action => this.periodService.updatePeriod(action.payload)
            .map(periods => new PeriodActions.AddUpdateItemSuccessAction(periods))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Period')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private periodService: PeriodService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
