import { Component, OnInit, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { MaterializeDirective, MaterializeAction } from 'angular2-materialize';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import {
  AppState, Budget, UserSelector, BudgetActions,
  BudgetLines, BudgetSelector, BudgetLineActions, BudgetLineSelector
} from './../../redux';
import { DisplayModeEnum } from '../../shared/shared-enum.enum';

@Component({
  selector: 'app-exploration',
  templateUrl: './exploration.component.html',
  styleUrls: ['./exploration.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExplorationComponent implements OnInit {

  actions1 = new EventEmitter<string | MaterializeAction>();
  public showApproval = false;
  form: FormGroup;
  budget$: Observable<Budget>;
  lines$: Observable<BudgetLines[]>;
  budgetId: string;

  public napims$: Observable<boolean>;
  public subCom$: Observable<boolean>;
  public tecCom$: Observable<boolean>;
  public malCom$: Observable<boolean>;

  public dept$: Observable<string>;
  public operator$: Observable<boolean>;

  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;
  constructor(private fb: FormBuilder, private store: Store<AppState>) { }

  ngOnInit() {
    this.dept$ = this.store.select(UserSelector.dept);
    this.subCom$ = this.store.select(UserSelector.subCom);
    this.tecCom$ = this.store.select(UserSelector.tecCom);
    this.malCom$ = this.store.select(UserSelector.malCom);
    this.napims$ = this.store.select(UserSelector.napims);

    this.budget$ = this.store.select(BudgetSelector.selectedBudget);
    this.budget$.subscribe(budget => {
      console.log(budget);
      if (budget.id !== '') {
        this.budgetId = budget.id;
        this.getBudgetLines();
      }

    });
    this.form = this.fb.group({
      status: new FormControl({}),
    });
    this.lines$ = this.store.select(BudgetLineSelector.getBudgetLineCollection);
    this.changeDisplayMode(DisplayModeEnum.Budget);


  }
  openFirst() {
    this.showApproval = true;
  }

  getBudgetLines() {
    this.store.dispatch(new BudgetLineActions.LoadItemsAction(this.budgetId));
  }

  changeDisplayMode(mode: DisplayModeEnum) {
    // // console.log(mode); 
    this.displayMode = mode;
  }

  selectBudget(id: string) {
    this.store.dispatch(new BudgetActions.SelectItemAction(id));
    this.getBudgetLines();
  }

}
