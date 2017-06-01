import {BaseService} from './../../utilities';
import {  StatusHistory } from './statusHistory.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import {  NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class StatusHistoryService extends BaseService {
    api: string = 'StatusHistory';

    constructor (
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

     public getStatusHistorys = (type: string): Observable<StatusHistory[]> => {
       this.store.dispatch(new NotificationActions.SetLoading('StatusHistory'));
        return this.Get(this.api);
    }

     public addStatusHistory = (statusHistory: StatusHistory): Observable<StatusHistory> => {
        return this.add(statusHistory, this.api + '/Add');
    }

     public updateStatusHistory = (statusHistory: StatusHistory): Observable<StatusHistory> => {
        return this.update(statusHistory, this.api + '/update');
    }

}

