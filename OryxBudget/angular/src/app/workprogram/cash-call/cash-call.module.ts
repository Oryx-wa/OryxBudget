import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CashCallComponent } from './cash-call.component';
import { SharedModule } from './../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CashCallRoutingModule} from './cash-call.routing.module';
import { AgGridModule } from 'ag-grid-angular/main';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    CashCallRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [CashCallComponent],
  exports: [CashCallComponent]
})
export class CashCallModule { }
