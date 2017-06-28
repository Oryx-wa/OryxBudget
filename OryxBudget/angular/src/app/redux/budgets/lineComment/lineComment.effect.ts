import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { LineCommentService } from './lineComment.service';
import * as LineCommentActions from './lineComment.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class LineCommentEffects implements OnDestroy {
    @Effect() LoadLineComments$: Observable<Action> = this.actions$
        .ofType(LineCommentActions.LOAD_ITEMS)
        .mergeMap(action => this.lineCommentService.getLineComments(action.payload)
            .mergeMap(lineComments => {
                return Observable.from([new LineCommentActions.LoadItemsSuccessAction(lineComments)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('LineComment Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(LineCommentActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('LineComment saved Sucessfully'));

    @Effect() addLineComments$: Observable<Action> = this.actions$
        .ofType(LineCommentActions.ADD_ITEM)
        .mergeMap(action => this.lineCommentService.addLineComment(action.payload)
            .map(lineComments => new LineCommentActions.AddUpdateItemSuccessAction(lineComments))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving LineComment')]);
            }));

    @Effect() updateLineComments$: Observable<Action> = this.actions$
        .ofType(LineCommentActions.UPDATE_ITEM)
        .mergeMap(action => this.lineCommentService.updateLineComment(action.payload)
            .map(lineComments => new LineCommentActions.AddUpdateItemSuccessAction(lineComments))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving LineComment')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private lineCommentService: LineCommentService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
