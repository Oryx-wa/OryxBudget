
import { Injectable } from '@angular/core';
import { Store, Action } from '@ngrx/store';

import { Actions, Effect } from '@ngrx/effects';
import { SecurityService } from './../../../login/security.service';
import { Observable } from 'rxjs'

import {  TokenActions } from '../actions';


import { AppState } from './../../index';

import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/observable/from';
import 'rxjs/add/operator/toArray';
import { Database } from '@ngrx/db';
import 'rxjs/add/operator/switchMapTo';



@Injectable()
export class LoginEffects {

  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    public securityService: SecurityService,
    private db: Database
  ) { }



  // tslint:disable-next-line:member-ordering

  // tslint:disable-next-line:member-ordering
 
/*
  @Effect()
  Login$: Observable<Action> = this.actions$
    .ofType(LoginActions.LOGIN)
    .switchMapTo(this.securityService.GetUserInfo())
    .map(user => new LoginActions.LoginSuccess(user));

  @Effect()
  SetUrl$: Observable<Action> = this.actions$
    .ofType(TokenActions.SET_URL)
    .map((action: TokenActions.SetUrl) => action.payload)
    .mergeMap(retUrl => this.db.insert('returnUrl', retUrl)
    ..map(());
*/
  // tslint:disable-next-line:member-ordering
  @Effect()
  GetUrl$: Observable<Action> = this.actions$
    .ofType(TokenActions.GET_URL)
    .map((action: TokenActions.SetUrlAction) => action.payload)
    .mergeMap(retUrl => this.db.query('returnUrl')
      .map(ret => new TokenActions.GetUrlSuccessAction(ret.result[0].name)));

}
