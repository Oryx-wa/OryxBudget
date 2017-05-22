import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Budgets, Operators, BudgetLines } from './../models';

@Component({
  selector: 'app-line-details',
  templateUrl: './line-details.component.html',
  styleUrls: ['./line-details.component.scss']
})
export class LineDetailsComponent implements OnInit, OnChanges {
  @Input() lines: BudgetLines[] = [];
  filtered: BudgetLines[] = [];
  selectedCode: BudgetLines;
  parentCode: BudgetLines;
  level: number;


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
    }


  }

  showDetails(code: string) {

  }

}
