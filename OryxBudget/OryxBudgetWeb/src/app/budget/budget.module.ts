import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorDetailsComponent } from './operator-details.component';
import { LineDetailsComponent } from './line-details.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [OperatorDetailsComponent, LineDetailsComponent]
})
export class BudgetModule { }
