import { BaseService } from './../../utilities';
import { BudgetLines } from './budgetLine.interface';

import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class BudgetLineService extends BaseService {
    api: string = 'BudgetLine';

    constructor(
        protected _http: Http,
        protected _configuration: Configuration,
        protected store: Store<AppState>

    ) {
        super(_http, _configuration, store);
    }

    public getBudgetLines = (budgetId: string, dept: string): Observable<BudgetLines[]> => {
        const params: URLSearchParams = new URLSearchParams();
        params.append('id', budgetId);
        params.append('department', dept);
        this.store.dispatch(new NotificationActions.SetLoading('Budget/GetBudgetDetails'));
        return this.GetByParam2('Budget/GetBudgetDetails', params);
    }

    public addBudgetLine = (budgetLine: BudgetLines): Observable<BudgetLines> => {
        return this.add(budgetLine, this.api + '/Add');
    }

    public updateBudgetLine = (budgetLine: BudgetLines): Observable<BudgetLines> => {
        return this.update(budgetLine, this.api + '/update');
    }

    public saveLineApprovals = (data: any[]): Observable<any> => {
        return this.add(data, 'BudgetLine/UpdateStatus');
    }
    public signOff = (budgetId: string, data: any[]): Observable<any> => {
        const params: URLSearchParams = new URLSearchParams();
        params.append('budgetId', budgetId);
        const url = 'BudgetLine/UpdateWorkProgramStatus';
        return this.addByParam(data, url, params);
    }


}
