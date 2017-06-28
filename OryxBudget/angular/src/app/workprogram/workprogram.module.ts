import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular/main';
import { SharedModule } from './../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WorkprogramComponent } from './workprogram.component';
import { WpDashboardComponent } from './wp-dashboard/wp-dashboard.component';
import { ExplorationModule } from './exploration/exploration.module';
import { FacilitiesModule } from './facilities/facilities.module';
import { WorkProgramRoutingModule } from './workprogram.routing.module';
import { WellComponent} from './well/well.component';
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
    FacilitiesModule

  ],
  declarations: [WorkprogramComponent, WpDashboardComponent, WellComponent],
  exports: [WorkprogramComponent, WpDashboardComponent, WellComponent
  ]

})
export class WorkprogramModule { }
