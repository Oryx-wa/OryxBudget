import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import * as _ from 'lodash';

import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import { Router } from '@angular/router';

import { TokenActions, LoginActions, MenuActions } from '../redux/login/actions';
import { Token, User, Menu, UserModel, initUser } from './../redux/login';
import { AppState, LoginSTATE } from '../redux';
import { Store } from '@ngrx/store';


@Injectable()
export class SecurityService {

    private actionUrl: string;
    private headers: Headers;
    private storage: any;
    private returnUrl: string;
    private idServerUrl: string;
    // private _router: Router;
    private _useBackEnd: boolean;
    private _isAuthorized: boolean;
    public HasAdminRole: boolean;
    public redirectUrl: string;
    private clientId: string;
    private scope: string;
    private dataFolder: string;
    public authenticated = false;
    public roles: any[] = [];
    public name = '';
    public operatorId = '';





    constructor(private _http: Http, private _configuration: Configuration,
        private _router: Router, private ngrxStore: Store<AppState>

    ) {

        this.actionUrl = _configuration.apiServer;
        this.returnUrl = _configuration.returnUrl;
        this.idServerUrl = _configuration.idServer;
        this._useBackEnd = _configuration.useBackend;
        this.clientId = _configuration.clientId;
        this.scope = _configuration.scope;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.headers.append('Access-Control-Allow-Origin', '*');
        this.storage = sessionStorage; // localStorage;

        this.dataFolder = _configuration.data;


        // this._router = router;

        if (this.retrieve('_isAuthorized') !== '') {
            this.HasAdminRole = this.retrieve('HasAdminRole');
            this._isAuthorized = this.retrieve('_isAuthorized');
        }
    }
    public IsAuthorized(): boolean {
        if (this._isAuthorized) {
            return true;
        }
        return false;
    }

    public setRouter(router: Router) {
        this._router = router;
    }

    public GetToken(): any {
        return this.retrieve('authorizationData');
    }

    public ResetAuthorizationData() {
        this.store('authorizationData', '');
        this.store('authorizationDataIdToken', '');

        this._isAuthorized = false;
        this.HasAdminRole = false;
        this.store('HasAdminRole', false);
        this.store('_isAuthorized', false);

    }

    public SetAuthorizationData(token: any, id_token: any) {
        if (this.retrieve('authorizationData') !== '') {
            this.store('authorizationData', '');
        }

        this.store('authorizationData', token);
        this.store('authorizationDataIdToken', id_token);
        this._isAuthorized = true;
        this.store('_isAuthorized', true);





    }

    public Authorize(requestedUrl: string) {
        this.ResetAuthorizationData();

        //this.ngrxStore.dispatch( new TokenActions.SetUrl(requestedUrl));
        this.store('RetUrl', requestedUrl);
        // // console.log('BEGIN Authorize, no auth data');

        let authorizationUrl = this.idServerUrl + 'connect/authorize';
        let client_id = this.clientId;
        let redirect_uri = this.returnUrl;
        let response_type = 'id_token token';
        let scope = this.scope;
        let nonce = 'N' + Math.random() + '' + Date.now();
        let state = Date.now() + '' + Math.random();


        this.store('authStateControl', state);
        this.store('authNonce', nonce);
        // // console.log('AuthorizedController created. adding myautostate: ' + this.retrieve('authStateControl'));

        let url =
            authorizationUrl + '?' +
            'response_type=' + encodeURI(response_type) + '&' +
            'client_id=' + encodeURI(client_id) + '&' +
            'scope=' + encodeURI(scope) + '&' +
            'redirect_uri=' + encodeURI(redirect_uri) + '&' +
            'nonce=' + encodeURI(nonce) + '&' +
            'state=' + encodeURI(state);

        window.location.href = url;
        //// console.log(url.toString());

    }
    private setHeaders() {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.headers.append('Access-Control-Allow-Origin', '*');

        let token = this.GetToken();
        // // console.log(token);

        if (token !== '') {
            this.headers.append('Authorization', 'Bearer ' + token);
        }
    }


    public getHeaders = (): Headers => {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        let token = this.GetToken();

        if (token !== '') {
            headers.append('Authorization', 'Bearer ' + token);

        }
        return headers;
    }

    public getUrl = (urlPart: string): string => {
        return this.actionUrl + urlPart + '/';
    }

