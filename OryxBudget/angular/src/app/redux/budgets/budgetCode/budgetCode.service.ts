import { BaseService } from './../../utilities';
import { BudgetCode } from './budgetCode.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class BudgetCodeService extends BaseService {
    api: string = 'BudgetCode';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getBudgetCodes = (type: string): Observable<BudgetCode[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('BudgetCode'));
        return this.Get(this.api);
    }

    public addBudgetCode = (budgetCode: BudgetCode): Observable<BudgetCode> => {
        return this.add(budgetCode, this.api + '/Add');
    }

    public updateBudgetCode = (budgetCode: BudgetCode): Observable<BudgetCode> => {
        return this.update(budgetCode, this.api + '/update');
    }

}

