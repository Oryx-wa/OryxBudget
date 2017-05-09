import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import {OryxDashboardComponent } from './shared/oryx-dashboard/oryx-dashboard.component';
@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    OryxDashboardComponent 
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
