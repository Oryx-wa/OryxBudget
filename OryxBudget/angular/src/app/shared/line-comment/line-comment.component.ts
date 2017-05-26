import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments, BudgetLines } from './../../models/';
import * as _ from 'lodash';

@Component({
  selector: 'app-line-comment',
  templateUrl: './line-comment.component.html',
  styleUrls: ['./line-comment.component.scss']
})
export class LineCommentComponent implements OnInit, OnChanges {
  @Input() line: BudgetLines;
  @Input() lineComments: LineComments[] = [{
    id: '', budgetId: '',
    code: '', comment: '', commentStatus: ''
  }];

  @Input() showSubCom = false;
  @Input() showTecCom = false;
  @Input() showMalCom = false;
  @Output() update = new EventEmitter();
  @Output() close = new EventEmitter();

  form: FormGroup;


  constructor(private fb: FormBuilder) {


  }
  ngOnChanges(changes: any): void {
    this.form = this.fb.group({
      opBudgetFC: new FormControl({value: this.line.opBudgetFC, disabled: true}),
      opBudgetLC: new FormControl({value: this.line.opBudgetLC, disabled: true}),
      opBudgetUSD: new FormControl({value: this.line.opBudgetUSD, disabled: true}),
      subComBudgetFC: new FormControl(this.line.subComBudgetFC),
      subComBudgetLC: new FormControl(this.line.subComBudgetLC),
      subComBudgetUSD: new FormControl(this.line.subComBudgetUSD),
      tecComBudgetFC: new FormControl(this.line.tecComBudgetFC),
      tecComBudgetLC: new FormControl(this.line.tecComBudgetLC),
      tecComBudgetUSD: new FormControl(this.line.tecComBudgetUSD),
      malComBudgetFC: new FormControl(this.line.malComBudgetFC),
      malComBudgetLC: new FormControl(this.line.malComBudgetLC),
      malComBudgetUSD: new FormControl(this.line.malComBudgetUSD),
      finalBudgetFC: new FormControl(this.line.finalBudgetFC),
      finalBudgetLC: new FormControl(this.line.finalBudgetLC),
      finalBudgetUSD: new FormControl(this.line.finalBudgetUSD),
      id: new FormControl(this.line.id),
      budgetId: new FormControl(this.line.budgetId),
      lineStatus: new FormControl(this.line.lineStatus),
      formArray: this.fb.array([])
    });

    const control = <FormArray>this.form.controls['formArray'];
    for (let i = control.length - 1; i >= 0; i--) {
      control.removeAt(i);
    }
    if (this.lineComments === null) {
      this.lineComments = [];
    }

    if (this.lineComments.length === 0) {
      this.addDetail(null);
    }
    this.lineComments.map(comment => {
      this.addDetail(comment);
    });
  }

  addDetail(data: any) {
    const arrayControl = <FormArray>this.form.controls['formArray'];
    const lineComment: LineComments = (data === null) ?
      { id: null, budgetId: this.line.budgetId, code: this.line.code, comment: '', commentStatus: '' } : data;
    const newDetail = this.fb.group({
      comment: new FormControl(lineComment.comment),
      id: new FormControl(lineComment.id),
      budgetId: new FormControl(lineComment.budgetId),
      commentStatus: new FormControl(lineComment.commentStatus),
      code: new FormControl(lineComment.code)
    });
    arrayControl.push(newDetail);
  }
  ngOnInit() {

  }

  save(data: any) {
    const comments: LineComments[] = [];
    const newComments: any[] = data.formArray;

    const line: BudgetLines = _.assign({}, data);

    newComments.map(lineComment => {
      comments.push(lineComment);
    });
    // console.log(comments);
    this.update.emit({lineComments: comments, budgetLine: line});

  }
  removeDetail(i: number) {
    const control = <FormArray>this.form.controls['formArray'];
    control.removeAt(i);
    this.form.markAsDirty();
  }
  get formArray() { return <FormArray>this.form.get('formArray'); }
}
