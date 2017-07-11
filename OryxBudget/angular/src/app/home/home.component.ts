import { Component, OnInit, OnChanges, OnDestroy } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';
import { Form, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { SecurityService } from './../login/security.service';
import { Observable } from 'rxjs/Observable';
import { Operators } from './../models/operators';
import { LoginActions, TokenActions } from '../redux/login/actions';
import {
  AppState, Operator, OperatorSelector, OperatorActions,
  LoginSTATE, UserSelector, TokenSelector, BudgetActions,
} from '../redux';
import { Store } from '@ngrx/store';
import { UserModel } from '../redux/login/models';

import { DisplayModeEnum } from '../shared/shared-enum.enum';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnChanges, OnDestroy {
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
  public operatorList$: Observable<Operator[]>;

  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;
  private alive = true;

  form: FormGroup;
  constructor(private _router: Router, public securityService: SecurityService,
    private _http: Http, private store: Store<AppState>, private fb: FormBuilder) {
    this.form = this.fb.group({
      operator: new FormControl('')
    });

  }

  ngOnInit() {

    this.store.dispatch(new BudgetActions.SelectItemAction(null));
    this.authenticated$ = this.store.select(TokenSelector.authenticated);
    this.dept$ = this.store.select(UserSelector.dept);
    this.subCom$ = this.store.select(UserSelector.subCom);
    this.tecCom$ = this.store.select(UserSelector.tecCom);
    this.malCom$ = this.store.select(UserSelector.malCom);
    this.napims$ = this.store.select(UserSelector.napims);
    this.operator$ = this.store.select(UserSelector.operator);
    this.operatorList$ = this.store.select(OperatorSelector.getOperatorCollection);

    this.authenticated$.subscribe(authenticated => {
      if (authenticated) {
        this.store.dispatch(new BudgetActions.LoadItemsAction(''));
      } else {
        this._router.navigateByUrl('/unauthorised');
      }

    });

this.store
      .takeWhile(() => this.alive)
      .subscribe(s => {
        if (s.security.user.showSubCom && s.security.user.operator) {
          this._router.navigateByUrl('/workprogram');
        }
      });
    this.napims$
      .takeWhile(() => this.alive)
      .subscribe(napims => {
        if (napims) {
          this.store.dispatch(new OperatorActions.LoadItemsAction(''));
          this.changeDisplayMode(DisplayModeEnum.Napims);
        }
      });
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

  operatorSelected(id: string) {
    this.store.dispatch(new LoginActions.SelectOperatorAction(id));
    this.store.dispatch(new BudgetActions.LoadItemsAction(''));
    this._router.navigateByUrl('/workprogram');
  }
  ngOnChanges(changes: any) {


  }

  changeDisplayMode(mode: DisplayModeEnum) {
    // // // console.log(mode);
    this.displayMode = mode;
  }

  ngOnDestroy() {
    this.alive = false;
  }


}
