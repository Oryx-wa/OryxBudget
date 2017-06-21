import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { OryxDashboardComponent } from './oryx-dashboard/oryx-dashboard.component';
import { SecurityService } from './../login/security.service';
import { FileuploaderComponent } from './fileuploader/fileuploader.component';
import { NgUploaderModule } from 'ngx-uploader';
import { ListComponent } from './listcomponent/list.component';
import { LineCommentComponent } from './line-comment/line-comment.component';
import { LineCommentDetailsComponent } from './line-comment/line-comment-details.component';
import { CurrencyComponent } from './../shared/renderers/currency.component';
import { SelectModule } from 'ng-select';
import { Ng2PaginationModule } from 'ng2-pagination';
import { SimpleNotificationsModule, PushNotificationsModule } from 'angular2-notifications';
import { NotificationsService } from 'angular2-notifications';
import { MaterializeModule } from 'angular2-materialize';
import { DialogComponent } from './dialog/dialog.component';
import { AttachmentComponent } from './attachment/attachment.component';
import { NotificationComponent } from './notification/notification.component';
import { CommentsComponent } from './comment/comments.component';
// import { LineCommentCommentsComponent } from './line-comment-comments/line-comment-comments.component';
// import { LineCommentCommentsDetailsComponent } from './line-comment-comments/line-comment-comments-details.component';
import { FileuploadAttachmentComponent } from './fileupload-attachment/fileupload-attachment.component';
@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgUploaderModule,
    FormsModule,
    Ng2PaginationModule,
    SelectModule,
    ReactiveFormsModule,
    MaterializeModule,
    BrowserAnimationsModule,
    SimpleNotificationsModule, PushNotificationsModule,

  ],
  declarations: [// MainNavComponent,
    OryxDashboardComponent,
    FileuploaderComponent,
    LineCommentComponent,
    ListComponent,
    LineCommentDetailsComponent,
    DialogComponent, CurrencyComponent, AttachmentComponent, NotificationComponent,
     CommentsComponent,  FileuploadAttachmentComponent],
  providers: [SecurityService, NotificationsService],
  exports: [// MainNavComponent,
    OryxDashboardComponent, NotificationComponent,
    FileuploaderComponent, CommentsComponent, AttachmentComponent, FileuploadAttachmentComponent,
    MaterializeModule, LineCommentComponent, CurrencyComponent,
    DialogComponent, ListComponent, Ng2PaginationModule, SelectModule]
})
export class SharedModule { }
