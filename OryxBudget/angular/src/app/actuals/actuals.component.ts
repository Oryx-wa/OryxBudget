import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments, BudgetLines, LineStatus, Actual } from './../models/';
import * as _ from 'lodash';

@Component({
  selector: 'app-actuals',
  templateUrl: './actuals.component.html',
  styleUrls: ['./actuals.component.scss']
})
export class ActualsComponent implements OnInit, OnChanges {
  @Input() line: BudgetLines;
  @Input() lineComments: LineComments[] = [{
    id: '', budgetId: '', userType: '',
    code: '', comment: '', commentStatus: '', userName: '', commentType: '', createDate: new Date()
  }];
  @Input() lineStatus: LineStatus[] = [{ budgetId: '', code: '', status: '' }]
  @Input() showSubCom = false;
  @Input() showTecCom = false;
  @Input() showMalCom = false;

  @Input() userType = '';
  @Input() napims = false;
  @Input() operator = false;
  @Input() displayMode = 'actual';

  @Output() update = new EventEmitter();
  @Output() close = new EventEmitter();
  form: FormGroup;


  constructor(private fb: FormBuilder) {


  }
  ngOnChanges(changes: any): void {
    const status = (this.lineStatus) ? this.lineStatus[0].status : 'New';
    this.form = this.fb.group({
      opActualFC: new FormControl({ value: this.line.opActualFC, disabled: true }),
      opActualLC: new FormControl({ value: this.line.opActualLC, disabled: true }),
      opActualUSD: new FormControl({ value: this.line.opActualUSD, disabled: true }),
      subComActualFC: new FormControl({
        value: this.line.subComActualFC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComActualLC: new FormControl({
        value: this.line.subComActualLC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComActualUSD: new FormControl({
        value: this.line.subComActualUSD,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      tecComActualFC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComActualLC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComActualUSD: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      malComActualFC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComActualLC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComActualUSD: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualFC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualLC: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalActualUSD: new FormControl({
        value: this.line.tecComActualFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      id: new FormControl(this.line.id),
      ActualId: new FormControl(this.line.budgetId),
      lineStatus: new FormControl({
        value: status,
        disabled: !(this.napims === true)
      }),

    });
    this.addDetail(null);

  }

  addDetail(data: any) {
    const status = (this.lineStatus) ? this.lineStatus[0].status : '';

  }

  ngOnInit() {
  }

  save(data: any) {
    const line: Actual = _.assign({}, data);
    const status = data.lineStatus;
    this.update.emit({ line: line, status: status });

  }

  changeDisplay(type: string) {
    this.displayMode = type;
  }
  itemSelected(item: string) {
    this.form.patchValue({
      lineStatus: item
    });
  }
}
