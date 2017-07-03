import { BaseService } from './../../utilities';
import { Actual } from './actual.interface';

import { Http, URLSearchParams } from '@angular/http';
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

    public getActuals = (budgetId: string, dept: string): Observable<Actual[]> => {
        const params: URLSearchParams = new URLSearchParams();
        params.append('id', budgetId);
        params.append('department', dept);
        this.store.dispatch(new NotificationActions.SetLoading('Budget/GetActualDetails'));
         return this.GetByParam2('Budget/GetActualDetails', params);
    }

    public addActual = (actual: Actual): Observable<Actual> => {
        return this.add(actual, this.api + '/Add');
    }

    public updateActual = (actual: Actual): Observable<Actual> => {
        return this.update(actual, this.api + '/update');
    }

}

