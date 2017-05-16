import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments, BudgetLines } from './../../models/';

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
  @Output() update = new EventEmitter();
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
      comment: new FormControl(lineComment.comment, Validators.required),
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
    let comments: LineComments[] = [];
    let newComments: any[] = data.formArray;

    newComments.map(lineComment => {
      comments.push(lineComment);
    });
    this.update.emit(comments);

  }
  removeDetail(i: number) {
    const control = <FormArray>this.form.controls['formArray'];
    control.removeAt(i);
    this.form.markAsDirty();
  }
  get formArray() { return <FormArray>this.form.get('formArray'); }
}
