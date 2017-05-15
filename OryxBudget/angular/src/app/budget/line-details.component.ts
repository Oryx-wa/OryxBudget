import { Component, OnInit, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import {BehaviorSubject} from 'rxjs'; 
import { MaterializeAction } from 'angular2-materialize';
import { Budgets, Operators, BudgetLines, LineComments } from './../models';

@Component({
  selector: 'app-line-details',
  templateUrl: './line-details.component.html',
  styleUrls: ['./line-details.component.scss']
})
export class LineDetailsComponent implements OnInit, OnChanges {
  @Input() lines: BudgetLines[] = [];
  @Input() lineComments: LineComments[] = [];
  @Input() lineObs: BehaviorSubject<BudgetLines>;
  @Output() comments = new EventEmitter();
  @Output() saveComments = new EventEmitter();

  modalActions = new EventEmitter<string | MaterializeAction>();
  filtered: BudgetLines[] = [];
  selectedCode: BudgetLines;
  parentCode: BudgetLines;
  level: number;
  showComment = false;
  line: BudgetLines = null;


  history: string[] = ['home'];
  constructor() { }

  ngOnInit() {

  }

  ngOnChanges(changes: any) {
    this.filtered = this.lines.filter(bd => bd.level === 1);
    this.level = 0;
    console.log(this.filtered);
  }

  addHistory(code: string) {
    this.history.push(code);
  }

  filterLines(code: string, addToHistory = true) {
    if (code === 'home') {
      this.filtered = this.lines.filter(bd => bd.level === 1);
      this.level = 0;
    } else {
      this.filtered = this.lines.filter(bd => bd.fatherNum === code);
      this.selectedCode = this.lines.filter(bd => bd.code === code)[0];
      this.level = this.selectedCode.level + 1;
      if (this.level === 3) {
        this.parentCode = this.lines.filter(bd => bd.code === this.selectedCode.fatherNum)[0];
      }
      if (this.history.indexOf(code) === -1) {
        if (addToHistory) { this.addHistory(code); }
      }
      this.comments.emit({code: this.selectedCode.code, budgetId: this.selectedCode.budgetId});
    }


  }

  showDetails(code: string) {

  }

  getComments(code: string) {
    this.showComment = true;
    // this.line = this.lines.filter(bd => bd.code === code)[0];
    // this.Comments.emit();
    this.modalActions.emit({ action: 'modal', params: ['open'] });

  }

  updateComments(data: any) {
    // this.showComment = false;
    this.modalActions.emit({ action: 'modal', params: ['close'] });
    this.saveComments.emit(data);
  }

}
