import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import { Store } from '@ngrx/store';
// import { Token } from './../login/models/';
import { AppState, LoginSTATE, UserSelector, TokenSelector, BudgetActions, Token} from '../../redux';
import { Configuration } from '../../app.constants';
import { SecurityService } from '../../login/security.service';
//import * as loginSelectors from  './../../selectors/login.selector';

@Injectable()
export class BaseService {
    protected _useBackEnd: boolean;
    private _actionUrl: string;
    private token: string;
    private idServerUrl: string;
    public b1Url: string;
    public actionUrl: string;
    public api: string;
    public headers: Headers;
    private dataFolder: string;
    private token$: Observable<string>;

    constructor(protected _http: Http, protected _configuration: Configuration,
        protected store: Store<AppState>
    ) {
        this._useBackEnd = _configuration.useBackend;
        if (this._useBackEnd) {
            this._actionUrl = `${_configuration.apiServer}`;
            this.idServerUrl = `${_configuration.idServer}`;

        } else {
            this._actionUrl = `${_configuration.apiLocal}`;
        }
        this.dataFolder = _configuration.data;

        this.token$ = this.store.select(TokenSelector.accessToken);
        this.token$.subscribe(token => this.token = token);
        
        // this.token = this.securityService.GetToken();
    }

    protected setHeaders() {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        let token = this.token;
        console.log(token);
        if (token !== '') {
            this.headers.append('Authorization', 'Bearer ' + token);
        }
    }

    public setActionUrl(action: string) {

        this.actionUrl = this._actionUrl + '/' + action + '/';
        // console.log(this.actionUrl)
    }

    public GetLocalJson = (file: string): Observable<any> => {
        return this._http.get(this.dataFolder + file, {})
            .map(res => res.json());
    }

    protected getUrl = (urlPart: string): string => {
        return this._actionUrl  + urlPart + '/';
    }

    protected getHeaders = (): Headers => {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        let token = this.token;

        if (token !== '') {
            headers.append('Authorization', 'Bearer ' + token);

        }
        return headers;
    }

    protected add = (itemToAdd: any, action: string): Observable<any> => {
        console.log(JSON.stringify(itemToAdd));
        return this._http.post(this.getUrl(action), JSON.stringify(itemToAdd), { headers: this.getHeaders() })
            .map(res => res.json());
    }

    protected addByParam = (itemToAdd: any, action: string, params: URLSearchParams): Observable<any> => {
        console.log(JSON.stringify(itemToAdd));
        return this._http.post(this.getUrl(action),
            JSON.stringify(itemToAdd),
            {
                headers: this.getHeaders(),
                search: params
            })
            .map(res => res.json());
    }

    protected update = (itemToUpdate: any, urlPart: string): Observable<any> => {

        return this._http
            .post(this.getUrl(urlPart),
            JSON.stringify(itemToUpdate),
            { headers: this.getHeaders() })
            .map(res => res.json());
    }

    protected updateByParam = (itemToUpdate: any, urlPart: string, params: URLSearchParams): Observable<any> => {

        return this._http
            .post(this.getUrl(urlPart),
            JSON.stringify(itemToUpdate),
            {
                headers: this.getHeaders(),
                search: params
            })
            .map(res => res.json());
    }

    protected Delete = (id: string, urlPart: string): Observable<any> => {

        return this._http.delete(this.getUrl(urlPart) + id, {
            headers: this.getHeaders(),
            body: ''
        })
            .map(res => res.json());
    }

    protected Get = (urlPart: string): Observable<any[]> => {

        let url: string = this.getUrl(urlPart);
        if (this._useBackEnd) {
            return this._http.get(url, {
                headers: this.getHeaders(),
                body: ''
            }).map(res => res.json());
        }
    }

     protected GetSingle = (urlPart: string): Observable<any> => {

        let url: string = this.getUrl(urlPart);
        if (this._useBackEnd) {
            return this._http.get(url, {
                headers: this.getHeaders(),
                body: ''
            }).map(res => res.json());
        }
    }

    protected GetByParam = (urlPart: string, params: URLSearchParams): Observable<any[]> => {

        let url: string = this.getUrl(urlPart);
        if (this._useBackEnd) {
            return this._http.get(url, {
                headers: this.getHeaders(),
                body: '',
                search: params
            }).map(res => res.json());
        }
    }

    protected GetByParam2 = (urlPart: string, params: URLSearchParams): Observable<any> => {

        let url: string = this.getUrl(urlPart);
        if (this._useBackEnd) {
            return this._http.get(url, {
                headers: this.getHeaders(),
                body: '',
                search: params
            }).map(res => res.json());
        }
    }

    protected GetId = (urlPart: string, id: any): Observable<any> => {
        let url: string = this.getUrl(urlPart + id);
        if (this._useBackEnd) {
            return this._http.get(url, {
                headers: this.getHeaders()
            }).map(res => res.json());
        }
    }


}