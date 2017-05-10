import { Component, OnInit, Input } from '@angular/core';
import { Budgets } from './../models/budget';
import { Operators } from './../models/operators';

@Component({
  selector: 'app-operator-view',
  templateUrl: './operator-view.component.html',
  styleUrls: ['./operator-view.component.scss']
})
export class OperatorViewComponent implements OnInit {
  @Input() name = '';
  @Input() operatorId = '';
  @Input() role = '';
   @Input() operators: Operators[] = [];
 

  constructor() { }

  ngOnInit() {
    console.log(this.role)
  }

}
