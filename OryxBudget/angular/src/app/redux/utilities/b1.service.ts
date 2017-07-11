import { Http, Response, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './../';
import { Configuration } from './../../app.constants';
import { BaseService } from './../utilities';

@Injectable()
export class B1Service extends BaseService { 
    public b1Url: string;
    constructor(
        protected _http: Http, protected _configuration: Configuration, protected store: Store<AppState>
    ) {
        super(_http, _configuration, store)
        this.b1Url = `${_configuration.b1Server}`;
    }

     protected getUrl = (urlPart: string): string => {
        return this.b1Url + '/' + urlPart + '/';
    }

    public setActionUrl(action: string) {

        this.actionUrl = this.b1Url + '/' + action + '/';
        // // console.log(this.actionUrl)
    }

}