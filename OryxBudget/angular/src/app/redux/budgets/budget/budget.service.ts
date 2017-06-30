import { BaseService } from './../../utilities';
import { Budget } from './budget.interface';

import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class BudgetService extends BaseService {
    api: 'Budget';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getBudgets = (operatorId: string): Observable<Budget[]> => {
        const params: URLSearchParams = new URLSearchParams();
        params.append('operatorId', operatorId);
        this.store.dispatch(new NotificationActions.SetLoading('Budget'));
        const url = 'Budget/GetByOperator';
        return this.GetByParam2(url, params);
    }

    public getBudget = (type: any): Observable<Budget[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Budget'));
        return this.Get(this.api);
    }

    public addBudget = (budget: Budget): Observable<Budget> => {
        return this.add(budget, this.api + '/Add');
    }

    public updateBudget = (budget: Budget): Observable<Budget> => {
        return this.update(budget, this.api + '/update');
    }

}

