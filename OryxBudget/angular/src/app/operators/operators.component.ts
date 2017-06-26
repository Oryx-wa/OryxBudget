import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectionStrategy, OnChanges } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';


@Component({
  selector: 'app-operators',
  templateUrl: './operators.component.html',
  styleUrls: ['./operators.component.scss']
})
export class OperatorsComponent implements OnInit {

  public title = 'Operator Details';
  public titled = 'Contact Details';
  form: FormGroup;
  id = new FormControl('');
  name = new FormControl('', );
  code = new FormControl('', );
  operatorTypeId = new FormControl('', );
  imageScr = new FormControl('', );
  firstName = new FormControl('', );
  lastName = new FormControl('', );
  email = new FormControl('', );
  userName = new FormControl('', );

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      id: this.id,
      name: this.name,
      code: this.code,
      operatorTypeId: this.operatorTypeId,
      imageScr: this.imageScr,
      formArray: this.fb.array([])
    });
  }
  addDetail(data: any) {
    const arrayControl = <FormArray>this.form.controls['formArray'];
    const newDetail = this.fb.group({
      email: new FormControl('', Validators.required),
      id: new FormControl(''),
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      userName: new FormControl('')
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
