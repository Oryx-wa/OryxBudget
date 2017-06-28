import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { OnDestroy } from '@angular/core';

import { ContactPersonService } from './contactPerson.service';
import * as ContactPersonActions from './contactPerson.action';
import { AppState } from './../../';
import {  NotificationActions, ErrorActions} from './../../general/actions/';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';

@Injectable()
export class ContactPersonEffects implements OnDestroy {
        @Effect() LoadContactPersons$: Observable<Action> = this.actions$
            .ofType(ContactPersonActions.LOAD_ITEMS)
            .mergeMap(action => this.contactPersonService.getContactPersons(action.payload)
                .mergeMap(contactPersons => {
                    return Observable.from([new ContactPersonActions.LoadItemsSuccessAction(contactPersons)]);
                })
                .catch(err => {
                    return Observable.from([new ErrorActions.ErrorAddAction(err),
                    new NotificationActions.SetLoaded( 'ContactPerson Items Loaded Sucessfully')]);
                }));
        @Effect() AddUpdateItemSuces$: Observable<Action> = this.actions$
            .ofType(ContactPersonActions.ADD_UPDATE_ITEM_SUCCESS)
            .map(() => new NotificationActions.SetSaved('ContactPerson saved Sucessfully'));

        @Effect() addContactPersons$: Observable<Action> = this.actions$
            .ofType(ContactPersonActions.ADD_ITEM)
            .mergeMap(action => this.contactPersonService.addContactPerson(action.payload)
            .map(contactPersons => new ContactPersonActions.AddUpdateItemSuccessAction(contactPersons))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving ContactPerson')]);
            }));

        @Effect() updateContactPersons$: Observable<Action> = this.actions$
            .ofType(ContactPersonActions.UPDATE_ITEM)
            .mergeMap(action => this.contactPersonService.updateContactPerson(action.payload)
            .map(contactPersons => new ContactPersonActions.AddUpdateItemSuccessAction(contactPersons))
            .catch(err => {
                return Observable.from([new ErrorActions.ErrorAddAction(err),
                new NotificationActions.SetSavingError('Error saving ContactPerson')]);
            }));


constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private contactPersonService: ContactPersonService
) {}

ngOnDestroy() {
    console.log('ngOnDestroy');
}
}
