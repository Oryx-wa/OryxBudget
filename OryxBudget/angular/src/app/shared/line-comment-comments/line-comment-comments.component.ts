import { Component, OnInit, ChangeDetectionStrategy, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';



@Component({
  selector: 'app-line-comment-comments',
  templateUrl: './line-comment-comments.component.html',
  styleUrls: ['./line-comment-comments.component.scss']
})
export class LineCommentCommentsComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      formArray: this.fb.array([])
    });
  }
  addDetail(data: any) {
    const arrayControl =  <FormArray>this.form.controls['formArray'];
    const newDetail = this.fb.group({
      comment: new FormControl(''),
    });
    arrayControl.push(newDetail);
  }
  ngOnInit() {


  }
 save(data: any) { }
  removeDetail(i: number) {
    const control = <FormArray>this.form.controls['formArray'];
    control.removeAt(i);
    this.form.markAsDirty();
  }
  get formArray() { return <FormArray>this.form.get('formArray'); }
}

