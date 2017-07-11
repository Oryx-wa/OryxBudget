import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetRunService } from './budgetRun.service';
import * as BudgetRunActions from './budgetRun.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class BudgetRunEffects implements OnDestroy {
    @Effect() LoadBudgetRuns$: Observable<Action> = this.actions$
        .ofType(BudgetRunActions.LOAD_ITEMS)
        .mergeMap(action => this.budgetRunService.getBudgetRuns(action.payload)
            .mergeMap(budgetRuns => {
                return Observable.from([new BudgetRunActions.LoadItemsSuccessAction(budgetRuns)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('BudgetRun Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(BudgetRunActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('BudgetRun saved Sucessfully'));

    @Effect() addBudgetRuns$: Observable<Action> = this.actions$
        .ofType(BudgetRunActions.ADD_ITEM)
        .mergeMap(action => this.budgetRunService.addBudgetRun(action.payload)
            .map(budgetRuns => new BudgetRunActions.AddUpdateItemSuccessAction(budgetRuns))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetRun')]);
            }));

    @Effect() updateBudgetRuns$: Observable<Action> = this.actions$
        .ofType(BudgetRunActions.UPDATE_ITEM)
        .mergeMap(action => this.budgetRunService.updateBudgetRun(action.payload)
            .map(budgetRuns => new BudgetRunActions.AddUpdateItemSuccessAction(budgetRuns))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetRun')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private budgetRunService: BudgetRunService
    ) { }

    ngOnDestroy() {
        // console.log('ngOnDestroy');
    }
}
