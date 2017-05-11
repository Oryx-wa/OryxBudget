import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorDetailsComponent } from './operator-details.component';
import { BudgetInitialisationComponent } from './budget-initialisation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [OperatorDetailsComponent, BudgetInitialisationComponent]
})
export class BudgetModule { }
