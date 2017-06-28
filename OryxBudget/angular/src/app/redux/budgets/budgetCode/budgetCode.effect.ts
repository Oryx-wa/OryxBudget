import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetCodeService } from './budgetCode.service';
import * as BudgetCodeActions from './budgetCode.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class BudgetCodeEffects implements OnDestroy {
    @Effect() LoadBudgetCodes$: Observable<Action> = this.actions$
        .ofType(BudgetCodeActions.LOAD_ITEMS)
        .mergeMap(action => this.budgetCodeService.getBudgetCodes(action.payload)
            .mergeMap(budgetCodes => {
                return Observable.from([new BudgetCodeActions.LoadItemsSuccessAction(budgetCodes)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('BudgetCode Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(BudgetCodeActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('BudgetCode saved Sucessfully'));

    @Effect() addBudgetCodes$: Observable<Action> = this.actions$
        .ofType(BudgetCodeActions.ADD_ITEM)
        .mergeMap(action => this.budgetCodeService.addBudgetCode(action.payload)
            .map(budgetCodes => new BudgetCodeActions.AddUpdateItemSuccessAction(budgetCodes))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetCode')]);
            }));

    @Effect() updateBudgetCodes$: Observable<Action> = this.actions$
        .ofType(BudgetCodeActions.UPDATE_ITEM)
        .mergeMap(action => this.budgetCodeService.updateBudgetCode(action.payload)
            .map(budgetCodes => new BudgetCodeActions.AddUpdateItemSuccessAction(budgetCodes))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetCode')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private budgetCodeService: BudgetCodeService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
