import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments, BudgetLines } from './../../models/';

@Component({
  selector: 'app-line-comment',
  templateUrl: './line-comment.component.html',
  styleUrls: ['./line-comment.component.scss']
})
export class LineCommentComponent implements OnInit, OnChanges {
  @Input() budgetLines: BudgetLines;
  @Input() lineComments: LineComments[] = [{
    id: '', budgetId: '',
    code: '', comment: '', commentStatus: ''
  }];
  form: FormGroup;


  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      formArray: this.fb.array([])
    });

  }
  ngOnChanges(changes: any): void {
    const control = <FormArray>this.form.controls['formArray'];
    for (let i = control.length - 1; i >= 0; i--) {
      control.removeAt(i);
    }
    if (this.lineComments === null) {
      this.lineComments = [];
    }

    if (this.lineComments.length === 0) {
      this.lineComments.push({
        id: '', budgetId: '',
        code: '', comment: '', commentStatus: ''
      });

      this.lineComments.map(comment => {
        this.addDetail(comment);
      });
    }
  }

  addDetail(data: any) {
    const arrayControl = <FormArray>this.form.controls['formArray'];
    const lineComment: LineComments = (data === null) ?
      { id: '', budgetId: this.budgetLines.budgetId, code: this.budgetLines.code, comment: '', commentStatus: '' } : data;
    const newDetail = this.fb.group({
      comments: new FormControl(lineComment.comment, Validators.required),
      id: new FormControl(lineComment.id),
      budgetId: new FormControl(lineComment.budgetId),
      commentStatus: new FormControl(lineComment.commentStatus),
      code: new FormControl(lineComment.code)
    });
    arrayControl.push(newDetail);
  }
  ngOnInit() {

  }

  save(data: any[]) {
  }
  removeDetail(i: number) {
    const control = <FormArray>this.form.controls['formArray'];
    control.removeAt(i);
    this.form.markAsDirty();
  }
  get formArray() { return <FormArray>this.form.get('formArray'); }
}
