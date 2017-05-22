import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular/main';
import { SharedModule } from './../shared/shared.module';
import { SecurityService } from './../login/security.service';
import { OperatorViewComponent } from './operator-view.component';
import { UploadComponent } from './upload.component';
import { CurrencyComponent } from './../shared/renderers/currency.component';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AgGridModule.withComponents(CurrencyComponent)
  ],
  declarations: [OperatorViewComponent, UploadComponent, ],
  exports: [
    OperatorViewComponent]
})

export class OperatorViewModule { }
