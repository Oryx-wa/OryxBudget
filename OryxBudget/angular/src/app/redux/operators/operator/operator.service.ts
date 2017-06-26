import { BaseService } from './../../utilities';
import { Operator } from './operator.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class OperatorService extends BaseService {
    api: string = 'Operator';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getOperators = (type: string): Observable<Operator[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Operator'));
        return this.Get(this.api);
    }

    public addOperator = (operator: Operator): Observable<Operator> => {
        return this.add(operator, this.api + '/Add');
    }

    public updateOperator = (operator: Operator): Observable<Operator> => {
        return this.update(operator, this.api + '/update');
    }

}

