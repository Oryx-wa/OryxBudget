import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExplorationComponent } from './exploration.component';
import { SharedModule } from './../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExplorationRoutingModule} from './exploration.routing.module';
import { AgGridModule } from 'ag-grid-angular/main';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ExplorationRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [ExplorationComponent],
  exports: [ExplorationComponent]
})
export class ExplorationModule { }
