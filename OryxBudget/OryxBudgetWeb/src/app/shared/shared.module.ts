import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
import { OryxDashboardComponent } from './oryx-dashboard/oryx-dashboard.component';
import { SecurityService } from './../login/security.service';
@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [// MainNavComponent, 
    OryxDashboardComponent],
  providers: [SecurityService],
  exports: [// MainNavComponent, 
    OryxDashboardComponent]
})
export class SharedModule { }