    public AuthorizedCallback() {
        // // console.log('BEGIN AuthorizedCallback, no auth data');
        this.ResetAuthorizationData();

        let hash = window.location.hash.substr(1);

        let result: any = hash.split('&').reduce(function (result, item) {
            let parts = item.split('=');
            result[parts[0]] = parts[1];
            return result;
        }, {});

        // // console.log(result);
        // // console.log('AuthorizedCallback created, begin token validation');

        let token = '';
        let id_token = '';
        let authResponseIsValid = false;
        if (!result.error) {

            if (result.state !== this.retrieve('authStateControl')) {
                // console.log('AuthorizedCallback incorrect state');
            } else {

                token = result.access_token;
                id_token = result.id_token;

                let dataIdToken: any = this.getDataFromToken(id_token);
                // // console.log(dataIdToken);

                // validate nonce
                if (dataIdToken.nonce !== this.retrieve('authNonce')) {
                    // console.log('AuthorizedCallback incorrect nonce');

                } else {
                    this.store('authNonce', '');
                    this.store('authStateControl', '');
                    this.authenticated = true;

                    authResponseIsValid = true;
                    // // console.log('AuthorizedCallback state and nonce validated, returning access token');
                }
            }
        }

        if (authResponseIsValid) {
            this.ngrxStore.dispatch(new TokenActions.GetUrlAction());
            this.ngrxStore.select<LoginSTATE>('security').map(s => s.token.retUrl).map(s => this.returnUrl = s);

            this.ngrxStore.dispatch(new TokenActions.SetTokenAction({
                id: id_token, access: token, authenticated: true,
                retUrl: this.returnUrl = this.retrieve('RetUrl')
            }));

            //let dataIdToken: any = this.getDataFromToken(id_token);
            const dataIdToken: any = this.getDataFromToken(token);

            const user: UserModel.User = _.assign({}, initUser, {
                authenticated: true, full_name: dataIdToken.full_name,
                given_name: dataIdToken.given_name, email: dataIdToken.email, name: dataIdToken.name,
                family_name: dataIdToken.family_name, branch: dataIdToken.branch,
                sub: dataIdToken.sub, role: dataIdToken.role, token: id_token, groups: [],
                operatorId: dataIdToken.id, napims: (dataIdToken.napims) ? true : false,
                operator: (dataIdToken.operator) ? true : false
            });

            this.ngrxStore.dispatch(new LoginActions.LoginSuccessAction(user));
            this.name = dataIdToken.name;
            this.roles = dataIdToken.role;
            this.operatorId = dataIdToken.id;
            // console.log(dataIdToken);
            //// console.log(accessIdToken);

            this.SetAuthorizationData(token, id_token);
        } else {
            this.ResetAuthorizationData();
            this._router.navigate(['/unauthorised']);
        }
    }


    public Logoff() {
        // /connect/endsession?id_token_hint=...&post_logout_redirect_uri=https://myapp.com
        // console.log('BEGIN Authorize, no auth data');

        let authorizationUrl = this.idServerUrl + 'connect/endsession';

        let id_token_hint = this.retrieve('authorizationDataIdToken');
        let post_logout_redirect_uri = this.returnUrl + 'unauthorised';

        let url =
            authorizationUrl + '?' +
            'id_token_hint=' + encodeURI(id_token_hint) + '&' +
            'post_logout_redirect_uri=' + encodeURI(post_logout_redirect_uri);

        this.ResetAuthorizationData();

        window.location.href = url;
    }
    public HandleError(error: any) {

        if (error.status === 403) {
            // this._router.navigate(['/forbidden'])
        } else
            if (error.status === 401) {
                this.ResetAuthorizationData();
                // this._router.navigate(['/unauthorized'])
            }
    }

    private urlBase64Decode(str: any) {
        let output = str.replace('-', '+').replace('_', '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
            default:
                throw 'Illegal base64url string!';
        }

        return window.atob(output);
    }

    private getDataFromToken(token: any) {
        let data = {};
        if (typeof token !== 'undefined') {
            let encoded = token.split('.')[1];
            data = JSON.parse(this.urlBase64Decode(encoded));
        }
        // // console.log(data);
        return data;
    }

    private retrieve(key: string): any {
        let item = this.storage.getItem(key);

        if (item && item !== 'undefined') {
            return JSON.parse(this.storage.getItem(key));
        }

        return;
    }

    private store(key: string, value: any) {
        this.storage.setItem(key, JSON.stringify(value));
    }


}

