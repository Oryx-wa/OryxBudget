import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorDetailsComponent } from './operator-details.component';
import { AgGridModule } from 'ag-grid-angular/main';
import { SharedModule } from './../shared/shared.module';

import { BudgetInitialisationComponent } from './budget-initialisation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LineDetailsComponent } from './line-details.component';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import { WordWrapComponent } from './../shared/renderers/word-wrap.component';
import { TextComponent } from './../shared/renderers/text.component';
import { ChildMessageComponent } from './../shared/renderers/child-message.component';
import { StyledComponent } from './../shared/renderers/styled-component';
import { DialogComponent } from './../shared/dialog/dialog.component';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    AgGridModule.withComponents([
      CurrencyComponent,
      WordWrapComponent,
      TextComponent,
      ChildMessageComponent,
      StyledComponent
    ])
  ],

  declarations: [OperatorDetailsComponent, BudgetInitialisationComponent, LineDetailsComponent,
    WordWrapComponent, TextComponent, LineDetailsComponent, ChildMessageComponent, StyledComponent
  ],
  exports: [LineDetailsComponent]

})
export class BudgetModule { }
