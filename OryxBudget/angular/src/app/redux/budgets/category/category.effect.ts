import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { CategoryService } from './category.service';
import * as CategoryActions from './category.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryEffects implements OnDestroy {
    @Effect() LoadCategorys$: Observable<Action> = this.actions$
        .ofType(CategoryActions.LOAD_ITEMS)
        .mergeMap(action => this.categoryService.getCategorys(action.payload)
            .mergeMap(categorys => {
                return Observable.from([new CategoryActions.LoadItemsSuccessAction(categorys)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Category Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(CategoryActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('Category saved Sucessfully'));

    @Effect() addCategorys$: Observable<Action> = this.actions$
        .ofType(CategoryActions.ADD_ITEM)
        .mergeMap(action => this.categoryService.addCategory(action.payload)
            .map(categorys => new CategoryActions.AddUpdateItemSuccessAction(categorys))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Category')]);
            }));

    @Effect() updateCategorys$: Observable<Action> = this.actions$
        .ofType(CategoryActions.UPDATE_ITEM)
        .mergeMap(action => this.categoryService.updateCategory(action.payload)
            .map(categorys => new CategoryActions.AddUpdateItemSuccessAction(categorys))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Category')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private categoryService: CategoryService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
