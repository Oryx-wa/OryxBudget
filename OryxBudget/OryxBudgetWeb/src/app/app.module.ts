import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
//import { LoginComponent } from './login/login.component';
import { SecurityService } from './login/security.service';
import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { BudgetModule} from './budget/budget.module';
import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { OryxDashboardComponent } from './shared/oryx-dashboard/oryx-dashboard.component';
import { Configuration } from './app.constants';

// import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AppRoutingModule } from './app.routing.module';
@NgModule({
  declarations: [
    AppComponent,
  MainNavComponent,
    //OryxDashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
     HomeModule,
     BudgetModule,
     AppRoutingModule,
    
   
  ],
  providers: [SecurityService, Configuration],
  bootstrap: [AppComponent]
})
export class AppModule { }
