import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular/main';
import { SharedModule } from './../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { WorkprogramComponent } from './workprogram.component';
import { WpDashboardComponent } from './wp-dashboard/wp-dashboard.component';
import { ExplorationModule } from './exploration/exploration.module';
import { FacilitiesModule } from './facilities/facilities.module';
import { WorkProgramRoutingModule } from './workprogram.routing.module';
import { WellComponent } from './well/well.component';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import { WordWrapComponent } from './../shared/renderers/word-wrap.component';
import { TextComponent } from './../shared/renderers/text.component';
import { ChildMessageComponent } from './../shared/renderers/child-message.component';
import { StyledComponent } from './../shared/renderers/styled-component';
import {
  BudgetLineEffects,  BudgetLineService, ActualEffects, ActualService,
  LineCommentEffects, LineCommentService
} from './../redux';
@NgModule({
  imports: [
    CommonModule,
    WorkProgramRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AgGridModule,
    ExplorationModule,
    FacilitiesModule,
    AgGridModule.withComponents([
      CurrencyComponent,
      WordWrapComponent,
      TextComponent,
      ChildMessageComponent,
      StyledComponent
    ]),
    EffectsModule.run(BudgetLineEffects),
    EffectsModule.run(ActualEffects),
    EffectsModule.run(LineCommentEffects)

  ],
  declarations: [WorkprogramComponent, WpDashboardComponent, WellComponent,],
  exports: [WorkprogramComponent, WpDashboardComponent, WellComponent,
  ],
  providers: [BudgetLineService, ActualService, LineCommentService]

})
export class WorkprogramModule { }
