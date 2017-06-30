import { Component, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { BudgetSelector, Budget, AppState, BudgetActions } from './../../redux';

@Component({
  selector: 'app-sub-navbar',
  templateUrl: './sub-navbar.component.html',
  styleUrls: ['./sub-navbar.component.scss']
})
export class SubNavbarComponent implements OnInit, OnChanges {
  @Output() budgetSelected = new EventEmitter();
  form: FormGroup;
  budgets$: Observable<Budget[]>;


  constructor(private store: Store<AppState>, private fb: FormBuilder) {
    this.form = this.fb.group({
     budget: new FormControl('')
    });
     
   }

  ngOnInit() {
    this.budgets$ = this.store.select(BudgetSelector.getBudgetCollection);
    // this.budgets$.subscribe(budgets => console.log(budgets));
  }

  ngOnChanges(changes: any) {
    // this.budgets$ = this.store.select(BudgetSelector.getBudgetCollection);
  }

  itemSelected(id: string) {
    this.store.dispatch(new BudgetActions.SelectItemAction(id));
  }
}
