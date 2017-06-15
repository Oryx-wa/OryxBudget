import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterializeModule } from 'angular2-materialize';
import { SelectModule } from 'ng-select';
import { ActualsComponent } from './actuals.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    SelectModule,
    FormsModule,
    ReactiveFormsModule,
    MaterializeModule,
  ],
  declarations: [ActualsComponent],
   exports: [ MaterializeModule, SelectModule, ActualsComponent]
})
export class ActualsModule { }
