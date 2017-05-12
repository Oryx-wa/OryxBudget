import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
import { OryxDashboardComponent } from './oryx-dashboard/oryx-dashboard.component';
import { SecurityService } from './../login/security.service';
import { FileuploaderComponent } from './fileuploader/fileuploader.component';
import { NgUploaderModule } from 'ngx-uploader';
import { MaterializeModule } from 'angular2-materialize';
@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgUploaderModule,
     MaterializeModule,
  ],
  declarations: [// MainNavComponent, 
    OryxDashboardComponent,
    FileuploaderComponent],
  providers: [SecurityService],
  exports: [// MainNavComponent, 
    OryxDashboardComponent,
    FileuploaderComponent,
     MaterializeModule,]
})
export class SharedModule { }
