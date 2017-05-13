import { Component, OnInit, ChangeDetectionStrategy, OnChanges } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-budget-initialisation',
  templateUrl: './budget-initialisation.component.html',
  styleUrls: ['./budget-initialisation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BudgetInitialisationComponent implements OnInit, OnChanges {

  form: FormGroup;


  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      year: new FormControl(''),
      description: new FormControl(''),
    });

  }
  ngOnChanges(changes: any): void {
    this.form.reset();

  }


  ngOnInit() {

  }

  save(form: FormGroup) {

  }

}
