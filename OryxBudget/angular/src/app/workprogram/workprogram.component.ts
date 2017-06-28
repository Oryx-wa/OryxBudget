import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppState, LoginSTATE, UserSelector, TokenSelector } from '../redux';
import { Store } from '@ngrx/store';
import { UserModel } from '../redux/login/models';


@Component({
  selector: 'app-workprogram',
  templateUrl: './workprogram.component.html',
  styleUrls: ['./workprogram.component.scss']
})
export class WorkprogramComponent implements OnInit {
  public napims$: Observable<boolean>;
  public subCom$: Observable<boolean>;
  public tecCom$: Observable<boolean>;
  public malCom$: Observable<boolean>;
  public dept$: Observable<string>;
  public operator$: Observable<boolean>;
  constructor(
    private store: Store<AppState>) { }

  ngOnInit() {
    this.dept$ = this.store.select(UserSelector.dept);
    this.subCom$ = this.store.select(UserSelector.subCom);
    this.tecCom$ = this.store.select(UserSelector.tecCom);
    this.malCom$ = this.store.select(UserSelector.malCom);
    this.napims$ = this.store.select(UserSelector.napims);
    this.operator$ = this.store.select(UserSelector.operator);
  }

}
