import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorDetailsComponent } from './operator-details.component';
import { SharedModule } from './../shared/shared.module'

import { BudgetInitialisationComponent } from './budget-initialisation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LineDetailsComponent } from './line-details.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],

  declarations: [OperatorDetailsComponent, BudgetInitialisationComponent, LineDetailsComponent]

})
export class BudgetModule { }
