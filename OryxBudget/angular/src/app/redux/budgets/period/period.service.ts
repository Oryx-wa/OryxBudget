import { BaseService } from './../../utilities';
import { Period } from './period.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class PeriodService extends BaseService {
    api: string = 'Period';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getPeriods = (type: string): Observable<Period[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Period'));
        return this.Get(this.api);
    }

    public addPeriod = (period: Period): Observable<Period> => {
        return this.add(period, this.api + '/Add');
    }

    public updatePeriod = (period: Period): Observable<Period> => {
        return this.update(period, this.api + '/update');
    }

}
