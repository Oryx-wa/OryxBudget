import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-workprogram-type',
  templateUrl: './workprogram-type.component.html',
  styleUrls: ['./workprogram-type.component.scss']
})
export class WorkprogramTypeComponent implements OnInit {
  public titled = 'Work Program Type';
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
