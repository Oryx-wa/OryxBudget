import {BaseService} from './../../utilities';
import {  LineComment } from './lineComment.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import {  NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class LineCommentService extends BaseService {
    api: string = 'LineComment';

    constructor (
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

     public getLineComments = (type: string): Observable<LineComment[]> => {
       this.store.dispatch(new NotificationActions.SetLoading('LineComment'));
        return this.Get(this.api);
    }

     public addLineComment = (lineComment: LineComment): Observable<LineComment> => {
        return this.add(lineComment, this.api + '/Add');
    }

     public updateLineComment = (lineComment: LineComment): Observable<LineComment> => {
        return this.update(lineComment, this.api + '/update');
    }

}

