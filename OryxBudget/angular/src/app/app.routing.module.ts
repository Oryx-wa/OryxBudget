import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent, UnauthorisedComponent } from './home';
import { OperatorDetailsComponent } from './budget/operator-details.component';
import { BudgetInitialisationComponent } from './budget/budget-initialisation.component';
// import { LoginComponent } from './login/login.component';
import { AuthGuard } from './login/auth.guard';
import { NgModule } from '@angular/core';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  // { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canLoad: [AuthGuard] },
  { path: 'operatordetails/:id', component: OperatorDetailsComponent },
  { path: 'unauthorised', component: UnauthorisedComponent },
  { path: 'budgetInitialisation', component: BudgetInitialisationComponent }

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

