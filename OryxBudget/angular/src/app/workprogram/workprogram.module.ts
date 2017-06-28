import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { AgGridModule } from 'ag-grid-angular/main';
import { SharedModule } from './../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WorkprogramComponent } from './workprogram.component';
import { WorkprogramTypeComponent } from './workprogram-type/workprogram-type.component';
import { DrillingcostTypeComponent } from './drillingcost-type/drillingcost-type.component';
import { WellComponent } from './well/well.component';
import { FieldComponent } from './field/field.component';
import { WpDashboardComponent } from './wp-dashboard/wp-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AgGridModule,

  ],
  declarations: [WorkprogramComponent, WorkprogramTypeComponent, DrillingcostTypeComponent,
    WellComponent, FieldComponent, WpDashboardComponent],
  exports: [WorkprogramComponent, WorkprogramTypeComponent, DrillingcostTypeComponent,
    WellComponent, FieldComponent, WpDashboardComponent
  ]
  
})
export class WorkprogramModule { }
