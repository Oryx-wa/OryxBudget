import { BaseService } from './../../utilities';
import { Actual } from './actual.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class ActualService extends BaseService {
    api: string = 'Actual';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getActuals = (type: string): Observable<Actual[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Actual'));
        return this.Get(this.api);
    }

    public addActual = (actual: Actual): Observable<Actual> => {
        return this.add(actual, this.api + '/Add');
    }

    public updateActual = (actual: Actual): Observable<Actual> => {
        return this.update(actual, this.api + '/update');
    }

}

