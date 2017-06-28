import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent, UnauthorisedComponent } from './home';
import { OperatorDetailsComponent } from './budget/operator-details.component';
import { BudgetInitialisationComponent } from './budget/budget-initialisation.component';
import { OperatorsComponent } from './operators/operators.component';
import { LineDetailComponent } from './budget/line-detail/line-detail.component';
// import { LoginComponent } from './login/login.component';
import { AuthGuard } from './login/auth.guard';
import { NgModule } from '@angular/core';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  // { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canLoad: [AuthGuard] },
  { path: 'operatordetails/:id', component: OperatorDetailsComponent, canLoad: [AuthGuard] },
  { path: 'linedetail/:id', component: LineDetailComponent, canLoad: [AuthGuard] },
  { path: 'unauthorised', component: UnauthorisedComponent, canLoad: [AuthGuard] },
  { path: 'budgetInitialisation', component: BudgetInitialisationComponent, canLoad: [AuthGuard] },
  { path: 'operators', component: OperatorsComponent, canLoad: [AuthGuard] },
  

];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [
    RouterModule
  ],
  providers: [AuthGuard],

})
export class AppRoutingModule { }

