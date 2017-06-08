import { Component, OnInit, Input, Output, OnChanges, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { LineComments } from './../../models';
import * as _ from 'lodash';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit, OnChanges {
  @Input() lineComments: LineComments[] = [];
  @Input() userType: string;
  @Input() napims = false;
  @Input() operator = false;

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
    const comment: LineComments = _.assign({}, {
      id: '', budgetId: '', userType: (this.napims === true) ? 'napims' : 'operator',
      code: '', comment: data.message, commentStatus: '', userName: '',
      commentType: '', createDate: new Date()
    });
    const newComments: LineComments[] = [];
    this.lineComments.push(comment);
    newComments.push(comment);
    this.form.reset();
    this.update.emit(data.message);
    console.log(comment);

  }

}
