import { BaseService } from './../../utilities';
import { Notification } from './notification.interface';

import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../../';
import { NotificationActions } from './../../general/actions/';
import { Configuration } from './../../../app.constants';


@Injectable()
export class NotificationService extends BaseService {
    api: string = 'Notification';

    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store);
    }



    public getAllUnreadNotifications = (operatorId: string, workProgram: string): Observable<Notification[]> => {
        const params1: URLSearchParams = new URLSearchParams();
        params1.append('operatorId', operatorId);
        params1.append('workProgram', workProgram);
        return this.GetByParam2('Notification/GetUnreadNotifications', params1);
      }


    public getAllNotifications = (): Observable<Notification[]> => {
        this.store.dispatch(new NotificationActions.SetLoading('Notification'));
        return this.Get('Notification/GetAllNotifications');
    }

    public addNotification = (notification: Notification): Observable<Notification> => {
        return this.add(notification, 'Notification/AddNotification');
    }
}
