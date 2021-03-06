import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments, BudgetLines, LineStatus } from './../../models/';
import * as _ from 'lodash';

@Component({
  selector: 'app-line-comment',
  templateUrl: './line-comment.component.html',
  styleUrls: ['./line-comment.component.scss']
})
export class LineCommentComponent implements OnInit, OnChanges {
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
  @Input() displayMode = 'details';

  @Output() update = new EventEmitter();
  @Output() close = new EventEmitter();
  form: FormGroup;


  constructor(private fb: FormBuilder) {


  }
  ngOnChanges(changes: any): void {
    const status = (this.lineStatus) ? this.lineStatus[0].status : 'New';
    this.form = this.fb.group({
      opBudgetFC: new FormControl({ value: this.line.opBudgetFC, disabled: true }),
      opBudgetLC: new FormControl({ value: this.line.opBudgetLC, disabled: true }),
      opBudgetUSD: new FormControl({ value: this.line.opBudgetUSD, disabled: true }),
      subComBudgetFC: new FormControl({
        value: this.line.subComBudgetFC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComBudgetLC: new FormControl({
        value: this.line.subComBudgetLC,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      subComBudgetUSD: new FormControl({
        value: this.line.subComBudgetUSD,
        disabled: (this.showSubCom === true && this.napims === true) ? false : true
      }),
      tecComBudgetFC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComBudgetLC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      tecComBudgetUSD: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showTecCom === true && this.napims === true) ? false : true
      }),
      malComBudgetFC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComBudgetLC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      malComBudgetUSD: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalBudgetFC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalBudgetLC: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      finalBudgetUSD: new FormControl({
        value: this.line.tecComBudgetFC,
        disabled: (this.showMalCom === true && this.napims === true) ? false : true
      }),
      id: new FormControl(this.line.id),
      budgetId: new FormControl(this.line.budgetId),
      lineStatus: new FormControl({
        value: status,
        disabled: !(this.napims === true)
      }),
      formArray: this.fb.array([])
    });
    this.addDetail(null);

  }

  addDetail(data: any) {
    const arrayControl = <FormArray>this.form.controls['formArray'];
    const lineComment: LineComments = (data === null) ?
      { id: null, budgetId: this.line.budgetId, code: this.line.code, comment: '', commentStatus: '' } : data;
    const status = (this.lineStatus) ? this.lineStatus[0].status : '';
    const newDetail = this.fb.group({
      comment: new FormControl(lineComment.comment),
      id: new FormControl(lineComment.id),
      budgetId: new FormControl(lineComment.budgetId),
      commentStatus: new FormControl(''),
      code: new FormControl(lineComment.code)
    });
    arrayControl.push(newDetail);
  }
  ngOnInit() {


  }

  save(data: any) {
    const comments: LineComments[] = [];
    const newComments: any[] = data.formArray;
    const status = data.lineStatus;

    const line: BudgetLines = _.assign({}, data);

    newComments.map(lineComment => {
      if (lineComment.comment !== '') {
        comments.push(lineComment);
      }
    });
    console.log(comments);
    this.update.emit({ lineComments: comments, budgetLine: line, status: status });

  }
  removeDetail(i: number) {
    const control = <FormArray>this.form.controls['formArray'];
    control.removeAt(i);
    this.form.markAsDirty();
  }
  get formArray() { return <FormArray>this.form.get('formArray'); }

  changeDisplay(type: string) {
    this.displayMode = type;
  }

  itemSelected(item: string) {
    this.form.patchValue({
      lineStatus: item
    });
  }
}
