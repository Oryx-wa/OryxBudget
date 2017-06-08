import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-field',
  templateUrl: './field.component.html',
  styleUrls: ['./field.component.scss']
})
export class FieldComponent implements OnInit {
  public titled = 'Field';
  form: FormGroup;
  constructor(private fb: FormBuilder) { }
  ngOnInit() {
    this.form = this.fb.group({
      code: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),   
      consessionId: new FormControl('', Validators.required),
      dimension: new FormControl('', Validators.required),
      area: new FormControl('', Validators.required),
      plannedVolume: new FormControl('', Validators.required),
      ratePerVolume: new FormControl('', Validators.required),
      totalCost: new FormControl('', Validators.required),
       remark: new FormControl('', Validators.required)
    });

  }
  save(data: any) { }
}
