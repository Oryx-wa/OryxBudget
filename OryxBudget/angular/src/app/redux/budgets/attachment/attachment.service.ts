import { BaseService } from './../../utilities';
import { Attachment } from './attachment.interface';

import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';

@Injectable()
export class AttachmentService extends BaseService {
    api: string = 'Attachment';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }

    public getAttachments = (type: string): Observable<Attachment[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Attachment'));
        return this.Get(this.api);
    }

    public addAttachment = (attachment: Attachment): Observable<Attachment> => {
        return this.add(attachment, this.api + '/Add');
    }

    public updateAttachment = (attachment: Attachment): Observable<Attachment> => {
        return this.update(attachment, this.api + '/update');
    }

}

