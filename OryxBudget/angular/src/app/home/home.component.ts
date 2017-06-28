import { Component, OnInit, OnChanges } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Operators } from './../models/operators';
import { LoginActions, TokenActions } from '../redux/login/actions';
import { AppState, LoginSTATE, UserSelector, TokenSelector } from '../redux';
import { Store } from '@ngrx/store';
import { UserModel } from '../redux/login/models';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnChanges {
  public name = '';
  public operatorId = '';
  public role = [];
  public operators$: Observable<Operators>;
  public showNapims = false;
  public showOperator = false;
  token$: Observable<UserModel.Token>;
  token: UserModel.Token;
  public authenticated$: Observable<boolean>;
  public napims$: Observable<boolean>;
  public subCom$: Observable<boolean>;
  public tecCom$: Observable<boolean>;
  public malCom$: Observable<boolean>;
  public dept$: Observable<string>;
  public operator$: Observable<boolean>;
  constructor(private _router: Router,
    public securityService: SecurityService,
    private _http: Http,
    private store: Store<AppState>) {

  }

  ngOnInit() {


    this.authenticated$ = this.store.select(TokenSelector.authenticated);
    this.dept$ = this.store.select(UserSelector.dept);
    this.subCom$ = this.store.select(UserSelector.subCom);
    this.tecCom$ = this.store.select(UserSelector.tecCom);
    this.malCom$ = this.store.select(UserSelector.malCom);
    this.napims$ = this.store.select(UserSelector.napims);
    this.operator$ = this.store.select(UserSelector.operator);

    this.subCom$.subscribe(subCom => {
      if (subCom) {
        this._router.navigateByUrl('/workprogram');
      }
    });

    /*
    if (this.securityService.IsAuthorized()) {
      this.name = this.securityService.name;
      this.operatorId = this.securityService.operatorId;
      this.role = this.securityService.roles;

      if (this.role.indexOf('NAPIMS') !== -1) {
        this.showNapims = true;
        const url = this.securityService.getUrl('Operator');

        this.operators$ = this._http.get(url, {
          headers: this.securityService.getHeaders(),
          body: ''
        }).map(res => res.json());
      }
      if (this.role.indexOf('Operator') !== -1) {
        this.showOperator = true;
      }
    } else {
      this._router.navigate(['/unauthorised']);
    }*/

  }

  updateTitle(token: UserModel.Token) {
    if (token.authenticated) {
      // this.pageTitle = 'Welcome authenticated user';
      this.token = token;
      if (token.retUrl) {
        if (token.retUrl.length > 1) {
          this._router.navigate([token.retUrl.replace('/', '')]);
        }
      }

    } else {
      this._router.navigate(['login']);
    }
  }


  ngOnChanges(changes: any) {


  }


}
