import { Component, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Store } from '@ngrx/store';
import {
  BudgetSelector, Budget, AppState, BudgetActions,
  UserSelector, User, LoginActions
} from './../../redux';

@Component({
  selector: 'app-sub-navbar',
  templateUrl: './sub-navbar.component.html',
  styleUrls: ['./sub-navbar.component.scss']
})
export class SubNavbarComponent implements OnInit, OnChanges {
  @Output() budgetSelected = new EventEmitter();
  form: FormGroup;
  budgets$: Observable<Budget[]>;
  showLevel$: Observable<number>;

  public showSubCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showTecCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public showMalCom$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  public cssClass = 'btn waves-effect waves-light ';
  public budgetClass = '';
  public actualClass = '';
  public cashCallClass = '';

  showLevel: number;


  constructor(private store: Store<AppState>, private fb: FormBuilder) {
    this.form = this.fb.group({
      budget: new FormControl(''),
      status:new FormControl('')
    });

  }

  ngOnInit() {
    this.budgets$ = this.store.select(BudgetSelector.getBudgetCollection);
    this.showLevel$ = this.store.select(UserSelector.showLevel);
    this.showLevel$.subscribe(showLevel => this.showLevel = showLevel);
    this.store.subscribe(s => {
      this.showSubCom$.next(s.security.user.showSubCom);
      this.showTecCom$.next(s.security.user.showTecCom);
      this.showMalCom$.next(s.security.user.showMalCom);
    });
    this.changeDisplay('budget');

  }

  ngOnChanges(changes: any) {

    // this.budgets$ = this.store.select(BudgetSelector.getBudgetCollection);
  }

  itemSelected(id: string) {
    this.store.dispatch(new BudgetActions.SelectItemAction(id));
    this.store.dispatch(new BudgetActions.GetWorkProgramStatusAction(id));
  }

  changeDisplay(type: string) {
    this.store.dispatch(new LoginActions.SelectDisplay(type));
    switch (type) {
      case 'budget':
        this.budgetClass = this.cssClass + ' green disabled';
        this.actualClass = this.cssClass + ' blue';
        this.cashCallClass = this.cssClass + ' orange';
        break;
      case 'actual':
        this.budgetClass = this.cssClass + ' green';
        this.actualClass = this.cssClass + ' blue disabled';
        this.cashCallClass = this.cssClass + ' orange';
        break;
      case 'cashCall':
        this.budgetClass = this.cssClass + ' green';
        this.actualClass = this.cssClass + ' blue';
        this.cashCallClass = this.cssClass + 'orange diasbled';
        break;
    }
  }
}
