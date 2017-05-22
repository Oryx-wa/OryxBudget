import { Component, OnInit, ChangeDetectionStrategy, OnChanges } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'app-line-comment',
  templateUrl: './line-comment.component.html',
  styleUrls: ['./line-comment.component.scss']
})
export class LineCommentComponent implements OnInit {

  form: FormGroup;


  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      formArray: this.fb.array([])
    });

  }
  ngOnChanges(changes: any): void {
    let control = <FormArray>this.form.controls['formArray'];
    for (let i = control.length - 1; i >= 0; i--) {
      control.removeAt(i);
    }
    this.form.reset();
  }

  addDetail(data: any) {
    let arrayControl = <FormArray>this.form.controls['formArray'];
    let newDetail = this.fb.group({
      comments: new FormControl('', )
    })
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