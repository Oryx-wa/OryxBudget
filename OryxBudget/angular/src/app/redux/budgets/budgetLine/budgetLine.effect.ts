import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { BudgetLineService } from './budgetLine.service';
import * as BudgetLineActions from './budgetLine.action';
import { LineCommentActions } from './../lineComment';
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
        .withLatestFrom(this.store$.select(state => state.security.user))
        .map(([action, user]) => {
            const ret = { dept: user.dept, budgetId: action.payload };
            return ret;
        })
        .takeWhile(payload => (payload.budgetId !== '' || payload.budgetId !== null))
        .mergeMap(payload => this.budgetLineService.getBudgetLines(payload.budgetId, payload.dept)
            .mergeMap(budgetLines => {
                return Observable.from([new BudgetLineActions.LoadItemsSuccessAction(budgetLines)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('BudgetLine Items Loaded Sucessfully')]);
            }));

    @Effect() SaveApprovalUpdates$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.SAVE_APPROVAL_UPDATES)
        .withLatestFrom(this.store$.select(state => state.budgets.budgetLine))
        .map(([action, budgetLine]) => {
            const ret: { id: string, budgetId: string, approvalStatus: number, code: string }[] = [];
            budgetLine.ids.map(id => {
                const line = budgetLine.entities[id];
                ret.push({
                    id: line.id, budgetId: line.budgetId,
                    approvalStatus: line.lineStatus, code: line.code
                })
            });
            return ret;
        })
        .mergeMap(payload => this.budgetLineService.saveLineApprovals(payload)
            .map(() => new BudgetLineActions.LoadItemAction(''))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving BudgetLine')]);
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

    @Effect() selectLine$: Observable<Action> = this.actions$
        .ofType(BudgetLineActions.SELECT)
        .map(() => new LineCommentActions.LoadItemsAction(''));

    
    constructor(
        private actions$: Actions,
        private store$: Store<AppState>,
        private budgetLineService: BudgetLineService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
