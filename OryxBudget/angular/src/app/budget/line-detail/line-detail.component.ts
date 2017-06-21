import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { BudgetLines } from './../../models/';
import * as _ from 'lodash';


@Component({
  selector: 'app-line-detail',
  templateUrl: './line-detail.component.html',
  styleUrls: ['./line-detail.component.scss']
})
export class LineDetailComponent implements OnInit, OnChanges {
  @Input() actual: BudgetLines;
   @Input() showSubCom = false;
  @Input() showTecCom = false;
  @Input() showMalCom = false;

  @Input() userType = '';
  @Input() napims = false;
  @Input() operator = false;
  @Output() update = new EventEmitter();
  actuals: BudgetLines;
 form: FormGroup;


  constructor(private fb: FormBuilder) {

  }
   ngOnInit() {
  }
 ngOnChanges(changes: any): void {

    this.form = this.fb.group({
       opBudgetFC: new FormControl({ value: this.actual.opBudgetFC, disabled: true }),
      opBudgetLC: new FormControl({ value: this.actual.opBudgetLC, disabled: true }),
      opBudgetUSD: new FormControl({ value: this.actual.opBudgetUSD, disabled: true }),
      opActualFC: new FormControl({ value: this.actual.opActualFC, disabled: true }),
      opActualLC: new FormControl({ value: this.actual.opActualLC, disabled: true }),
      opActualUSD: new FormControl({ value: this.actual.opActualUSD, disabled: true }),
      /*subComActualFC: new FormControl({
        value: this.actual.subComActualFC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComActualLC: new FormControl({
        value: this.actual.subComActualLC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComActualUSD: new FormControl({
        value: this.actual.subComActualUSD,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      tecComActualFC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComActualLC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComActualUSD: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      malComActualFC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComActualLC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComActualUSD: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualFC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualLC: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualUSD: new FormControl({
        value: this.actual.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      id: new FormControl(this.actual.id),
      ActualId: new FormControl(this.actual.budgetId),
      actualStatus: new FormControl({
        value: status,
        disabled: !(this.napims === true)
      }),*/

    });

  }
save(data: any) {
    const actual: BudgetLines = _.assign({}, data);   
    this.update.emit({ actual: actual });

  }

}
