import {BaseService} from './../../utilities';
import {  Category } from './category.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import {  NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class CategoryService extends BaseService {
    api: string = 'Category';

    constructor (
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

     public getCategorys = (type: string): Observable<Category[]> => {
       this.store.dispatch(new NotificationActions.SetLoading('Category'));
        return this.Get(this.api);
    }

     public addCategory = (category: Category): Observable<Category> => {
        return this.add(category, this.api + '/Add');
    }

     public updateCategory = (category: Category): Observable<Category> => {
        return this.update(category, this.api + '/update');
    }

}

