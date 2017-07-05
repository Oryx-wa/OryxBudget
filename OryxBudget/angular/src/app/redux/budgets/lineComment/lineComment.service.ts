import { BaseService } from './../../utilities';
import { LineComment } from './lineComment.interface';

import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class LineCommentService extends BaseService {
    api: string = 'LineComment';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getLineComments = (budgetId: string, code: string): Observable<LineComment[]> => {
        const params1: URLSearchParams = new URLSearchParams();
        params1.append('budgetId', budgetId);
        params1.append('code', code);
        this.store.dispatch(new NotificationActions.SetLoading('LineComment'));
        return this.GetByParam2('Budget/GetLineComment', params1);
    }

    public addLineComment = (lineComment: LineComment): Observable<LineComment> => {
        return this.add(lineComment, 'Budget/AddComment');
    }

    public updateLineComment = (lineComment: LineComment): Observable<LineComment> => {
        return this.update(lineComment, this.api + '/update');
    }

}

