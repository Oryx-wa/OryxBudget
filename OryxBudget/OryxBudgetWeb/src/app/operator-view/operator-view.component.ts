import { Component, OnInit, Input } from '@angular/core';
import { Operators } from './../models';

@Component({
  selector: 'app-operator-view',
  templateUrl: './operator-view.component.html',
  styleUrls: ['./operator-view.component.scss']
})
export class OperatorViewComponent implements OnInit {
   @Input() name = '';
  @Input() operatorId = '';
  @Input() role = '';
  constructor() { }

  ngOnInit() {
  }

}
