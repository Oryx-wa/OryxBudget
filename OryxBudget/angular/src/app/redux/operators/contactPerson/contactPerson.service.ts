import { BaseService } from './../../utilities';
import { ContactPerson } from './contactPerson.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class ContactPersonService extends BaseService {
    api: string = 'ContactPerson';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getContactPersons = (type: string): Observable<ContactPerson[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('ContactPerson'));
        return this.Get(this.api);
    }

    public addContactPerson = (contactPerson: ContactPerson): Observable<ContactPerson> => {
        return this.add(contactPerson, this.api + '/Add');
    }

    public updateContactPerson = (contactPerson: ContactPerson): Observable<ContactPerson> => {
        return this.update(contactPerson, this.api + '/update');
    }

}

