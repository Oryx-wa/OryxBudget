import { Component, OnInit, EventEmitter, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { MaterializeDirective, MaterializeAction } from 'angular2-materialize';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import {
  AppState, Budget, UserSelector, BudgetActions, Actual, ActualSelector,
  BudgetLines, BudgetSelector, BudgetLineActions, BudgetLineSelector, ActualActions
} from './../../redux';
import { DisplayModeEnum } from '../../shared/shared-enum.enum';

@Component({
  selector: 'app-exploration',
  templateUrl: './exploration.component.html',
  styleUrls: ['./exploration.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExplorationComponent implements OnInit, OnDestroy {

  actions1 = new EventEmitter<string | MaterializeAction>();
  public showApproval = false;
  form: FormGroup;
  budget$: Observable<Budget>;
  lines$: Observable<BudgetLines[]>;
  actuals$: Observable<Actual[]>
  budgetId = '';

  public napims$: Observable<boolean>;
  public subCom$: Observable<boolean>;
  public tecCom$: Observable<boolean>;
  public malCom$: Observable<boolean>;
  public display$: Observable<string>;

  public dept$: Observable<string>;
  public operator$: Observable<boolean>;
  private alive = true;

  public displayMode: DisplayModeEnum;
  public displayModeEnum = DisplayModeEnum;
  constructor(private fb: FormBuilder, private store: Store<AppState>) { }

  ngOnInit() {
    this.displayMode = DisplayModeEnum.Card;
    this.dept$ = this.store.select(UserSelector.dept);
    this.subCom$ = this.store.select(UserSelector.subCom);
    this.tecCom$ = this.store.select(UserSelector.tecCom);
    this.malCom$ = this.store.select(UserSelector.malCom);
    this.napims$ = this.store.select(UserSelector.napims);
    this.display$ = this.store.select(UserSelector.display);

    this.display$.subscribe(display => {
      if (this.budgetId !== '' && this.budgetId !== null) {
        switch (display) {
          case 'budget':
            this.changeDisplayMode(DisplayModeEnum.Budget);
            this.store.dispatch(new BudgetLineActions.LoadItemsAction(this.budgetId));
            break;
          case 'actual':
            this.changeDisplayMode(DisplayModeEnum.Actual);
            this.store.dispatch(new ActualActions.LoadItemsAction(this.budgetId));
            break;
          case 'cashCall':
            this.changeDisplayMode(DisplayModeEnum.CashCall);

            break;
          default:
            this.changeDisplayMode(DisplayModeEnum.Budget);
            break;
        }
      }

    });
    this.budget$ = this.store.select(BudgetSelector.selectedBudget);
    this.budget$
      .takeWhile(() => this.alive)
      .subscribe(budget => {
        if (budget.id) {
          if (budget.id !== '' && budget.id !== null) {
            this.budgetId = budget.id;
            switch (this.displayMode) {
              case DisplayModeEnum.Budget:
                this.store.dispatch(new BudgetLineActions.LoadItemsAction(this.budgetId));
                break;
              case DisplayModeEnum.Actual:
                this.store.dispatch(new ActualActions.LoadItemsAction(this.budgetId));
                break;
              default:
                break;
            }
          }
        }

      });
    this.form = this.fb.group({
      status: new FormControl({}),
    });
    this.lines$ = this.store.select(BudgetLineSelector.getBudgetLineCollection);
    this.actuals$ = this.store.select(ActualSelector.getActualCollection);
    
    this.changeDisplayMode(DisplayModeEnum.Budget);
  }
  openFirst() {
    this.showApproval = true;
  }

  getBudgetLines() {

  }

  changeDisplayMode(mode: DisplayModeEnum) {
    // // console.log(mode); 
    this.displayMode = mode;
  }

  selectBudget(id: string) {
    this.store.dispatch(new BudgetActions.SelectItemAction(id));
    // this.store.dispatch(new BudgetLineActions.LoadItemsAction(this.budgetId));
  }

  ngOnDestroy() {
    this.alive = false;
  }

}
