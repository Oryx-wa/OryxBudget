import { Component, OnInit, Input, Output, OnChanges, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComment, initLineComment, BudgetLines } from './../../redux';
import * as _ from 'lodash';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit, OnChanges {
  @Input() lineComments: LineComment[] = [];
  @Input() userType: string;
  @Input() napims = false;
  @Input() operator = false;
  @Input() line: BudgetLines;

  @Output() update = new EventEmitter();
  @Output() close = new EventEmitter();

  form: FormGroup;
  lineCommentsForm: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      message: new FormControl('', Validators.required)
    });


  }

  ngOnChanges(changes: any) {
    console.log(this.lineComments);
  }

  addDetail(data: any) {
    const arrayControl = <FormArray>this.form.controls['formArray'];
    const newDetail = this.fb.group({
      comment: new FormControl(''),
    });
    arrayControl.push(newDetail);
  }

  send(data: any) {
    const comment: LineComment = _.assign({}, initLineComment, {
       budgetId: this.line.budgetId, userType: (this.napims === true) ? 'napims' : 'operator',
      code: this.line.code, comment: data.message, commentStatus: '',
      createDate: new Date()
    });
    const newComments: LineComment[] = [];
    this.lineComments.push(comment);
    newComments.push(comment);
    this.form.reset();
    this.update.emit(comment);
    console.log(comment);

  }

}
