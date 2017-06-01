import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetService } from './budget.service';
import * as BudgetActions from './budget.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class BudgetEffects implements OnDestroy {
    @Effect() LoadBudgets$: Observable<Action> = this.actions$
        .ofType(BudgetActions.LOAD_ITEMS)
        .mergeMap(action => this.budgetService.getBudgets(action.payload)
            .mergeMap(budgets => {
                return Observable.from([new BudgetActions.LoadItemsSuccessAction(budgets)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Budget Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(BudgetActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('Budget saved Sucessfully'));

    @Effect() addBudgets$: Observable<Action> = this.actions$
        .ofType(BudgetActions.ADD_ITEM)
        .mergeMap(action => this.budgetService.addBudget(action.payload)
            .map(budgets => new BudgetActions.AddUpdateItemSuccessAction(budgets))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Budget')]);
            }));

    @Effect() updateBudgets$: Observable<Action> = this.actions$
        .ofType(BudgetActions.UPDATE_ITEM)
        .mergeMap(action => this.budgetService.updateBudget(action.payload)
            .map(budgets => new BudgetActions.AddUpdateItemSuccessAction(budgets))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Budget')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private budgetService: BudgetService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
