import { Component, OnInit,  EventEmitter } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { MaterializeDirective, MaterializeAction } from 'angular2-materialize';

@Component({
  selector: 'app-exploration',
  templateUrl: './exploration.component.html',
  styleUrls: ['./exploration.component.scss']
})
export class ExplorationComponent implements OnInit {

actions1 = new EventEmitter<string | MaterializeAction>();
  public showApproval = false;
 form: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
            status: new FormControl({}),
    });
  }
openFirst() {
    this.showApproval = true;
  }
}
