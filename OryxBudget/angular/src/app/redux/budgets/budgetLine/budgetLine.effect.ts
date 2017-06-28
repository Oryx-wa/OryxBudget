import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetLineService } from './budgetLine.service';
import * as BudgetLineActions from './budgetLine.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class BudgetLineEffects implements OnDestroy {
    @Effect() LoadBudgetLines$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.LOAD_ITEMS)
        .mergeMap(action => this.budgetLineService.getBudgetLines(action.payload)
            .mergeMap(budgetLines => {
                return Observable.from([new BudgetLineActions.LoadItemsSuccessAction(budgetLines)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('BudgetLine Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('BudgetLine saved Sucessfully'));

    @Effect() addBudgetLines$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.ADD_ITEM)
        .mergeMap(action => this.budgetLineService.addBudgetLine(action.payload)
            .map(budgetLines => new BudgetLineActions.AddUpdateItemSuccessAction(budgetLines))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetLine')]);
            }));

    @Effect() updateBudgetLines$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.UPDATE_ITEM)
        .mergeMap(action => this.budgetLineService.updateBudgetLine(action.payload)
            .map(budgetLines => new BudgetLineActions.AddUpdateItemSuccessAction(budgetLines))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetLine')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private budgetLineService: BudgetLineService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
