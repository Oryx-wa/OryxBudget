import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SharedModule} from './../shared/shared.module';
import { SecurityService } from './../login/security.service';
import { OperatorViewComponent} from './operator-view.component';
import { UploadComponent } from './upload.component';
@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [OperatorViewComponent, UploadComponent],
   exports: [
    OperatorViewComponent]
})

export class OperatorViewModule { }
