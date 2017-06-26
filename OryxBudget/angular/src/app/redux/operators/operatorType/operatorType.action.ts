import { BaseService } from './../../utilities';
import { OperatorType } from './operatorType.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class OperatorTypeService extends BaseService {
    api: string = 'OperatorType';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getOperatorTypes = (type: string): Observable<OperatorType[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('OperatorType'));
        return this.Get(this.api);
    }

    public addOperatorType = (operatorType: OperatorType): Observable<OperatorType> => {
        return this.add(operatorType, this.api + '/Add');
    }

    public updateOperatorType = (operatorType: OperatorType): Observable<OperatorType> => {
        return this.update(operatorType, this.api + '/update');
    }

}

