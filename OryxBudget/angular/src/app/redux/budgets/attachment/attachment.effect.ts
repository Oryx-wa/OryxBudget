import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { AttachmentService } from './attachment.service';
import * as AttachmentActions from './attachment.action';
import { AppState } from './../../';
import { NotificationActions, ErrorActions } from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class AttachmentEffects implements OnDestroy {
    @Effect() LoadAttachments$: Observable<Action> = this.actions$
        .ofType(AttachmentActions.LOAD_ITEMS)
        .mergeMap(action => this.attachmentService.getAttachments(action.payload)
            .mergeMap(attachments => {
                return Observable.from([new AttachmentActions.LoadItemsSuccessAction(attachments)]);
            })
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetLoaded('Attachment Items Loaded Sucessfully')]);
            }));
    @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
        .ofType(AttachmentActions.ADD_UPDATE_ITEM_SUCCESS)
        .map(() => new NotificationActions.SetSaved('Attachment saved Sucessfully'));

    @Effect() addAttachments$: Observable<Action> = this.actions$
        .ofType(AttachmentActions.ADD_ITEM)
        .mergeMap(action => this.attachmentService.addAttachment(action.payload)
            .map(attachments => new AttachmentActions.AddUpdateItemSuccessAction(attachments))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Attachment')]);
            }));

    @Effect() updateAttachments$: Observable<Action> = this.actions$
        .ofType(AttachmentActions.UPDATE_ITEM)
        .mergeMap(action => this.attachmentService.updateAttachment(action.payload)
            .map(attachments => new AttachmentActions.AddUpdateItemSuccessAction(attachments))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving Attachment')]);
            }));


    constructor(
        private actions$: Actions,
        private store: Store<AppState>,
        private attachmentService: AttachmentService
    ) { }

    ngOnDestroy() {
        console.log('ngOnDestroy');
    }
}
