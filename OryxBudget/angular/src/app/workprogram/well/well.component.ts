import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-well',
  templateUrl: './well.component.html',
  styleUrls: ['./well.component.scss']
})
export class WellComponent implements OnInit {

   public titled = 'Well';
  form: FormGroup;
  constructor(private fb: FormBuilder) { }
  ngOnInit() {
    this.form = this.fb.group({
      code: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      fieldId: new FormControl('', Validators.required),
      location: new FormControl('', Validators.required),
      terrain: new FormControl('', Validators.required),
      spudDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      rigRate: new FormControl('', Validators.required),
      supportService: new FormControl('', Validators.required),
       totalCost: new FormControl('', Validators.required)
    });

  }
  save(data: any) { }
}
