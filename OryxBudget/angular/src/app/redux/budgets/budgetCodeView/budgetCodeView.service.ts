import { BaseService } from './../../utilities';
import { BudgetCodeView } from './budgetCodeView.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class BudgetCodeViewService extends BaseService {
    api: string = 'BudgetCodeView';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getBudgetCodeViews = (type: string): Observable<BudgetCodeView[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('BudgetCodeView'));
        return this.Get(this.api);
    }

    public addBudgetCodeView = (budgetCodeView: BudgetCodeView): Observable<BudgetCodeView> => {
        return this.add(budgetCodeView, this.api + '/Add');
    }

    public updateBudgetCodeView = (budgetCodeView: BudgetCodeView): Observable<BudgetCodeView> => {
        return this.update(budgetCodeView, this.api + '/update');
    }

}

