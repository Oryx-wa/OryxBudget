import { BaseService } from './../../utilities';
import { BudgetLines } from './budgetLine.interface';

import { Http } from '@angular/http';
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

    public getBudgetLines = (type: string): Observable<BudgetLines[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('BudgetLine'));
        return this.Get(this.api);
    }

    public addBudgetLine = (budgetLine: BudgetLines): Observable<BudgetLines> => {
        return this.add(budgetLine, this.api + '/Add');
    }

    public updateBudgetLine = (budgetLine: BudgetLines): Observable<BudgetLines> => {
        return this.update(budgetLine, this.api + '/update');
    }

}
