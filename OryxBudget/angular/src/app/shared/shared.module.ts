import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MainNavComponent } from './main-nav/main-nav.component';
import { OryxDashboardComponent } from './oryx-dashboard/oryx-dashboard.component';
import { SecurityService } from './../login/security.service';
import { FileuploaderComponent } from './fileuploader/fileuploader.component';
import { NgUploaderModule } from 'ngx-uploader';

import { LineCommentComponent } from './line-comment/line-comment.component';
import { LineCommentDetailsComponent } from './line-comment/line-comment-details.component';

import { MaterializeModule } from 'angular2-materialize';
@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgUploaderModule,
    FormsModule,
    ReactiveFormsModule,
    MaterializeModule,

  ],
  declarations: [// MainNavComponent, 
    OryxDashboardComponent,
    FileuploaderComponent,
    LineCommentComponent,
    LineCommentDetailsComponent],
  providers: [SecurityService],
  exports: [// MainNavComponent, 
    OryxDashboardComponent,
    FileuploaderComponent,
    MaterializeModule, LineCommentComponent]
})
export class SharedModule { }
