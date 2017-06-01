import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { OperatorTypeService } from './operatorType.service';
import * as OperatorTypeActions from './operatorType.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class OperatorTypeEffects implements OnDestroy {
    @Effect() LoadOperatorTypes$: Observable<Action> = this.actions$
        .ofType(OperatorTypeActions.LOAD_ITEMS)
        .mergeMap(action => this.operatorTypeService.getOperatorTypes(action.payload)
            .mergeMap(operatorTypes => {
                return Observable.from([new OperatorTypeActions.LoadItemsSuccessAction(operatorTypes)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('OperatorType Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(OperatorTypeActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('OperatorType saved Sucessfully'));

    @Effect() addOperatorTypes$: Observable<Action> = this.actions$
        .ofType(OperatorTypeActions.ADD_ITEM)
        .mergeMap(action => this.operatorTypeService.addOperatorType(action.payload)
            .map(operatorTypes => new OperatorTypeActions.AddUpdateItemSuccessAction(operatorTypes))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving OperatorType')]);
            }));

    @Effect() updateOperatorTypes$: Observable<Action> = this.actions$
        .ofType(OperatorTypeActions.UPDATE_ITEM)
        .mergeMap(action => this.operatorTypeService.updateOperatorType(action.payload)
            .map(operatorTypes => new OperatorTypeActions.AddUpdateItemSuccessAction(operatorTypes))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving OperatorType')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private operatorTypeService: OperatorTypeService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
