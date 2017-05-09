import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { environment } from './../environments/environment';
@Injectable()
export class Configuration {
    public apiServer: string = 'http://localhost:5502/api';
    public idServer: string = 'http://localhost:5000/';
    public returnUrl: string = 'http://localhost:4200/';
    public useBackend: boolean = true;
    public apiLocal: string = '/api';
    public clientId: string = 'OryxHR.webapi';
    public scope: string = 'openid profile OryxHR email';
    public data: string = '/assets/data/';
    public b1Server: string = 'http://localhost:39930/api';
    public apiUploadFolder: string = this.apiServer + '/uploads';

    private constants: Observable<Contants>;

    constructor(private _http: Http, ) {
        if (environment.production) {
        this.constants = this._http.get('/assets/config/app.constants.json', {})
            .map(res => res.json());
            this.constants.subscribe(constants => {
                this.apiServer = constants.apiServer;
                this.idServer = constants.idServer;
                this.returnUrl = constants.returnUrl;
                this.clientId = constants.clientId;
                this.scope = constants.scope;
                this.apiUploadFolder = constants.apiUploadFolder;
            });
        }
    }
}

export interface Contants {
    apiServer: string;
    idServer: string;
    returnUrl: string;
    useBackend: boolean;
    clientId: string;
    scope: string;
    apiUploadFolder: string;
}