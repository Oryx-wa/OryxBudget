import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AgGridModule } from 'ag-grid-angular/main';
//import { LoginComponent } from './login/login.component';
import { SecurityService } from './login/security.service';
import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { BudgetModule } from './budget/budget.module';
import { StoreModule, Store } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { reducer, initLoginState, initBdState, AppState } from './redux';
import { CoreModule } from './core/core.module';

import { MainNavComponent } from './shared/main-nav/main-nav.component';
import { OryxDashboardComponent } from './shared/oryx-dashboard/oryx-dashboard.component';
import { Configuration } from './app.constants';

// import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AppRoutingModule } from './app.routing.module';
import { OperatorsModule } from './operators/operators.module';
import { WorkprogramModule } from './workprogram/workprogram.module';
import { BudgetEffects, BudgetService } from './redux/budgets/budget/';
import { LogoutComponent } from './shared/logout/logout.component';





@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    LogoutComponent


    //OryxDashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    CoreModule.forRoot(),
    // StoreModule.provideStore(reducer),
    StoreDevtoolsModule.instrumentOnlyWithExtension(),
    EffectsModule.run(BudgetEffects),
    HomeModule,
    BudgetModule,
    AppRoutingModule,
    AgGridModule,
    OperatorsModule,
    WorkprogramModule


  ],

  providers: [SecurityService, Configuration, BudgetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
