import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-drillingcost-type',
  templateUrl: './drillingcost-type.component.html',
  styleUrls: ['./drillingcost-type.component.scss']
})
export class DrillingcostTypeComponent implements OnInit {
 public titled = 'Drilling Cost Type';
 form: FormGroup;
  constructor(private fb: FormBuilder) { }
  ngOnInit() {
     this.form = this.fb.group({
      code: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      type: new FormControl('', Validators.required)
    });

  }
 save(data: any) {}
}
