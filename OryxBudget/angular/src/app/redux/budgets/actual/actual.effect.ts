import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { ActualService } from './actual.service';
import * as ActualActions from './actual.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class ActualEffects implements OnDestroy {

    @Effect() LoadActuals$: Observable<Action> = this.actions$
        .ofType(ActualActions.LOAD_ITEMS)
        .withLatestFrom(this.store$.select(state => state.security.user))
        .map(([action, user]) => {
            
            const ret = { dept: user.dept, budgetId: action.payload };
            return ret;
        })
        .mergeMap(payload => this.actualService.getActuals(payload.budgetId, payload.dept)
            .mergeMap(budgetLines => {
                return Observable.from([new ActualActions.LoadItemsSuccessAction(budgetLines)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Actuals Items Loaded Sucessfully')]);
            }));

    @Effect() addActuals$: Observable<Action> = this.actions$
        .ofType(ActualActions.ADD_ITEM)
        .mergeMap(action => this.actualService.addActual(action.payload)
            .map(actuals => new ActualActions.AddUpdateItemSuccessAction(actuals))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Actual')]);
            }));

    @Effect() updateActuals$: Observable<Action> = this.actions$
        .ofType(ActualActions.UPDATE_ITEM)
        .mergeMap(action => this.actualService.updateActual(action.payload)
            .map(actuals => new ActualActions.AddUpdateItemSuccessAction(actuals))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Actual')]);
            }));


    constructor(
        private actions$: Actions,
        private store$: Store<AppState>,
        private actualService: ActualService
    ) { }

    ngOnDestroy() {
        // console.log('ngOnDestroy');
    }
}
