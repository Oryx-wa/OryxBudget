import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetCodeViewService } from './budgetCodeView.service';
import * as BudgetCodeViewActions from './budgetCodeView.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class BudgetCodeViewEffects implements OnDestroy {
    @Effect() LoadBudgetCodeViews$: Observable<Action> = this.actions$
        .ofType(BudgetCodeViewActions.LOAD_ITEMS)
        .mergeMap(action => this.budgetCodeViewService.getBudgetCodeViews(action.payload)
            .mergeMap(budgetCodeViews => {
                return Observable.from([new BudgetCodeViewActions.LoadItemsSuccessAction(budgetCodeViews)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('BudgetCodeView Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(BudgetCodeViewActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('BudgetCodeView saved Sucessfully'));

    @Effect() addBudgetCodeViews$: Observable<Action> = this.actions$
        .ofType(BudgetCodeViewActions.ADD_ITEM)
        .mergeMap(action => this.budgetCodeViewService.addBudgetCodeView(action.payload)
            .map(budgetCodeViews => new BudgetCodeViewActions.AddUpdateItemSuccessAction(budgetCodeViews))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetCodeView')]);
            }));

    @Effect() updateBudgetCodeViews$: Observable<Action> = this.actions$
        .ofType(BudgetCodeViewActions.UPDATE_ITEM)
        .mergeMap(action => this.budgetCodeViewService.updateBudgetCodeView(action.payload)
            .map(budgetCodeViews => new BudgetCodeViewActions.AddUpdateItemSuccessAction(budgetCodeViews))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetCodeView')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private budgetCodeViewService: BudgetCodeViewService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
