import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { OperatorService } from './operator.service';
import * as OperatorActions from './operator.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class OperatorEffects implements OnDestroy {
    @Effect() LoadOperators$: Observable<Action> = this.actions$
        .ofType(OperatorActions.LOAD_ITEMS)
        .mergeMap(action => this.operatorService.getOperators(action.payload)
            .mergeMap(operators => {
                return Observable.from([new OperatorActions.LoadItemsSuccessAction(operators)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Operator Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(OperatorActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('Operator saved Sucessfully'));

    @Effect() addOperators$: Observable<Action> = this.actions$
        .ofType(OperatorActions.ADD_ITEM)
        .mergeMap(action => this.operatorService.addOperator(action.payload)
            .map(operators => new OperatorActions.AddUpdateItemSuccessAction(operators))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Operator')]);
            }));

    @Effect() updateOperators$: Observable<Action> = this.actions$
        .ofType(OperatorActions.UPDATE_ITEM)
        .mergeMap(action => this.operatorService.updateOperator(action.payload)
            .map(operators => new OperatorActions.AddUpdateItemSuccessAction(operators))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Operator')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private operatorService: OperatorService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
