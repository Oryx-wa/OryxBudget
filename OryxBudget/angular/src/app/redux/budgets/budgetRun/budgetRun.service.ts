import {BaseService} from './../../utilities';
import {  BudgetRun } from './budgetRun.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import {  NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class BudgetRunService extends BaseService {
    api: string = 'BudgetRun';

    constructor (
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

     public getBudgetRuns = (type: string): Observable<BudgetRun[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('BudgetRun'));
        return this.Get(this.api);
    }

     public addBudgetRun = (budgetRun: BudgetRun): Observable<BudgetRun> => {
        return this.add(budgetRun, this.api + '/Add');
    }

     public updateBudgetRun = (budgetRun: BudgetRun): Observable<BudgetRun> => {
        return this.update(budgetRun, this.api + '/update');
    }

}

