import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { environment } from './../environments/environment';
@Injectable()
export class Configuration {
    public apiServer: string;
    public idServer: string;
    public returnUrl: string;
    public useBackend: boolean = true;
    public apiLocal: string = '/api';
    public clientId: string = 'OryxBudget';
    public scope: string = 'openid profile OryxBudget';
    public data: string = '/assets/data/';
    public b1Server: string = 'http://localhost:39930/api';
    public apiUploadFolder: string;

    private constants: Observable<Contants>;

    constructor(private _http: Http, ) {

        if (environment.production) {

            this.apiServer = 'http://192.168.1.19/budgetapi/api/';
            this.idServer = 'http://192.168.1.19/budgetidsrv/';
            this.returnUrl = 'http://192.168.1.19/napims/';
            this.apiUploadFolder = this.apiServer + 'uploads';
        } else {
            this.apiServer = 'http://localhost:5502/api/';
            this.idServer = 'http://localhost:5000/';
            this.returnUrl = 'http://localhost:4200/';
            this.apiUploadFolder = this.apiServer + 'uploads';
        }
        console.log(environment.production);
        console.log(this.apiServer)
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